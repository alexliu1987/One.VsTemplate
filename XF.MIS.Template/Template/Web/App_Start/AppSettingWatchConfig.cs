using System;
using ConfigCenter.Provider;

namespace $safeprojectname$.Web
{
    public static class AppSettingWatchConfig
    {
        private static Watcher _watcher;

        private static readonly Lazy<Watcher> Lazy =
            new Lazy<Watcher>(() =>
              {
                  var sw = new AppSettingWatch();
                  return sw.Build();
              });

        public static void RegisterWatcher()
        {
            if (!Lazy.IsValueCreated)
                _watcher = Lazy.Value;
        }

        public static void DisposeWatcher()
        {
            _watcher?.Dispose();
        }
    }
}