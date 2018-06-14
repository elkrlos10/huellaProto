using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.ViewModels
{
    public class MainViewModel
    {
        #region ViewModel

        public LoginViewModel Login { get; set; }
        public huellaViewModel huellaProto { get; set; }
        public RegistroViewModel Registro { get; set; }
        #endregion

        #region Contructores

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
           
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
