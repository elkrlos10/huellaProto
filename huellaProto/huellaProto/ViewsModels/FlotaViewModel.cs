
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


    public class FlotaViewModel : BaseViewModel
    {

        #region Service
        private ApiService apiService;
        #endregion

        #region atributos

        private int cantidadVehiculo;

        private bool isVisibleForm;
        private bool isVisiblePreg;
        private int cantidadTotal;
        private int cantidadGasolina;
        private float km_Gasolina;
        private int cantidadDiesel;
        private float km_Diesel;
        private int cantidadGas;
        private float km_Gas;

        #endregion

        #region Propiedades

        public bool IsVisibleForm
        {
            get { return this.isVisibleForm; }
            set { SetValue(ref this.isVisibleForm, value); }
        }
        public bool IsVisiblePreg
        {
            get { return this.isVisiblePreg; }
            set { SetValue(ref this.isVisiblePreg, value); }
        }

        public int CantidadTotal
        {
            get { return this.cantidadTotal; }
            set { SetValue(ref this.cantidadTotal, value); }
        }
        public int CantidadGasolina
        {
            get { return this.cantidadGasolina; }
            set { SetValue(ref this.cantidadGasolina, value); }
        }
        public float Km_Gasolina
        {
            get { return this.km_Gasolina; }
            set { SetValue(ref this.km_Gasolina, value); }
        }
        public int CantidadDiesel
        {
            get { return this.cantidadDiesel; }
            set { SetValue(ref this.cantidadDiesel, value); }
        }
        public float Km_Diesel
        {
            get { return this.km_Diesel; }
            set { SetValue(ref this.km_Diesel, value); }
        }
        public int CantidadGas
        {
            get { return this.cantidadGas; }
            set { SetValue(ref this.cantidadGas, value); }
        }
        public float Km_Gas
        {
            get { return this.km_Gas; }
            set { SetValue(ref this.km_Gas, value); }
        }

        #endregion

        #region Constructor
        public FlotaViewModel()
        {
            this.IsVisibleForm = false;
            this.IsVisiblePreg = true;
            this.apiService = new ApiService();
        }
        #endregion

        #region Commands 
        public ICommand VehiculosCommand
        {
            get
            {
                return new RelayCommand(Vehiculos);
            }
        }

        public ICommand OmitirCommand
        {
            get
            {
                return new RelayCommand(CambioViewVehiculo);
            }
        }
        #endregion


        #region Metodos

        private void Vehiculos()
        {
            this.IsVisibleForm = true;
            this.IsVisiblePreg = false;
            Application.Current.MainPage.DisplayAlert(
                     "Para tener en cuenta"
                   , "Ingrese el número de vehículos por cada tipo de combustible y el promedio de kilometros que recorren semanalmente"
                   , "Aceptar");

            return;
        }

        private async void CambioViewVehiculo()
        {
            if (!this.IsVisiblePreg)
            {
                this.IsVisibleForm = true;
                this.IsVisiblePreg = false;
            }

            if (this.CantidadGasolina > 0 && this.Km_Gasolina == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor los Km recorridos en la semana por los vahículos a gasolina"
                  , "Aceptar");

                return;
            }
            if (this.CantidadDiesel > 0 && this.Km_Diesel <= 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor los Km recorridos en la semana por los vahículos a diesel"
                  , "Aceptar");

                return;
            }
            if (this.CantidadGas > 0 && this.km_Gas <= 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor los Km recorridos en la semana por los vahículos a gas"
                  , "Aceptar");

                return;
            }

            var idProyecto = MainViewModel.GetInstance().oProyecto.IdProyecto;
            var oVehiculos = new Vehiculos
            {
                Can_Gasolina = this.CantidadGasolina,
                Km_Gasolina = this.Km_Gasolina,
                Can_Diesel = this.CantidadDiesel,
                Km_Diesel = this.km_Diesel,
                Can_GasNatural = this.CantidadGas,
                Km_GasNatural = this.Km_Gas,
                IdProyecto = idProyecto
            };

            try
            {
                var response = await this.apiService._Post(
                                     MainViewModel.GetInstance().UrlServices,
                                      "api/Encuestas",
                                     "/RegristarVehiculos", oVehiculos);

            }
            catch (Exception e)
            {

                throw;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(1));
            //Remover la ultima vista de la pila
            Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);
        }

        #endregion

    }

}
