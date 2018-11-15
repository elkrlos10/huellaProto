using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.ViewsModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Helpers;
    using huellaProto.Models.DTO;
    using huellaProto.Service;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using Xamarin.Forms;


    public class MenuItemViewModel : BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

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

        public MenuItemViewModel()
        {
            this.apiService = new ApiService();
        }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        private async void Navigate()
        {
            //App.Master.IsPresented = false;

            if (this.PageName == "Login")
            {
                //Settings.IsRemembered = "false";
                var mainViewModel = MainViewModel.GetInstance();
                //mainViewModel.Token = null;
                //mainViewModel.User = null;
                Settings.User = string.Empty;
                Settings.Proyectos = string.Empty;
                Application.Current.MainPage = new NavigationPage(new Login());
            }
            //else if (this.PageName == "MyProfilePage")
            //{
            //    MainViewModel.GetInstance().MyProfile = new MyProfileViewModel();
            //    App.Navigator.PushAsync(new MyProfilePage());
            //}
            else if (this.PageName == "Proyectos")
            {
                var pendientes = await ConsultarProyectos();

                if (pendientes != "")
                {
                    await Application.Current.MainPage.DisplayAlert("Información", pendientes, "Aceptar");
                    return;
                }
                MainViewModel.GetInstance().Bienvenida = new BienvenidaViewModel();
                Application.Current.MainPage = new NavigationPage(new Bienvenida());
                //await Application.Current.MainPage.Navigation.PushAsync(new Bienvenida());
            }


        }

        private async Task<string> ConsultarProyectos()
        {
            var IdEmpresa = MainViewModel.GetInstance().oUsuarioDTO.IdEmpresa;

            try
            {
                var response = await this.apiService._GetList<HuellaDTO>(
                                 MainViewModel.GetInstance().UrlServices,
                                 "api/Proyecto",
                                "/ConsultarProyectos", IdEmpresa);

                var ListaHuella = (List<HuellaDTO>)response.Result;

                //Validar la respuesta del api
                if (!response.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");

                    return "";
                }

                var Mensaje = "";
                foreach (var item in ListaHuella)
                {
                  
                    if (item.Estado1 == "Pendiente")
                    {
                        return Mensaje = "Todavia no puedes crear un proyecto nuevo porque aún hay pendientes por aprobación";
                    }
                    if (item.sumaPorcentaje <100)
                    {
                        return Mensaje = "Aún hay proyecto por completar la compensación al 100%";
                    }

                }

                return Mensaje;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        #endregion
    }
}
