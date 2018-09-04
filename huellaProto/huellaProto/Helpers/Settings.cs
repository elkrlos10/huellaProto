namespace huellaProto.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        //private const string SettingsKey = "settings_key";
        const string user = "User";
        const string idProyecto = "0";
        static readonly string SettingsDefaultInt = "0";
        static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string User
        {
            get
            {
                return AppSettings.GetValueOrDefault(user, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(user, value);
            }
        }

        public static string IdProyecto
        {
            get
            {
                return AppSettings.GetValueOrDefault(idProyecto, SettingsDefaultInt);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idProyecto, value);
            }
        }

    }
}
