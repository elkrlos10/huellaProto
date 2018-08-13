
namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using System.Windows.Input;
    using Xamarin.Forms;


    public class FlotaViewModel : BaseViewModel
    {
        #region Constructor
        public FlotaViewModel()
        {
           
        }
        #endregion

        #region atributos

        private int cantidadVehiculo;

        #endregion

        #region Propiedades

        public int CantidadVehiculo
        {
            get { return this.cantidadVehiculo; }
            set { SetValue(ref this.cantidadVehiculo, value); }
        }

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

        
        #region Metodos

        private async void ConfCommand()
        {
            var can = this.CantidadVehiculo.ToString();
            MainViewModel.GetInstance().ListaFlota = new ListFlotaViewModel(can);
            await Application.Current.MainPage.Navigation.PushAsync(new ListFlota());
            await Application.Current.MainPage.DisplayAlert(
                    "Información"
                  , "Ingrese el número de días a la semana que labora cada tipo de vehículo."
                  , "Aceptar");
        }

        #endregion

    }

}
