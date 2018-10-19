using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.ViewsModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using Xamarin.Forms;


    public class MenuItemViewModel : BaseViewModel
    {
        #region Atributos
        private string nombreEmpresa;
        #endregion
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        public string WidthRequest { get; set; }

        //public string NombreEmpresa
        //{
        //    get { return this.nombreEmpresa; }
        //    set { SetValue(ref this.nombreEmpresa, value); }
        //}
        #endregion

        #region Constructor

        //public MenuItemViewModel()
        //{
        //    this.NombreEmpresa = MainViewModel.GetInstance().oProyecto.NombreEmpresa;
        //}
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }



        private void Navigate()
        {
            //App.Master.IsPresented = false;

            if (this.PageName == "Login")
            {
                //Settings.IsRemembered = "false";
                var mainViewModel = MainViewModel.GetInstance();
                //mainViewModel.Token = null;
                //mainViewModel.User = null;
                Application.Current.MainPage = new NavigationPage(new Login());
            }
            //else if (this.PageName == "MyProfilePage")
            //{
            //    MainViewModel.GetInstance().MyProfile = new MyProfileViewModel();
            //    App.Navigator.PushAsync(new MyProfilePage());
            //}
            else if (this.PageName == "Proyectos")
            {
                MainViewModel.GetInstance().Bienvenida = new BienvenidaViewModel();

                //MainPage = new NavigationPage(new Bienvenida());
                Application.Current.MainPage = new NavigationPage(new Bienvenida());
                //await Application.Current.MainPage.Navigation.PushAsync(new Bienvenida());
            }


        }
        #endregion
    }
}
