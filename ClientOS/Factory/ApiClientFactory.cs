﻿using ClientOS.Utility;
using CoreApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientOS.Factory
{
    public class ApiClientFactory
    {
        private static Uri apiUri;

        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(
            () => new ApiClient(apiUri), 
            LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);

        }

        public static ApiClient Instance
        {
            get
            {

                return restClient.Value;

            }

        }


    }
}
