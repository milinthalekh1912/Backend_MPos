﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder
{
    public class MessageModel
    {
        public string type { get; set; }
        public string text { get; set; }
    }
}