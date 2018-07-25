
namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;


    public class FlotaViewModel : BaseViewModel
    {
        
        #region Commands 
        public ICommand SiguienteCommand
        {
            get
            {
                return new RelayCommand(ConfCommand);
            }
        }
        #endregion


        #region Metodos

        private async void ConfCommand()
        {
            MainViewModel.GetInstance().huellaProto = new huellaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ListFlota());
            await Application.Current.MainPage.DisplayAlert(
                    "Información"
                  , "Ingrese el número de días a la semana que labora cada tipo de vehículo."
                  , "Aceptar");
        }

        #endregion

    }

}
