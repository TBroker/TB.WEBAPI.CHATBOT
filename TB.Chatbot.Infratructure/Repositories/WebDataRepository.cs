using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Globalization;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Entities;
using TB.Chatbot.Domain.Reponses;
using TB.Chatbot.Domain.Requests;
using TB.Chatbot.Infrastructure.DBContexts;

namespace TB.Chatbot.Infrastructure.Repositories
{
    public class WebDataRepository(WebTBrokerDBContext webTBrokerDBContext, ILogger<WebDataRepository> logger, IConfiguration config) : IWebDataRepository
    {
        private readonly WebTBrokerDBContext _webTBrokerDBContext = webTBrokerDBContext;
        private readonly ILogger<WebDataRepository> _logger = logger;
        private readonly IConfiguration _configuration = config;

        public async Task<WebUserJWTAuthorized?> GetDataUserToken(ReqUserInfo reqUserInfo)
        {
            try
            {
                return await _webTBrokerDBContext.WebUserJWTAuthorizeds
                                .FirstOrDefaultAsync(u => u.username!.Equals(reqUserInfo.UserName)
                                && u.password!.Equals(reqUserInfo.Password)
                                && u.status!.ToUpper().Equals("A"));
            }
            catch (Exception ex)
            {
                _logger.LogError($"result token : {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<RespCarBrand>> GetDataCarBrand()
        {
            try
            {
                return await _webTBrokerDBContext.WebPremiumsMotors
                                .Where(x => x.status!.ToUpper() == "A")
                                .GroupBy(x => x.car_brand)
                                .Select(x => new RespCarBrand { car_brand = x.Key })
                                .OrderBy(x => x.car_brand)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"m car brand : {ex.Message}");
                return [];
            }
        }

        public async Task<IEnumerable<RespCarModel>> GetDataCarModel(ReqCarModel reqCarModel)
        {
            try
            {
                return await _webTBrokerDBContext.WebPremiumsMotors
                                .Where(x => x.car_brand!.Trim()!.Equals(reqCarModel.car_brand!.Trim()) && x.status!.ToUpper() == "A")
                                .GroupBy(x => new { x.car_brand, x.car_model })
                                .Select(x => new RespCarModel
                                {
                                    car_brand = x.Key.car_brand,
                                    car_model = x.Key.car_model
                                })
                                .OrderBy(x => x.car_model)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"m car model : {ex.Message}");
                return [];
            }
        }

        public async Task<IEnumerable<RespCarEngineSize>> GetDataCarEngineSize(ReqCarEngineSize reqCarEngineSize)
        {
            try
            {
                return await _webTBrokerDBContext.WebPremiumsMotors
                                .Where(x => x.car_brand!.Trim().ToUpper()!.Equals(reqCarEngineSize.car_brand!.Trim().ToUpper())
                                && x.car_model!.Trim().ToUpper()!.Equals(reqCarEngineSize.car_model!.Trim().ToUpper()))
                                .GroupBy(x => new { x.car_brand, x.car_model, x.car_engine_size })
                                .Select(x => new RespCarEngineSize
                                {
                                    car_engine_size = x.Key.car_engine_size
                                })
                                .OrderBy(x => x.car_engine_size)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"m car engine size : {ex.Message}");
                return [];
            }
        }

        public async Task<IEnumerable<RespCarYear>> GetDataCarYear(ReqCarYear reqCarYear)
        {
            try
            {
                return await _webTBrokerDBContext.WebPremiumsMotors
                                .Where(x => x.car_brand!.Trim().ToUpper()!.Equals(reqCarYear.car_brand!.Trim().ToUpper())
                                && x.car_model!.Trim().ToUpper()!.Equals(reqCarYear.car_model!.Trim().ToUpper()))
                                .GroupBy(x => new { x.car_brand, x.car_model, x.car_year })
                                .Select(x => new RespCarYear
                                {
                                    car_year = x.Key.car_year
                                })
                                .OrderByDescending(x => x.car_year)
                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"m car year : {ex.Message}");
                return [];
            }
        }

        public async Task<IEnumerable<RespCoverType>> GetDataCoverageType(ReqCoverType reqCoverType)
        {
            try
            {
                var query = from prem in _webTBrokerDBContext.WebPremiumsMotors
                            join cover in _webTBrokerDBContext.WebDataMotorCoverageTypes on prem.coverage_code equals cover.coverage_code
                            where prem.car_brand!.Trim().ToUpper().Equals(reqCoverType.car_brand) && prem.car_model!.Trim().ToUpper().Equals(reqCoverType.car_model)
                            group new { cover.coverage_code, cover.coverage_name } by new RespCoverType
                            {
                                coverage_code = cover.coverage_code,
                                coverage_name = cover.coverage_name
                            } into grouped
                            select new RespCoverType
                            {
                                coverage_code = grouped.Key.coverage_code,
                                coverage_name = grouped.Key.coverage_name
                            };

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"master coverage type : {ex.Message}");
                return [];
            }
        }

        public async Task<IEnumerable<RespCoverType>> GetDataCoverageType()
        {
            try
            {
                var query = from cover in _webTBrokerDBContext.WebDataMotorCoverageTypes
                            where cover.coverage_code != "T"
                            select new RespCoverType
                            {
                                coverage_code = cover.coverage_code,
                                coverage_name = cover.coverage_name
                            };

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"master coverage type : {ex.Message}");
                return [];
            }
        }

        public async Task<IEnumerable<RespCompany>> GetDataCompany()
        {
            try
            {
                var query = from co in _webTBrokerDBContext.WebCompanies
                            select new RespCompany
                            {
                                company_code = co.company_code,
                                company_name = co.title
                            };
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"master company : {ex.Message}");
                return [];
            }
        }

        public async Task<IEnumerable<RespPremiumList>> GetDataPremiumsList(ReqPremiumList reqPremiumList)
        {
            try
            {
                var currentDateInt = int.Parse(DateTime.Now.ToString("yyyyMMdd", CultureInfo.GetCultureInfo("en-GB")));

                var user = _webTBrokerDBContext.WebUserAgents.Where(x => x.UserID == reqPremiumList.userid);

                var groupAgent = "";
                var businessType = "";
                var profitSharingCode = "";

                if (user != null)
                {
                    groupAgent = user.Select(x => x.BusinessType!.Equals("4") ? "MLM" : x.BusinessType.Equals("6") ? "TFG" : "NON MLM").FirstOrDefault();
                    businessType = user.Select(x => x.BusinessType).FirstOrDefault();
                    profitSharingCode = user.Select(x => string.IsNullOrEmpty(x.ProfitSharingCode) ? "111" : x.ProfitSharingCode).FirstOrDefault();
                }

                var product_code = await _webTBrokerDBContext.WebMasterPlanConditions.Where(x => x.group_agent == groupAgent && x.business_type == businessType && x.profit_sharing == profitSharingCode).Select(x => x.product_code).ToListAsync();

                var query = (from p in _webTBrokerDBContext.WebPremiumsMotors
                             join co in _webTBrokerDBContext.WebCompanies on p.company_code equals co.company_code
                             join c in _webTBrokerDBContext.WebDataMotorCoverageTypes on p.coverage_code equals c.coverage_code
                             join mp in _webTBrokerDBContext.WebMasterPlans
                              on new
                              {
                                  p.TM_PRODUCT_CODE,
                                  p.company_code,
                                  p.effective_date,
                                  p.expire_date
                              }
                              equals new
                              {
                                  mp.TM_PRODUCT_CODE,
                                  mp.company_code,
                                  mp.effective_date,
                                  mp.expire_date
                              }
                             where p.car_brand!.ToUpper().Trim().Equals(reqPremiumList.car_brand!.ToUpper().Trim())
                             && p.car_model!.ToUpper().Trim().Equals(reqPremiumList.car_model!.ToUpper().Trim())
                             && p.coverage_code!.ToUpper().Trim().Equals(reqPremiumList.coverage_code)
                             && p.car_year!.ToUpper().Trim().Equals(reqPremiumList.car_year)
                             && p.car_engine_size!.ToUpper().Trim().Equals(reqPremiumList.car_engine_size)
                             && p.status!.Equals("A")
                             && mp.status == 1
                             && mp.show_front == 1
                             select new
                             {
                                 id = (int)p.id,
                                 tm_product_code = p.TM_PRODUCT_CODE,
                                 p.title_masterplan,
                                 c.coverage_code,
                                 c.coverage_name,
                                 p.company_code,
                                 company_name = co.title,
                                 company_image = $"{_configuration["AppSetting:BaseURL"]}/{co.img1}",
                                 p.repair_type,// S = ซ่อมศูนย์ , B = ซ่อมอู่
                                 repair_name = p.repair_type!.Equals("S") ? "ซ่อมศูนย์" : "ซ่อมอู่",// S = ซ่อมศูนย์ , B = ซ่อมอู่
                                 p.car_brand,
                                 p.car_model,
                                 p.car_year,
                                 p.car_engine_size,
                                 sum_insure = (int)Decimal.Parse(string.IsNullOrEmpty(p.sum_insure!) ? "0" : p.sum_insure),
                                 f_t = (int)Decimal.Parse(string.IsNullOrEmpty(p.f_t!) ? "0" : p.f_t),
                                 s_p = (int)Decimal.Parse(string.IsNullOrEmpty(p.s_p!) ? "0" : p.s_p),
                                 od = (int)Decimal.Parse(string.IsNullOrEmpty(p.od!) ? "0" : p.od),
                                 p.atm_type,
                                 net_premiums = Decimal.Parse(string.IsNullOrEmpty(p.net_premiums) ? "0" : p.net_premiums),
                                 stamp = Decimal.Parse(string.IsNullOrEmpty(p.stamp) ? "0" : p.stamp),
                                 tax = Decimal.Parse(string.IsNullOrEmpty(p.tax) ? "0" : p.tax),
                                 total_premiums = Decimal.Parse(string.IsNullOrEmpty(p.total_premiums) ? "0" : p.total_premiums),
                                 cmi_net_premiums = Decimal.Parse(string.IsNullOrEmpty(p.cmi_net_premiums) ? "0" : p.cmi_net_premiums),
                                 cmi_stamp = Decimal.Parse(string.IsNullOrEmpty(p.cmi_stamp) ? "0" : p.cmi_stamp),
                                 cmi_tax = Decimal.Parse(string.IsNullOrEmpty(p.cmi_tax) ? "0" : p.cmi_tax),
                                 cmi_total_premiums = Decimal.Parse(string.IsNullOrEmpty(p.cmi_total_premiums) ? "0" : p.cmi_total_premiums),
                                 total_premiums_with_cmi = Decimal.Parse(string.IsNullOrEmpty(p.total_premiums_with_cmi) ? "0" : p.total_premiums_with_cmi),
                                 effective_date = Int32.Parse(p.effective_date!.ToString()),
                                 expire_date = Int32.Parse(p.expire_date!.ToString()),
                                 mp.group_agent,
                                 mp.business_type,
                                 mp.profit_sharing_code,
                             }).ToList();

                var data = query
                .Where(x => product_code.Any(pc => x.tm_product_code.Contains(pc!)))
                .Select(x => new RespPremiumList
                {
                    id = x.id,
                    tm_product_code = x.tm_product_code,
                    title_masterplan = x.title_masterplan,
                    coverage_code = x.coverage_code,
                    coverage_name = x.coverage_name,
                    company_code = x.company_code,
                    company_name = x.company_name,
                    company_image = x.company_image,
                    repair_type = x.repair_type,
                    repair_name = x.repair_name,
                    car_brand = x.car_brand,
                    car_model = x.car_model,
                    car_year = x.car_year,
                    car_engine_size = x.car_engine_size,
                    atm_type = x.atm_type,
                    net_premiums = x.net_premiums,
                    stamp = x.stamp,
                    tax = x.tax,
                    total_premiums = x.total_premiums,
                    cmi_net_premiums = x.cmi_net_premiums,
                    cmi_stamp = x.cmi_stamp,
                    cmi_tax = x.cmi_tax,
                    cmi_total_premiums = x.cmi_total_premiums,
                    total_premiums_with_cmi = x.total_premiums_with_cmi,
                    sum_insure = x.sum_insure,
                    f_t = x.f_t,
                    s_p = x.s_p,
                    od = x.od,
                });

                if (reqPremiumList.coverage_code != "1" && reqPremiumList.coverage_code != "2" && reqPremiumList.coverage_code != "3")
                {
                    var resultsNonType1 = data.Where(x => x.sum_insure == (reqPremiumList.sum_insured == 0 ? x.sum_insure : reqPremiumList.sum_insured)
                    && x.od == (reqPremiumList.od == 0 ? x.od : reqPremiumList.od)
                    && x.f_t == (reqPremiumList.f_t == 0 ? x.f_t : reqPremiumList.f_t)
                    && x.s_p == (reqPremiumList.s_p == 0 ? x.s_p : reqPremiumList.s_p)
                    ).Select(x => new RespPremiumList
                    {
                        id = x.id,
                        tm_product_code = x.tm_product_code,
                        title_masterplan = x.title_masterplan,
                        coverage_code = x.coverage_code,
                        coverage_name = x.coverage_name,
                        company_code = x.company_code,
                        company_name = x.company_name,
                        company_image = x.company_image,
                        repair_type = x.repair_type,
                        repair_name = x.repair_name,
                        car_brand = x.car_brand,
                        car_model = x.car_model,
                        car_year = x.car_year,
                        car_engine_size = x.car_engine_size,
                        atm_type = x.atm_type,
                        net_premiums = x.net_premiums,
                        stamp = x.stamp,
                        tax = x.tax,
                        total_premiums = x.total_premiums,
                        cmi_net_premiums = x.cmi_net_premiums,
                        cmi_stamp = x.cmi_stamp,
                        cmi_tax = x.cmi_tax,
                        cmi_total_premiums = x.cmi_total_premiums,
                        total_premiums_with_cmi = x.total_premiums_with_cmi,
                        sum_insure = x.sum_insure, // จำนวนเงินสูงสุดที่บริษัทประกันจะจ่ายให้ หากเกิดความเสียหาย
                        od = x.od, // ความเสียหายต่อตัวรถของผู้เอาประกันภัย
                        f_t = x.f_t, // ความคุ้มครองกรณีรถไฟไหม้หรือถูกโจรกรรม
                        s_p = x.s_p // ความคุ้มครองกรณีการก่อจลาจล การนัดหยุดงาน หรือภัยสาธารณะ
                    }).ToList();

                    return await Task.Run(() => resultsNonType1.OrderBy(o => (o.company_code == "TNI") ? 0.0 : 1.0)
                           .ThenBy(o => Convert.ToDecimal(o.sum_insure))
                           .ThenBy(o => Convert.ToDecimal(o.total_premiums))
                           .ToList());
                }

                var resultsType1 = (from x in data
                                    let maxSumInsure = (from wm in data
                                                        where wm.company_code == x.company_code
                                                              //&& wm.status!.Equals("A")
                                                              && wm.car_brand!.ToUpper().Equals(reqPremiumList.car_brand!.ToUpper().Trim())
                                                              && wm.car_model!.ToUpper().Equals(reqPremiumList.car_model!.ToUpper().Trim())
                                                              && wm.car_engine_size!.ToUpper().Equals(reqPremiumList.car_engine_size)
                                                              && wm.car_year!.ToUpper().Equals(reqPremiumList.car_year)
                                                              && wm.coverage_code!.ToUpper().Equals(reqPremiumList.coverage_code)
                                                              && wm.tm_product_code == x.tm_product_code
                                                        group wm by wm.company_code into g
                                                        select g.Max(w => w.sum_insure)).AsEnumerable()
                                    .Select(sum_insure => sum_insure).Max()
                                    where x.sum_insure == maxSumInsure
                                    select new RespPremiumList
                                    {
                                        id = x.id,
                                        tm_product_code = x.tm_product_code,
                                        title_masterplan = x.title_masterplan,
                                        coverage_code = x.coverage_code,
                                        coverage_name = x.coverage_name,
                                        company_code = x.company_code,
                                        company_name = x.company_name,
                                        company_image = x.company_image,
                                        repair_type = x.repair_type,
                                        repair_name = x.repair_name,
                                        car_brand = x.car_brand,
                                        car_model = x.car_model,
                                        car_year = x.car_year,
                                        car_engine_size = x.car_engine_size,
                                        atm_type = x.atm_type,
                                        net_premiums = x.net_premiums,
                                        stamp = x.stamp,
                                        tax = x.tax,
                                        total_premiums = x.total_premiums,
                                        cmi_net_premiums = x.cmi_net_premiums,
                                        cmi_stamp = x.cmi_stamp,
                                        cmi_tax = x.cmi_tax,
                                        cmi_total_premiums = x.cmi_total_premiums,
                                        total_premiums_with_cmi = x.total_premiums_with_cmi,
                                        sum_insure = maxSumInsure, // จำนวนเงินสูงสุดที่บริษัทประกันจะจ่ายให้ หากเกิดความเสียหาย
                                        od = x.od, // ความเสียหายต่อตัวรถของผู้เอาประกันภัย
                                        f_t = x.f_t, // ความคุ้มครองกรณีรถไฟไหม้หรือถูกโจรกรรม
                                        s_p = x.s_p // ความคุ้มครองกรณีการก่อจลาจล การนัดหยุดงาน หรือภัยสาธารณะ
                                    });

                return await Task.Run(() => resultsType1.OrderBy(o => (o.company_code == "TNI") ? 0.0 : 1.0)
                            .ThenBy(o => Convert.ToDecimal(o.sum_insure))
                            .ThenBy(o => Convert.ToDecimal(o.total_premiums))
                            .ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return [];
            }
        }

        public async Task<RespPremium> GetDataPremiums(string premium_id)
        {
            try
            {
                var query = await (from p in _webTBrokerDBContext.WebPremiumsMotors
                                   join co in _webTBrokerDBContext.WebCompanies on p.company_code equals co.company_code
                                   join c in _webTBrokerDBContext.WebDataMotorCoverageTypes on p.coverage_code equals c.coverage_code
                                   where p.id.Equals(Convert.ToDecimal(premium_id))
                                   select new RespPremium
                                   {
                                       id = (int)p.id,
                                       tm_product_code = p.TM_PRODUCT_CODE,
                                       title_masterplan = p.title_masterplan,
                                       coverage_code = c.coverage_code,
                                       coverage_name = c.coverage_name,
                                       company_code = p.company_code,
                                       company_name = co.title,
                                       company_image = $"{_configuration["AppSetting:BaseURL"]}/" + co.img1,
                                       repair_type = p.repair_type,// S = ซ่อมศูนย์ , B = ซ่อมอู่
                                       repair_name = p.repair_type!.Equals("S") ? "ซ่อมศูนย์" : "ซ่อมอู่",// S = ซ่อมศูนย์ , B = ซ่อมอู่
                                       car_brand = p.car_brand,
                                       car_model = p.car_model,
                                       car_year = p.car_year,
                                       car_engine_size = p.car_engine_size,
                                       sum_insure = (int)Decimal.Parse(string.IsNullOrEmpty(p.sum_insure!) ? "0" : p.sum_insure!),
                                       od = (int)Decimal.Parse(string.IsNullOrEmpty(p.od!) ? "0" : p.od!),
                                       f_t = (int)Decimal.Parse(string.IsNullOrEmpty(p.f_t!) ? "0" : p.f_t!),
                                       s_p = (int)Decimal.Parse(string.IsNullOrEmpty(p.s_p!) ? "0" : p.s_p!),
                                       atm_type = p.atm_type,
                                       net_premiums = Decimal.Parse(string.IsNullOrEmpty(p.net_premiums) ? "0" : p.net_premiums!),
                                       stamp = Decimal.Parse(string.IsNullOrEmpty(p.stamp) ? "0" : p.stamp!),
                                       tax = Decimal.Parse(string.IsNullOrEmpty(p.tax) ? "0" : p.tax!),
                                       total_premiums = Decimal.Parse(string.IsNullOrEmpty(p.total_premiums) ? "0" : p.total_premiums!),
                                       cmi_net_premiums = (int)Decimal.Parse(string.IsNullOrEmpty(p.cmi_net_premiums) ? "0" : p.cmi_net_premiums!),
                                       cmi_stamp = (int)Decimal.Parse(string.IsNullOrEmpty(p.cmi_stamp) ? "0" : p.cmi_stamp!),
                                       cmi_tax = Decimal.Parse(string.IsNullOrEmpty(p.cmi_tax) ? "0" : p.cmi_tax!),
                                       cmi_total_premiums = Decimal.Parse(string.IsNullOrEmpty(p.cmi_total_premiums) ? "0" : p.cmi_total_premiums!),
                                       total_premiums_with_cmi = Decimal.Parse(string.IsNullOrEmpty(p.total_premiums_with_cmi) ? "0" : p.total_premiums_with_cmi!),
                                   }).FirstOrDefaultAsync();

                return query!;
            }
            catch (Exception ex)
            {
                _logger.LogError($"data premium list : {ex.Message}");
                return new RespPremium();
            }
        }

        public async Task<RespCoverText> GetDataCoverText(ReqCoverText reqCoverText)
        {
            try
            {
                var premium = _webTBrokerDBContext.WebPremiumsMotors.Where(w => w.id == Convert.ToInt32(reqCoverText.premium_id)).FirstOrDefault();
                string od = Convert.ToDouble(premium.od?.ToString()).ToString("N0") ?? "";
                string f_t = Convert.ToDouble(premium.f_t?.ToString()).ToString("N0") ?? "";
                string s_p = Convert.ToDouble(premium.s_p?.ToString()).ToString("N0") ?? "";

                var query = from m in _webTBrokerDBContext.WebMasterPlans
                            join c in _webTBrokerDBContext.WebProductCoverTxts on m.coverage_code equals c.coverage_code
                            where m.TM_PRODUCT_CODE!.Trim().Equals(reqCoverText.tm_product_code!)
                            && m.company_code!.ToUpper().Trim().Equals(reqCoverText.company_code!.ToUpper().Trim())
                            && m.coverage_code!.Trim().Equals(reqCoverText.coverage_code!)
                            select new RespCoverText
                            {
                                cover_txt1 = c.cover_txt1,
                                cover_txt2 = c.cover_txt2,
                                cover_txt3 = c.cover_txt3,
                                cover_txt4 = c.cover_txt4,
                                cover_txt5 = c.cover_txt5,
                                cover_txt6 = c.cover_txt6,
                                cover_txt7 = c.cover_txt7,
                                cover_txt8 = c.cover_txt8,
                                cover_txt9 = c.cover_txt9,
                                cover_txt10 = c.cover_txt10,
                                cover_txt11 = c.cover_txt11,
                                cover_txt12 = c.cover_txt12,
                                cover_txt13 = c.cover_txt13,
                                cover_txt14 = c.cover_txt14,
                                cover_txt15 = c.cover_txt15,
                                cover_txt16 = c.cover_txt16,
                                cover_txt17 = c.cover_txt17,
                                cover_txt18 = c.cover_txt18,
                                cover_txt19 = c.cover_txt19,
                                cover_txt20 = c.cover_txt20,
                                cover_val1 = m.cover_val1,
                                cover_val2 = m.cover_val2,
                                cover_val3 = m.cover_val3,
                                cover_val4 = m.cover_val4,
                                cover_val5 = m.cover_val5,
                                cover_val6 = m.cover_val6,
                                cover_val7 = m.cover_val7,
                                cover_val8 = m.cover_val8,
                                cover_val9 = m.cover_val9,
                                cover_val10 = m.cover_val10,
                                cover_val11 = m.cover_val11,
                                cover_val12 = m.cover_val12,
                                cover_val13 = m.cover_val13,
                                cover_val14 = m.cover_val14,
                                cover_val15 = m.cover_val15,
                                cover_val16 = m.cover_val16,
                                cover_val17 = m.cover_val17,
                                cover_val18 = m.cover_val18,
                                cover_val19 = m.cover_val19,
                                cover_val20 = m.cover_val20,
                            };

                var results = await query.ToListAsync();

                foreach (var coverage in results)
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        var txtProp = typeof(RespCoverText).GetProperty($"cover_txt{i}");
                        var valProp = typeof(RespCoverText).GetProperty($"cover_val{i}");
                        var txtValue = txtProp?.GetValue(coverage)?.ToString();
                        var valValue = valProp?.GetValue(coverage);

                        // ปรับค่าความคุ้มครองตามตารางเบี้ย
                        if (txtValue.Contains("- รถยนต์สูญหาย") && txtValue.Contains("ไฟไหม้"))
                        {
                            valValue = $"{f_t} บาท";
                        }
                        else if (txtValue.Contains("- ความเสียหายต่อรถยนต์"))
                        {
                            valValue = $"{od} บาท";
                        }
                        else if (txtValue.Contains("หมายเหตุ"))
                        {
                            valValue = string.Concat($"เพิ่มความคุ้มครองน้ำท่วม {s_p} บาท", valValue);
                        }
                        valProp?.SetValue(coverage, valValue);
                    }
                }

                return results.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"data c text : {ex.Message}");
                return new RespCoverText();
            }
        }

        public async Task<IEnumerable<RespUser>> GetDataUser(ReqUser reqUser)
        {
            try
            {
                var queryDoc = from d in _webTBrokerDBContext.WebUserAgentDocs
                               join dd in _webTBrokerDBContext.WebUserAgentDocDetails on d.id equals dd.doc_id
                               join dt in _webTBrokerDBContext.WebUserAgentDocTypes on dd.DocCode equals dt.DocCode
                               where d.UserID!.Equals(reqUser.userid)
                               select new
                               {
                                   d.id,
                                   dd.DocCode,
                                   dt.DocName,
                                   dd.DocNo,
                               };

                var docNo = "ว00027/2559";
                var list = (from dd in _webTBrokerDBContext.WebUserAgentDocDetails
                            join d in _webTBrokerDBContext.WebUserAgentDocs on dd.doc_id equals d.id into doc
                            from x in doc.DefaultIfEmpty()
                            where x.UserID == reqUser.userid && dd.DocCode == "D04"
                            select new
                            {
                                DocNo = string.IsNullOrEmpty(dd.DocNo) ? docNo : dd.DocNo,
                                dd.DocExpire
                            }).FirstOrDefault();

                if (list != null)
                {
                    if (!string.IsNullOrEmpty(list.DocExpire))
                    {
                        docNo = Convert.ToInt32(list.DocExpire) < Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd", CultureInfo.GetCultureInfo("en-GB"))) ? docNo : list.DocNo;
                    }
                }

                return await _webTBrokerDBContext.WebUserAgents
                       .Where(x => x.UserID!.Equals(reqUser.userid))
                       .Select(x => new RespUser
                       {
                           agentcode = x.UserID,
                           titletxt = x.TitleTxt,
                           name = x.Name,
                           lastname = x.LastName,
                           birth_date = $"{x.Birthdate!.Substring(0, 4)}-{x.Birthdate.Substring(4, 2)}-{x.Birthdate.Substring(6, 2)}",
                           mobilephone = x.MobilePhone,
                           email = x.Email,
                           line_id = x.LineID,
                           business_type_code = x.BusinessType,
                           business_type = (x.BusinessType!.Equals("1") ? "นายหน้าทั่วไป" :
                           x.BusinessType!.Equals("2") ? "อู่ในเครือธนชาต" :
                           x.BusinessType!.Equals("3") ? "พนักงานในเครือ" :
                           x.BusinessType!.Equals("4") ? "โครงสร้างบริหารทีม (MLM)" :
                           x.BusinessType!.Equals("5") ? "พนักงานสำรวจภัย (Surveyor)" :
                           x.BusinessType!.Equals("6") ? "ธนชาต แฟมิลี่ (TFG)" :
                           ""),
                           business_group = x.BusinessType!.Equals("4") ? "MLM" : x.BusinessType.Equals("6") ? "TFG" : "NON MLM",
                           account_type = x.ACCOUNT_TYPE,
                           doc_no_car_ins = docNo,//queryDoc.Where(x => x.DocCode.Equals("D04")).Select(x => x.DocNo).FirstOrDefault(),
                           doc_no_life_ins = queryDoc.Where(x => x.DocCode.Equals("D05")).Select(x => x.DocNo).FirstOrDefault(),
                           addressno = x.AddressNo,
                           addressalley = x.AddressAlley,
                           addressstreet = x.AddressStreet,
                           addressprovincetxt = x.AddressProvinceTxt,
                           addressdistricttxt = x.AddressDistrictTxt,
                           addresssubdistricttxt = x.AddressSubDistrictTxt,
                           addresszipcode = x.AddressZipcode,
                       }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"data result : {ex.Message}");
                return [];
            }
        }

        public async Task<RespCalComm> CalculationPremium(ReqCalComm reqCalComm)
        {
            var userAgent = await _webTBrokerDBContext.WebUserAgents
                .Where(x => x.UserID!.Equals(reqCalComm.userid))
                .Select(x => new
                {
                    userid = x.UserID,
                    business_type = x.BusinessType!.Equals("4") ? "MLM" : x.BusinessType.Equals("6") ? "TFG" : "NON MLM",
                    account_type = x.ACCOUNT_TYPE,
                })
                .FirstOrDefaultAsync();

            var product_cmi = reqCalComm.atm_type switch
            {
                "เก๋ง" => "M24",
                "กระบะ 4 ประตู" => "M24",
                "กระบะ 2 ประตู" => "M25",
                "ตู้" => "M28",
                _ => "",
            };

            var comm_tax = await _webTBrokerDBContext.WebCmsCommissionTaxConfigs.FirstOrDefaultAsync();

            var comm_vmi = await _webTBrokerDBContext.WebDataCommissionRates
                .Where(x => x.company_code!.ToUpper().Trim().Equals(reqCalComm.company_code) &&
                x.TM_PRODUCT_CODE!.ToUpper().Trim().Equals(reqCalComm.product_code) &&
                x.ACCOUNT_TYPE!.ToUpper().Trim().Equals(userAgent!.account_type) &&
                x.group_agent!.Trim().Equals(userAgent.business_type))
                .FirstOrDefaultAsync();

            var comm_cmi = await _webTBrokerDBContext.WebDataCommissionRates
                .Where(x => x.company_code!.ToUpper().Trim().Equals(reqCalComm.company_code) &&
                x.TM_PRODUCT_CODE!.ToUpper().Trim().Equals(product_cmi) &&
                x.ACCOUNT_TYPE!.ToUpper().Trim().Equals(userAgent!.account_type) &&
                x.group_agent!.Trim().Equals(userAgent.business_type))
                .FirstOrDefaultAsync();

            var respCalComm = new RespCalComm()
            {
                comm_percent = Convert.ToDouble(Double.TryParse(comm_vmi!.comm_sale_service, out double comm_percent) ? comm_percent : "0.00"),
                comm_percent_tax = Convert.ToDouble(Double.TryParse(comm_tax!.pb_config_value, out double comm_percent_tax) ? comm_percent_tax : "0.00"),
                cmi_comm_percent = Convert.ToDouble(Double.TryParse(comm_cmi!.comm_sale_service, out double cmi_comm_percent) ? cmi_comm_percent : "0.00"),
                cmi_comm_percent_tax = Convert.ToDouble(Double.TryParse(comm_tax!.pb_config_value, out double cmi_comm_percent_tax) ? cmi_comm_percent_tax : "0.00"),
            };

            return respCalComm;
        }

        public async Task<IEnumerable<RespProduct>> GetDataProduct(ReqProduct reqProduct)
        {
            try
            {
                var query = from pm in _webTBrokerDBContext.WebPremiumsMotors
                            join mp in _webTBrokerDBContext.WebMasterPlans on pm.TM_PRODUCT_CODE equals mp.TM_PRODUCT_CODE
                            where pm.company_code!.Equals(reqProduct.company_code) && pm.coverage_code!.Equals(reqProduct.coverage_code)
                            group new { mp.TM_PRODUCT_CODE, mp.title } by new RespProduct
                            {
                                product_code = mp.TM_PRODUCT_CODE,
                                product_name = mp.title
                            } into grouped
                            select new RespProduct
                            {
                                product_code = grouped.Key.product_code,
                                product_name = grouped.Key.product_name
                            };
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"data product : {ex.Message}");
                return [];
            }
        }

        public async Task<IEnumerable<RespAutoMobile>> GetDataAutoMobile()
        {
            try
            {
                var query = from pm in _webTBrokerDBContext.WebPremiumsMotors
                            group new { pm.atm_type_txt } by new RespAutoMobile
                            {
                                atm_text = pm.atm_type_txt,
                            } into grouped
                            select new RespAutoMobile
                            {
                                atm_text = grouped.Key.atm_text,
                            };

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"master auto mobile : {ex.Message}");
                return [];
            }
        }

        public async Task<IEnumerable<WebDataTracking>> GetDataTracking(ReqDataTracking reqDataTracking)
        {
            try
            {
                var query = from tk in _webTBrokerDBContext.WebDataTrackings
                            where tk.NameInsurance!.Equals(reqDataTracking.NameIns!) && tk.CarRegistration!.Equals(reqDataTracking.CarRegis!)
                            select tk;

                return await query.Take(10).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get data tracking : {ex.Message}");
                return [];
            }
        }

        public async Task<RespAddOrderMotor> InsertOrderMotor(ReqOrderMotor reqOrderMotor)
        {
            try
            {
                var message = new RespAddOrderMotor()
                {
                    QuoteNumber = reqOrderMotor.QuoteNumber,
                    Message = "",
                    Status = false,
                };

                var duplicate = await _webTBrokerDBContext.WebOrderMotors
                           .Where(w => w.quo_number == reqOrderMotor.QuoteNumber)
                           .Select(s => new { s.quo_number })
                           .ToListAsync();
                if (duplicate.Count > 0)
                {
                    message.Message = $"มีข้อมูลเลขใบเสนอราคานี้แล้ว";
                    message.Status = false;
                    return message;
                }

                var tm_product_code = reqOrderMotor.PremiumList.FirstOrDefault()!.ProductCode;
                if (reqOrderMotor == null || reqOrderMotor.PremiumList.Count <= 0)
                {
                    message.Message = "ไม่พบข้อมูลเบี้ยประกัน";
                    message.Status = false;
                    return message;
                }

                var productDstGroup = "";
                var dstGroup = await _webTBrokerDBContext.WebDataProductTMs
                    .Where(cc => cc.TM_PRODUCT_CODE == tm_product_code)
                    .Take(1)
                    .ToListAsync();

                if (dstGroup.Count > 0)
                    productDstGroup = dstGroup[0].TM_PRODUCT_DST_GROUP!;

                var quoRemark = await _webTBrokerDBContext.WebQuoRemarks
                    .Where(x => x.pb_TM_PRODUCT_DST_GROUP != "" && x.pb_TM_PRODUCT_DST_GROUP == productDstGroup && x.show_front == 1 && x.status == 1)
                    .Select(s => new { info = s.pb_info, en_info = s.pb_en_info })
                    .Take(1)
                    .ToListAsync();

                var orderMotor = new WebOrderMotor()
                {
                    date_create = DateTime.Now,
                    date_update = DateTime.Now,
                    status_system = "Q1",
                    UserID = reqOrderMotor.UserId,
                    quo_number = reqOrderMotor.QuoteNumber,
                    tm_product_code = tm_product_code,
                    coverage_code = reqOrderMotor.CoverageCode,
                    car_brand = reqOrderMotor.CarBrand,
                    car_model = reqOrderMotor.CarModel,
                    car_sub_model = reqOrderMotor.CarSubModel,
                    car_engine_size = reqOrderMotor.CarEngineSize,
                    car_year = reqOrderMotor.CarYear,
                    name = reqOrderMotor.CustName,
                    last_name = reqOrderMotor.CustLastName,
                    vehicle_license = reqOrderMotor.VehicleLicense,
                    phone_number = reqOrderMotor.VehicleLicense,
                    email = reqOrderMotor.Email,
                    buy_cmi = reqOrderMotor.BuyCMI,
                    is_cmi = null,
                    status = 1,
                    quo_remark = (quoRemark.Count > 0) ? quoRemark[0].info : "",
                    en_quo_remark = (quoRemark.Count > 0) ? quoRemark[0].en_info : ""
                };
                await _webTBrokerDBContext.AddAsync(orderMotor);
                //var insertOrderMotor = _webTBrokerDBContext.SaveChangesAsync();

                var motorPremiums = await _webTBrokerDBContext.WebPremiumsMotors
                    .Where(w => reqOrderMotor.PremiumList.Select(x => x.PremiumsId).Contains(w.id))
                    .ToListAsync();

                var listOrderMotorPremiums = new List<WebOrderMotorPremiums>();

                foreach (var premiums in motorPremiums)
                {
                    #region ### msater plan ####

                    var master_plan = await _webTBrokerDBContext.WebMasterPlans
                                .Where(w =>
                                    premiums.TM_PRODUCT_CODE == w.pb_TM_PRODUCT_CODE &&
                                    premiums.TM_PRODUCT_CODE_OIC == w.pb_TM_PRODUCT_CODE_OIC &&
                                    premiums.company_code == w.pb_company_code &&
                                    premiums.effective_date == w.pb_effective_date &&
                                    premiums.expire_date == w.pb_expire_date
                                    )
                                .Select(s => new
                                {
                                    lastupdate = s.lastupdate,
                                    cover_val1 = s.pb_cover_val1,
                                    cover_val2 = s.pb_cover_val2,
                                    cover_val3 = s.pb_cover_val3,
                                    cover_val4 = s.pb_cover_val4,
                                    cover_val5 = s.pb_cover_val5,
                                    cover_val6 = s.pb_cover_val6,
                                    cover_val7 = s.pb_cover_val7,
                                    cover_val8 = s.pb_cover_val8,
                                    cover_val9 = s.pb_cover_val9,
                                    cover_val10 = s.pb_cover_val10,
                                    cover_val11 = s.pb_cover_val11,
                                    cover_val12 = s.pb_cover_val12,
                                    cover_val13 = s.pb_cover_val13,
                                    cover_val14 = s.pb_cover_val14,
                                    cover_val15 = s.pb_cover_val15,
                                    cover_val16 = s.pb_cover_val16,
                                    cover_val17 = s.pb_cover_val17,
                                    cover_val18 = s.pb_cover_val18,
                                    cover_val19 = s.pb_cover_val19,
                                    cover_val20 = s.pb_cover_val20,
                                    en_cover_val1 = s.pb_en_cover_val1,
                                    en_cover_val2 = s.pb_en_cover_val2,
                                    en_cover_val3 = s.pb_en_cover_val3,
                                    en_cover_val4 = s.pb_en_cover_val4,
                                    en_cover_val5 = s.pb_en_cover_val5,
                                    en_cover_val6 = s.pb_en_cover_val6,
                                    en_cover_val7 = s.pb_en_cover_val7,
                                    en_cover_val8 = s.pb_en_cover_val8,
                                    en_cover_val9 = s.pb_en_cover_val9,
                                    en_cover_val10 = s.pb_en_cover_val10,
                                    en_cover_val11 = s.pb_en_cover_val11,
                                    en_cover_val12 = s.pb_en_cover_val12,
                                    en_cover_val13 = s.pb_en_cover_val13,
                                    en_cover_val14 = s.pb_en_cover_val14,
                                    en_cover_val15 = s.pb_en_cover_val15,
                                    en_cover_val16 = s.pb_en_cover_val16,
                                    en_cover_val17 = s.pb_en_cover_val17,
                                    en_cover_val18 = s.pb_en_cover_val18,
                                    en_cover_val19 = s.pb_en_cover_val19,
                                    en_cover_val20 = s.pb_en_cover_val20,
                                    sub_insure = s.pb_sub_insure
                                })
                                .OrderByDescending(or => or.lastupdate)
                                .Take(1)
                                .FirstOrDefaultAsync();

                    #endregion ### msater plan ####

                    #region ### cover text ####

                    var cover_txt = await (from pt in _webTBrokerDBContext.WebProductCoverTxts
                                           join ptm in _webTBrokerDBContext.WebDataProductTMs on pt.pb_TM_PRODUCT_DST_GROUP equals ptm.TM_PRODUCT_DST_GROUP
                                           where ptm.TM_PRODUCT_CODE == premiums.TM_PRODUCT_CODE && pt.pb_coverage_code == premiums.coverage_code && pt.status == 1 && pt.show_front == 1
                                           select new
                                           {
                                               lastupdate = pt.lastupdate,
                                               cover_txt1 = pt.pb_cover_txt1,
                                               cover_txt2 = pt.pb_cover_txt2,
                                               cover_txt3 = pt.pb_cover_txt3,
                                               cover_txt4 = pt.pb_cover_txt4,
                                               cover_txt5 = pt.pb_cover_txt5,
                                               cover_txt6 = pt.pb_cover_txt6,
                                               cover_txt7 = pt.pb_cover_txt7,
                                               cover_txt8 = pt.pb_cover_txt8,
                                               cover_txt9 = pt.pb_cover_txt9,
                                               cover_txt10 = pt.pb_cover_txt10,
                                               cover_txt11 = pt.pb_cover_txt11,
                                               cover_txt12 = pt.pb_cover_txt12,
                                               cover_txt13 = pt.pb_cover_txt13,
                                               cover_txt14 = pt.pb_cover_txt14,
                                               cover_txt15 = pt.pb_cover_txt15,
                                               cover_txt16 = pt.pb_cover_txt16,
                                               cover_txt17 = pt.pb_cover_txt17,
                                               cover_txt18 = pt.pb_cover_txt18,
                                               cover_txt19 = pt.pb_cover_txt19,
                                               cover_txt20 = pt.pb_cover_txt20,
                                               en_cover_txt1 = pt.pb_en_cover_txt1,
                                               en_cover_txt2 = pt.pb_en_cover_txt2,
                                               en_cover_txt3 = pt.pb_en_cover_txt3,
                                               en_cover_txt4 = pt.pb_en_cover_txt4,
                                               en_cover_txt5 = pt.pb_en_cover_txt5,
                                               en_cover_txt6 = pt.pb_en_cover_txt6,
                                               en_cover_txt7 = pt.pb_en_cover_txt7,
                                               en_cover_txt8 = pt.pb_en_cover_txt8,
                                               en_cover_txt9 = pt.pb_en_cover_txt9,
                                               en_cover_txt10 = pt.pb_en_cover_txt10,
                                               en_cover_txt11 = pt.pb_en_cover_txt11,
                                               en_cover_txt12 = pt.pb_en_cover_txt12,
                                               en_cover_txt13 = pt.pb_en_cover_txt13,
                                               en_cover_txt14 = pt.pb_en_cover_txt14,
                                               en_cover_txt15 = pt.pb_en_cover_txt15,
                                               en_cover_txt16 = pt.pb_en_cover_txt16,
                                               en_cover_txt17 = pt.pb_en_cover_txt17,
                                               en_cover_txt18 = pt.pb_en_cover_txt18,
                                               en_cover_txt19 = pt.pb_en_cover_txt19,
                                               en_cover_txt20 = pt.pb_en_cover_txt20,
                                           })
                                     .OrderByDescending(or => or.lastupdate)
                                     .Take(1)
                                     .FirstOrDefaultAsync();

                    #endregion ### cover text ####

                    var commission = reqOrderMotor.PremiumList.Where(x => x.PremiumsId == premiums.id).FirstOrDefault();

                    var orderMotorPremiums = new WebOrderMotorPremiums()
                    {
                        quo_number = reqOrderMotor.QuoteNumber,
                        premiums_id = Convert.ToInt32(premiums.id),
                        company_code = premiums.company_code,

                        TM_PRODUCT_CODE = premiums.TM_PRODUCT_CODE,
                        TM_PRODUCT_DST_GROUP = premiums.TM_PRODUCT_DST_GROUP,
                        TM_PRODUCT_CODE_OIC = premiums.TM_PRODUCT_CODE_OIC,
                        title_masterplan = premiums.title_masterplan,
                        en_title_masterplan = premiums.en_title_masterplan,
                        coverage_code = premiums.coverage_code,

                        group_agent = premiums.group_agent,
                        repair_type = premiums.repair_type,
                        car_brand = premiums.car_brand,
                        car_model = premiums.car_model,
                        car_sub_model = premiums.car_sub_model,
                        car_group = premiums.car_group,
                        car_year = premiums.car_year,
                        car_engine_size = premiums.car_engine_size,
                        sum_insure = premiums.sum_insure,
                        sub_insure = master_plan!.sub_insure,
                        sum_insure_default = premiums.sum_insure_default,
                        driver_flag = premiums.driver_flag,
                        driver_year_of_birth = premiums.driver_year_of_birth,
                        driver_ranges_year_of_birth = premiums.driver_ranges_year_of_birth,
                        accessory_flag = premiums.accessory_flag,
                        accessory_des = premiums.accessory_des,
                        effective_date = premiums.effective_date,
                        expire_date = premiums.expire_date,
                        subclass_sos = premiums.subclass_sos,
                        subclass_gis = premiums.subclass_gis,
                        f_t = premiums.f_t,
                        atm_type = premiums.atm_type,
                        atm_type_txt = premiums.atm_type_txt,
                        active_year = premiums.active_year,
                        active_type = premiums.active_type,
                        s_p = premiums.s_p,
                        od = premiums.od,
                        net_premiums = premiums.net_premiums,
                        stamp = premiums.stamp,
                        tax = premiums.tax,
                        total_premiums = premiums.total_premiums,
                        cmi_net_premiums = premiums.cmi_net_premiums,
                        cmi_stamp = premiums.cmi_stamp,
                        cmi_tax = premiums.cmi_tax,
                        cmi_total_premiums = premiums.cmi_total_premiums,
                        total_premiums_with_cmi = premiums.total_premiums_with_cmi,
                        status = premiums.status,

                        cover_txt1 = (cover_txt != null ? cover_txt.cover_txt1 : ""),
                        cover_txt2 = (cover_txt != null ? cover_txt.cover_txt2 : ""),
                        cover_txt3 = (cover_txt != null ? cover_txt.cover_txt3 : ""),
                        cover_txt4 = (cover_txt != null ? cover_txt.cover_txt4 : ""),
                        cover_txt5 = (cover_txt != null ? cover_txt.cover_txt5 : ""),
                        cover_txt6 = (cover_txt != null ? cover_txt.cover_txt6 : ""),
                        cover_txt7 = (cover_txt != null ? cover_txt.cover_txt7 : ""),
                        cover_txt8 = (cover_txt != null ? cover_txt.cover_txt8 : ""),
                        cover_txt9 = (cover_txt != null ? cover_txt.cover_txt9 : ""),
                        cover_txt10 = (cover_txt != null ? cover_txt.cover_txt10 : ""),
                        cover_txt11 = (cover_txt != null ? cover_txt.cover_txt11 : ""),
                        cover_txt12 = (cover_txt != null ? cover_txt.cover_txt12 : ""),
                        cover_txt13 = (cover_txt != null ? cover_txt.cover_txt13 : ""),
                        cover_txt14 = (cover_txt != null ? cover_txt.cover_txt14 : ""),
                        cover_txt15 = (cover_txt != null ? cover_txt.cover_txt15 : ""),
                        cover_txt16 = (cover_txt != null ? cover_txt.cover_txt16 : ""),
                        cover_txt17 = (cover_txt != null ? cover_txt.cover_txt17 : ""),
                        cover_txt18 = (cover_txt != null ? cover_txt.cover_txt18 : ""),
                        cover_txt19 = (cover_txt != null ? cover_txt.cover_txt19 : ""),
                        cover_txt20 = (cover_txt != null ? cover_txt.cover_txt20 : ""),
                        en_cover_txt1 = (cover_txt != null ? cover_txt.en_cover_txt1 : ""),
                        en_cover_txt2 = (cover_txt != null ? cover_txt.en_cover_txt2 : ""),
                        en_cover_txt3 = (cover_txt != null ? cover_txt.en_cover_txt3 : ""),
                        en_cover_txt4 = (cover_txt != null ? cover_txt.en_cover_txt4 : ""),
                        en_cover_txt5 = (cover_txt != null ? cover_txt.en_cover_txt5 : ""),
                        en_cover_txt6 = (cover_txt != null ? cover_txt.en_cover_txt6 : ""),
                        en_cover_txt7 = (cover_txt != null ? cover_txt.en_cover_txt7 : ""),
                        en_cover_txt8 = (cover_txt != null ? cover_txt.en_cover_txt8 : ""),
                        en_cover_txt9 = (cover_txt != null ? cover_txt.en_cover_txt9 : ""),
                        en_cover_txt10 = (cover_txt != null ? cover_txt.en_cover_txt10 : ""),
                        en_cover_txt11 = (cover_txt != null ? cover_txt.en_cover_txt11 : ""),
                        en_cover_txt12 = (cover_txt != null ? cover_txt.en_cover_txt12 : ""),
                        en_cover_txt13 = (cover_txt != null ? cover_txt.en_cover_txt13 : ""),
                        en_cover_txt14 = (cover_txt != null ? cover_txt.en_cover_txt14 : ""),
                        en_cover_txt15 = (cover_txt != null ? cover_txt.en_cover_txt15 : ""),
                        en_cover_txt16 = (cover_txt != null ? cover_txt.en_cover_txt16 : ""),
                        en_cover_txt17 = (cover_txt != null ? cover_txt.en_cover_txt17 : ""),
                        en_cover_txt18 = (cover_txt != null ? cover_txt.en_cover_txt18 : ""),
                        en_cover_txt19 = (cover_txt != null ? cover_txt.en_cover_txt19 : ""),
                        en_cover_txt20 = (cover_txt != null ? cover_txt.en_cover_txt20 : ""),

                        cover_val1 = (master_plan != null ? master_plan.cover_val1 : ""),
                        cover_val2 = (master_plan != null ? master_plan.cover_val2 : ""),
                        cover_val3 = (master_plan != null ? master_plan.cover_val3 : ""),
                        cover_val4 = (master_plan != null ? master_plan.cover_val4 : ""),
                        cover_val5 = (master_plan != null ? master_plan.cover_val5 : ""),
                        cover_val6 = (master_plan != null ? master_plan.cover_val6 : ""),
                        cover_val7 = (master_plan != null ? master_plan.cover_val7 : ""),
                        cover_val8 = (master_plan != null ? master_plan.cover_val8 : ""),
                        cover_val9 = (master_plan != null ? master_plan.cover_val9 : ""),
                        cover_val10 = (master_plan != null ? master_plan.cover_val10 : ""),
                        cover_val11 = (master_plan != null ? master_plan.cover_val11 : ""),
                        cover_val12 = (master_plan != null ? master_plan.cover_val12 : ""),
                        cover_val13 = (master_plan != null ? master_plan.cover_val13 : ""),
                        cover_val14 = (master_plan != null ? master_plan.cover_val14 : ""),
                        cover_val15 = (master_plan != null ? master_plan.cover_val15 : ""),
                        cover_val16 = (master_plan != null ? master_plan.cover_val16 : ""),
                        cover_val17 = (master_plan != null ? master_plan.cover_val17 : ""),
                        cover_val18 = (master_plan != null ? master_plan.cover_val18 : ""),
                        cover_val19 = (master_plan != null ? master_plan.cover_val19 : ""),
                        cover_val20 = (master_plan != null ? master_plan.cover_val20 : ""),
                        en_cover_val1 = (master_plan != null ? master_plan.en_cover_val1 : ""),
                        en_cover_val2 = (master_plan != null ? master_plan.en_cover_val2 : ""),
                        en_cover_val3 = (master_plan != null ? master_plan.en_cover_val3 : ""),
                        en_cover_val4 = (master_plan != null ? master_plan.en_cover_val4 : ""),
                        en_cover_val5 = (master_plan != null ? master_plan.en_cover_val5 : ""),
                        en_cover_val6 = (master_plan != null ? master_plan.en_cover_val6 : ""),
                        en_cover_val7 = (master_plan != null ? master_plan.en_cover_val7 : ""),
                        en_cover_val8 = (master_plan != null ? master_plan.en_cover_val8 : ""),
                        en_cover_val9 = (master_plan != null ? master_plan.en_cover_val9 : ""),
                        en_cover_val10 = (master_plan != null ? master_plan.en_cover_val10 : ""),
                        en_cover_val11 = (master_plan != null ? master_plan.en_cover_val11 : ""),
                        en_cover_val12 = (master_plan != null ? master_plan.en_cover_val12 : ""),
                        en_cover_val13 = (master_plan != null ? master_plan.en_cover_val13 : ""),
                        en_cover_val14 = (master_plan != null ? master_plan.en_cover_val14 : ""),
                        en_cover_val15 = (master_plan != null ? master_plan.en_cover_val15 : ""),
                        en_cover_val16 = (master_plan != null ? master_plan.en_cover_val16 : ""),
                        en_cover_val17 = (master_plan != null ? master_plan.en_cover_val17 : ""),
                        en_cover_val18 = (master_plan != null ? master_plan.en_cover_val18 : ""),
                        en_cover_val19 = (master_plan != null ? master_plan.en_cover_val19 : ""),
                        en_cover_val20 = (master_plan != null ? master_plan.en_cover_val20 : ""),

                        comm_percent = commission!.Commissions.comm_percent.ToString("0.##"),
                        comm_percent_tax = commission.Commissions.comm_percent_tax.ToString("0.##"),
                        net_comm = commission.Commissions.net_comm.ToString("0.##"),
                        total_comm = commission.Commissions.total_comm.ToString("0.##"),
                        delivery_amount = commission.Commissions.delivery_amount.ToString("0.##"),
                        cmi_comm_percent = commission.Commissions.cmi_comm_percent.ToString("0.##"),
                        cmi_comm_percent_tax = commission.Commissions.cmi_comm_percent_tax.ToString("0.##"),
                        cmi_net_comm = commission.Commissions.cmi_net_comm.ToString("0.##"),
                        cmi_total_comm = commission.Commissions.cmi_total_comm.ToString("0.##"),
                        cmi_delivery_amount = commission.Commissions.cmi_delivery_amount.ToString("0.##"),
                    };

                    string od = Convert.ToDouble(orderMotorPremiums.od?.ToString()).ToString("N0") ?? "-";
                    string f_t = Convert.ToDouble(orderMotorPremiums.f_t?.ToString()).ToString("N0") ?? "-";
                    string s_p = Convert.ToDouble(orderMotorPremiums.s_p?.ToString()).ToString("N0") ?? "-";

                    if (orderMotorPremiums.coverage_code == "2.1" || orderMotorPremiums.coverage_code == "3.1")
                    {
                        for (int index = 1; index <= 20; index++)
                        {
                            string coverTxt = orderMotorPremiums.GetType().GetProperty($"cover_txt{index}")?.GetValue(orderMotorPremiums) as string ?? "";
                            string coverVal = orderMotorPremiums.GetType().GetProperty($"cover_val{index}")?.GetValue(orderMotorPremiums) as string ?? "";
                            string enCoverTxt = orderMotorPremiums.GetType().GetProperty($"en_cover_txt{index}")?.GetValue(orderMotorPremiums) as string ?? "";
                            string enCoverVal = orderMotorPremiums.GetType().GetProperty($"en_cover_val{index}")?.GetValue(orderMotorPremiums) as string ?? "";

                            // ปรับค่าความคุ้มครองตามตารางเบี้ย
                            if (coverTxt.Contains("- รถยนต์สูญหาย") && coverTxt.Contains("ไฟไหม้"))
                            {
                                coverVal = $"{f_t} บาท";
                            }
                            else if (coverTxt.Contains("- ความเสียหายต่อรถยนต์"))
                            {
                                coverVal = $"{od} บาท";
                            }
                            else if (coverTxt.Contains("หมายเหตุ"))
                            {
                                coverVal = string.Concat($"เพิ่มความคุ้มครองน้ำท่วม {s_p} บาท", coverVal);
                            }

                            if (enCoverTxt.Contains("- รถยนต์สูญหาย") && enCoverTxt.Contains("ไฟไหม้"))
                            {
                                enCoverVal = $"{f_t} บาท";
                            }
                            else if (enCoverTxt.Contains("- ความเสียหายต่อรถยนต์"))
                            {
                                enCoverVal = $"{od} บาท";
                            }
                            else if (enCoverTxt.Contains("หมายเหตุ"))
                            {
                                enCoverVal = string.Concat($"เพิ่มความคุ้มครองน้ำท่วม {s_p} บาท", coverVal);
                            }

                            orderMotorPremiums.GetType().GetProperty($"cover_val{index}")?.SetValue(orderMotorPremiums, coverVal);
                            orderMotorPremiums.GetType().GetProperty($"en_cover_val{index}")?.SetValue(orderMotorPremiums, enCoverVal);
                        }
                    }

                    listOrderMotorPremiums.Add(orderMotorPremiums);
                }

                await _webTBrokerDBContext.AddRangeAsync(listOrderMotorPremiums);
                var insertOrderPremiums = _webTBrokerDBContext.SaveChangesAsync();

                if (await insertOrderPremiums == 0)
                {
                    #region ############### Clear Record #############

                    if (true)
                    {
                        var dels = await _webTBrokerDBContext.WebOrderMotors
                            .Where(o => o.quo_number == orderMotor.quo_number)
                            .ToListAsync();

                        if (dels.Count > 0)
                            _webTBrokerDBContext.WebOrderMotors.RemoveRange(dels);

                        var dels2 = await _webTBrokerDBContext.WebOrderMotorPremiums
                            .Where(o => o.quo_number == orderMotor.quo_number)
                            .ToListAsync();

                        if (dels2.Count > 0)
                            _webTBrokerDBContext.WebOrderMotorPremiums.RemoveRange(dels2);

                        await _webTBrokerDBContext.SaveChangesAsync();
                    }

                    #endregion ############### Clear Record #############

                    message.Message = $"บันทึกเลขใบเสนอราคานี้ไม่สำเร็จ";
                    message.Status = false;
                    return message;
                }

                message.Message = $"บันทึกเลขใบเสนอราคานี้สำเร็จ";
                message.Status = true;
                return message;
            }
            catch
            {
                #region ############### Clear Record #############

                if (true)
                {
                    var dels = await _webTBrokerDBContext.WebOrderMotors
                        .Where(o => o.quo_number == reqOrderMotor.QuoteNumber)
                        .ToListAsync();

                    if (dels.Count > 0)
                        _webTBrokerDBContext.WebOrderMotors.RemoveRange(dels);

                    var dels2 = await _webTBrokerDBContext.WebOrderMotorPremiums
                        .Where(o => o.quo_number == reqOrderMotor.QuoteNumber)
                        .ToListAsync();

                    if (dels2.Count > 0)
                        _webTBrokerDBContext.WebOrderMotorPremiums.RemoveRange(dels2);

                    await _webTBrokerDBContext.SaveChangesAsync();
                }

                #endregion ############### Clear Record #############

                var message = new RespAddOrderMotor()
                {
                    QuoteNumber = reqOrderMotor.QuoteNumber,
                    Message = "เกิดข้อผิดพลาด ไม่สามารถบันทึกเลขใบเสนอราคานี้อได้",
                    Status = false,
                };
                return message;
            }
        }

        public async Task<RespReward> GetRewardPoint(ReqUser reqUser)
        {
            try
            {
                var agent = await _webTBrokerDBContext.WebDataRewardPoints.AsNoTracking()
                    .Where(x => x.AgentCode!.Equals(reqUser.userid)).FirstOrDefaultAsync();

                if (agent == null)
                {
                    return new RespReward()
                    {
                        UserId = reqUser.userid,
                        Point = 0,
                        PointFocus = 0,
                        PointPlus = 0,
                        PointMonthly = 0,
                        PointTotal = 0,
                        CmsRewardPoint = [],
                        CmsRewardPromotion = []
                    };
                }

                var point = await _webTBrokerDBContext.WebCmsRewardPoints
                    .Where(x => x.Status == "Y" && x.DateEnd >= DateTime.Now)
                    .ToListAsync();

                var promotion = await _webTBrokerDBContext.WebCmsRewardPromotions
                    .Where(x => x.Status == "Y" && x.DateEnd >= DateTime.Now)
                    .ToListAsync();

                var respReward = new RespReward()
                {
                    UserId = agent.AgentCode,
                    Point = agent.Point,
                    PointFocus = agent.PointFocus,
                    PointPlus = agent.PointPlus,
                    PointMonthly = agent.PointMonthly,
                    PointTotal = agent.Point + agent.PointFocus + agent.PointPlus + agent.PointMonthly,
                    CmsRewardPoint = point.Count != 0 ? [..point.Select(x => new RespCmsRewardPoint() {
                    Header = x.Header,
                    Point = x.Point,
                    FilePathImage = $"{_configuration["AppSetting:BaseURL2"]}" + x.FilePathImage,
                    DateEnd = x.DateEnd!.Value,
                    DateStart = x.DateStart!.Value })] : [],
                    CmsRewardPromotion = promotion.Count != 0 ? [.. promotion.Select(x => new RespCmsRewardPromotion() {
                    FilePathImage = $"{_configuration["AppSetting:BaseURL2"]}" + x.FilePathImage,
                    PromotionName = x.PromotionName })] : []
                };

                return respReward;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Select table web_data_reward_point : {ex.Message}");
                return new RespReward();
            }
        }

        public async Task<RespSubInsure> GetSubInsurance(ReqFilterCoverage request)
        {
            var result = await _webTBrokerDBContext.WebPremiumsMotors
                .Where(w => w.status == "A"
                    && w.car_brand!.ToUpper().Trim() == request.car_brand!.ToUpper().Trim()
                    && w.car_model!.ToUpper().Trim() == request.car_model!.ToUpper().Trim()
                    && w.car_engine_size!.ToUpper().Trim() == request.car_engine_size!.ToUpper().Trim()
                    && w.car_year!.Trim() == request.car_year!.Trim()
                    && w.coverage_code != "T"
                    && w.coverage_code == request.coverage_code
                ).Select(s => new
                {
                    sum_insure = string.IsNullOrEmpty(s.sum_insure) ? 0 : Convert.ToInt32(s.sum_insure),
                    od = string.IsNullOrEmpty(s.od) ? 0 : Convert.ToInt32(s.od),
                    f_t = string.IsNullOrEmpty(s.f_t) ? 0 : Convert.ToInt32(s.f_t),
                    s_p = string.IsNullOrEmpty(s.s_p) ? 0 : Convert.ToInt32(s.s_p)
                }).ToListAsync();

            if (request.coverage_code == "1" || request.coverage_code == "2" || request.coverage_code == "3")
            {
                return new RespSubInsure
                {
                    sum_insure = result.Select(s => s.sum_insure).OrderBy(o => o).Distinct().ToArray()
                };
            }
            else
            {
                if (request.od != 0)
                {
                    result = result.Where(w => w.od == request.od).ToList();
                }

                if (request.f_t != 0)
                {
                    result = result.Where(w => w.f_t == request.f_t).ToList();
                }

                if (request.s_p != 0)
                {
                    result = result.Where(w => w.s_p == request.s_p).ToList();
                }

                var response = new RespSubInsure
                {
                    sum_insure = [],
                    od = result.Select(s => s.od).OrderBy(o => o).Distinct().ToArray(),
                    f_t = result.Select(s => s.f_t).OrderBy(o => o).Distinct().ToArray(),
                    s_p = result.Select(s => s.s_p).OrderBy(o => o).Distinct().ToArray()
                };
                return response;
            }
        }
    }
}