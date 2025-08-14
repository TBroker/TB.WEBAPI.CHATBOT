using System.ComponentModel;

namespace TB.Chatbot.Domain.Enums
{
    public enum BusinessType
    {
        [Description("นายหน้าทั่วไป")]
        Other = 1,

        [Description("อู่ในเครือธนชาต")]
        Garage = 2,

        [Description("พนักงานในเครือ")]
        Employee = 3,

        [Description("โครงสร้างบริหารทีม (MLM)")]
        MLM = 4,

        [Description("พนักงานสำรวจภัย (Surveyor)")]
        Suveyor = 5,

        [Description("ธนชาต แฟมิลี่ (TFG)")]
        TFG = 6
    }
}