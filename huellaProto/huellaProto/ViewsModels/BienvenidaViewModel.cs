
namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Models;
    using huellaProto.Service;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class BienvenidaViewModel: BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region Commands 
        public ICommand SiguienteCommand
        {
            get
            {
                return new RelayCommand(ConfCommand);
            }
        }
        #endregion

        #region Constructor
        public BienvenidaViewModel()
        {
            this.apiService = new ApiService();
        }
        #endregion

        #region Metodos

        private async void ConfCommand()
        {

            try
            {

                var proyecto = new Proyecto();

                proyecto.IdEmpresa = MainViewModel.GetInstance().IdEmpresa;
                proyecto.FechaProyecto = DateTime.Now;
                proyecto.Etapa = 1;
                
                var response = await this.apiService.Post<Proyecto>(
                                      MainViewModel.GetInstance().UrlServices,
                                      "api/Usuario",
                                     "/CrearProyecto", proyecto);
               var proyect = (Proyecto)response.Result;

                MainViewModel.GetInstance().oProyecto = proyect;
                MainViewModel.GetInstance().oProyecto.FechaProyecto= DateTime.Parse("2018-09-16");
            }
            catch (Exception e)
            {
                throw;
            }

            if (MainViewModel.GetInstance().TipoEmpresa == 1)
            {
                MainViewModel.GetInstance().Tabs = new TabsViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(4));

            }
            else
            {
                MainViewModel.GetInstance().FlotaC = new FlotaViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new Flota());

            }


        }

        #endregion
    }
}
