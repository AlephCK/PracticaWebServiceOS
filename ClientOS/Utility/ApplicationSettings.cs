﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientOS.Utility
{
    public class ApplicationSettings
    {
        public static string WebApiUrl { get; set; }

        public ApplicationSettings()
        {
            WebApiUrl = "http://localhost:6846/api/";

        }


    }
}