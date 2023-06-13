using System;
using System.Collections.Generic;

namespace TCCPOS.Backend.InventoryService.Entities
{
    /// <summary>
    /// ตารางไว้เก็บคำอธิบาย status ของ delivery
    /// </summary>
    public partial class deliverystatus
    {
        public sbyte? delivery_status_id { get; set; }
        public string? status_description { get; set; }
    }
}
