﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldControlApi.Configuration
{
    public class Configuration : IConfiguration
    {
        public string BaseUrl { get; set; }
    }
}