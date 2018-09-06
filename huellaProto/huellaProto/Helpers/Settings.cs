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
        const string tipoEmpresa = "0";

        static readonly string userDefault = string.Empty;
        static readonly string idProyectoDefaultInt = "0";
        static readonly string Default = "0";
        #endregion


        public static string User
        {
            get
            {
                return AppSettings.GetValueOrDefault(user, userDefault);
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
                return AppSettings.GetValueOrDefault(idProyecto, idProyectoDefaultInt);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idProyecto, value);
            }
        }


        public static string TipoEmpresa
        {
            get
            {
                return AppSettings.GetValueOrDefault(tipoEmpresa, Default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idProyecto, value);
            }
        }

    }
}
