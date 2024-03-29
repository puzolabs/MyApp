﻿using System.Collections.Generic;
using System.Linq;

namespace MyApp.Data
{
    public class DbSettings : Dictionary<string, string>
    {
        public const string SettingsKeyName = "DB_SETTINGS";

        public string ToConnectionString() => string.Join(";", this.Select(kpv => $"{kpv.Key}={kpv.Value}")) + ";";
    }
}
