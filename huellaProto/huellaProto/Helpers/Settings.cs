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
        const string proyectos = "Proyectos";
        const string idEmpresa = "IdEmpresa";
        //const string tipoEmpresa = "0";

        static readonly string userDefault = string.Empty;
        static readonly string tokenDefault = string.Empty;
        static readonly string idEmpresaDefault = "0";
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

        public static string Proyectos
        {
            get
            {
                return AppSettings.GetValueOrDefault(proyectos, tokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(proyectos, value);
            }
        }

        public static string IdEmpresa
        {
            get
            {
                return AppSettings.GetValueOrDefault(idEmpresa, idEmpresaDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idEmpresa, value);
            }
        }

        //public static string TipoEmpresa
        //{
        //    get
        //    {
        //        return AppSettings.GetValueOrDefault(tipoEmpresa, Default);
        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(idProyecto, value);
        //    }
        //}

    }
}
