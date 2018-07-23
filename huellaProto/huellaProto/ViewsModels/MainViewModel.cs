

using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.ViewModels
{
    using huellaProto.ViewsModels;

    public class MainViewModel
    {
        #region ViewModel

        public LoginViewModel Login { get; set; }
        public huellaViewModel huellaProto { get; set; }
        public RegistroViewModel Registro { get; set; }
        public CalculoViewModel Calculo { get; set; }
        public RecordarViewModel Recordar { get; set; }
        public FlotaViewModel FlotaC { get; set; }
        #endregion

        #region Contructores

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.Registro = new RegistroViewModel();
            this.Recordar = new RecordarViewModel();
            this.FlotaC = new FlotaViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
