﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetsanGida.Ui.Models
{
    public class ReturnValue
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
}