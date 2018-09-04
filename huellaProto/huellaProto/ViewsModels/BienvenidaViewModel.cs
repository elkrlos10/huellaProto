
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
                //var proyecto = new Proyecto();

                //proyecto.IdEmpresa = 1;
                //proyecto.FechaProyecto = DateTime.Now;

                //var response = await this.apiService.Post<Proyecto>(
                //                      "http://apihuella.azurewebsites.net/",
                //                      "api/Usuario",
                //                     "/CrearProyecto", proyecto);
            }
            catch (Exception e)
            {
                throw;
            }

            MainViewModel.GetInstance().Tabs = new TabsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(4));

        }

        #endregion
    }
}
