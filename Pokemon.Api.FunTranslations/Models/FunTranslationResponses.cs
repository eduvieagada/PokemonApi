﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Api.FunTranslations.Models
{
    class ApiResponse
    {
        public Success success { get; set; }
        public Contents contents { get; set; }
    }

    class Success
    {
        public int total { get; set; }
    }

    class Contents
    {
        public string translated { get; set; }
        public string text { get; set; }
        public string translation { get; set; }
    }
}
