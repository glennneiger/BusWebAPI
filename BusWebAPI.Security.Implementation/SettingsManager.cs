﻿using System;
using System.Configuration;

namespace BusWebAPI.Security.Implementation
{
    /// <summary>Handle settings from config</summary>
    internal static class SettingsManager
    {
        public static string AppPrefix
        {
            // randomly generated guid for each project - you can change this to whatever you want
            get => "{4FB5CF79-D289-490E-A744-E1CB2CFA8067}";
        }

        private static int? _ticketDurationMin;
        private static TimeSpan? _ticketDurationTimeSpan;
        public static TimeSpan? TicketDurationTimeSpan
        {
            get
            {
                if (_ticketDurationMin == default)
                {
                    _ticketDurationMin = int.Parse(ConfigurationManager.AppSettings["TicketDurationMin"]);
                    if (_ticketDurationMin.Value != 0)
                        _ticketDurationTimeSpan = TimeSpan.FromMinutes(_ticketDurationMin.Value);
                }
                return _ticketDurationTimeSpan;
            }
        }
    }
}
