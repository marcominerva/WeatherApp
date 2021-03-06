﻿using Microsoft.Extensions.Logging;

namespace WeatherApp.Mobile.Logging
{
    [ProviderAlias("AppCenter")]
    public class AppCenterLoggerProvider : ILoggerProvider
    {
        // Create an instance of an ILogger, which is used to actually write the logs
        public ILogger CreateLogger(string categoryName)
        {
            return new AppCenterLogger(this, categoryName);
        }

        public void Dispose()
        {
        }
    }
}