using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace MoreCantrips
{
    internal static class Logging
    {
        private const string BaseChannel = "MoreCantrips";

        private static readonly Dictionary<string, Logger> Loggers = new();
        private static bool VerboseLogging = false;

        internal static Logger GetLogger(string channel)
        {
            if (Loggers.ContainsKey(channel))
            {
                return Loggers[channel];
            }
            var logger = new Logger($"{BaseChannel}+{channel}");
            Loggers[channel] = logger;
            return logger;
        }

        internal static void EnableVerboseLogging(bool enabled)
        {
            VerboseLogging = enabled;
            BlueprintCore.Utils.LogWrapper.EnableInternalVerboseLogs(enabled);
        }

        internal class Logger
        {
            private readonly ModLogger InternalLog;

            internal Logger(string name)
            {
                InternalLog = new(name);
            }

            internal void Log(string str)
            {
                InternalLog.Log(str);
            }

            internal void Warning(string str)
            {
                InternalLog.Warning(str);
            }

            internal void LogException(string key, Exception e)
            {
                InternalLog.LogException(key, e);
            }

            internal void Verbose(string str)
            {
                if (VerboseLogging)
                    InternalLog.NativeLog(str);
            }
        }
    }
}
