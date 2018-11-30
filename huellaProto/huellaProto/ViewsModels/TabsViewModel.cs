namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using huellaProto.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using huellaProto.Service;
    using System.Threading.Tasks;

    public class TabsViewModel : BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region Atributos
        private int idProyecto;

        private bool isVisibleForm;
        private bool isVisiblePreg;
        private bool isVisibleFormMaquina;
        private bool isVisiblePregMaquina;

        //vista transporte
        private int cantidadTotal;
        private int cantidadGasolina;
        private float km_Gasolina;
        private int cantidadDiesel;
        private float km_Diesel;
        private int cantidadGas;
        private float km_Gas;

        //Vista maquinas
        private int can_Total;
        private int can_Gasolina;
        private double lts_Gasolina;
        private int can_Diesel;
        private double lts_Diesel;
        private int can_GasNatural;
        private double lts_GasNatural;

        //Vista Residuos
        private bool separacionResiduos;
        private bool programaReciclaje;
        private bool compostaje;
        private double can_ResiduosSolidos;
        private double can_RediduosRecicla;

        //Vista Energia
        private double energiaKwh;
        private double gas;
        private bool energiaRenovable;
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
        public bool IsVisibleFormMaquina
        {
            get { return this.isVisibleFormMaquina; }
            set { SetValue(ref this.isVisibleFormMaquina, value); }
        }
        public bool IsVisiblePregMaquina
        {
            get { return this.isVisiblePregMaquina; }
            set { SetValue(ref this.isVisiblePregMaquina, value); }
        }

        //Vista transporte
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

        //Vista maquinas
        public int Can_Total
        {
            get { return this.can_Total; }
            set { SetValue(ref this.can_Total, value); }
        }
        public int Can_Gasolina
        {
            get { return this.can_Gasolina; }
            set { SetValue(ref this.can_Gasolina, value); }
        }
        public double Lts_Gasolina
        {
            get { return this.lts_Gasolina; }
            set { SetValue(ref this.lts_Gasolina, value); }
        }
        public int Can_Diesel
        {
            get { return this.can_Diesel; }
            set { SetValue(ref this.can_Diesel, value); }
        }
        public double Lts_Diesel
        {
            get { return this.lts_Diesel; }
            set { SetValue(ref this.lts_Diesel, value); }
        }
        public int Can_GasNatural
        {
            get { return this.can_GasNatural; }
            set { SetValue(ref this.can_GasNatural, value); }
        }
        public double Lts_GasNatural
        {
            get { return this.lts_GasNatural; }
            set { SetValue(ref this.lts_GasNatural, value); }
        }

        //Vista Residuos
        public bool SeparacionResiduos
        {
            get { return this.separacionResiduos; }
            set { SetValue(ref this.separacionResiduos, value); }
        }
        public bool ProgramaReciclaje
        {
            get { return this.programaReciclaje; }
            set { SetValue(ref this.programaReciclaje, value); }
        }
        public bool Compostaje
        {
            get { return this.compostaje; }
            set { SetValue(ref this.compostaje, value); }
        }
        public double Can_ResiduosSolidos
        {
            get { return this.can_ResiduosSolidos; }
            set { SetValue(ref this.can_ResiduosSolidos, value); }
        }
        public double Can_RediduosRecicla
        {
            get { return this.can_RediduosRecicla; }
            set { SetValue(ref this.can_RediduosRecicla, value); }
        }

        //Vista Energia
        public double EnergiaKwh
        {
            get { return this.energiaKwh; }
            set { SetValue(ref this.energiaKwh, value); }
        }
        public double Gas
        {
            get { return this.gas; }
            set { SetValue(ref this.gas, value); }
        }
        public bool EnergiaRenovable
        {
            get { return this.energiaRenovable; }
            set { SetValue(ref this.energiaRenovable, value); }
        }
        #endregion

        #region Constructor
        public TabsViewModel()
        {
            this.IsVisibleForm = false;
            this.IsVisiblePreg = true;
            this.IsVisibleFormMaquina = false;
            this.IsVisiblePregMaquina = true;
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

        public ICommand MaquinasCommand
        {
            get
            {
                return new RelayCommand(Maquinas);
            }
        }

        public ICommand OmitirMaquinaCommand
        {
            get
            {
                return new RelayCommand(CambioViewMaquina);
            }
        }


        public ICommand ResiduosCommand
        {
            get
            {
                return new RelayCommand(CambioViewResiduos);
            }
        }

        public ICommand CalcularCommand
        {
            get
            {
                return new RelayCommand(Calcular);
            }
        }
        #endregion

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

            if (this.CantidadGasolina < 0 || this.Km_Gasolina < 0 || this.CantidadDiesel < 0 || this.Km_Diesel < 0 || this.CantidadGas < 0 || this.km_Gas < 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Algunos datos tienen valores negativos"
                  , "Aceptar");

                return;
            }

            if (this.CantidadGasolina > 0 && this.Km_Gasolina==0)
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

            if (this.CantidadGasolina == 0 && this.Km_Gasolina > 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor la cantidad de vahículos a gasolina"
                  , "Aceptar");

                return;
            }
            if (this.CantidadDiesel == 0 && this.Km_Diesel > 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor la cantidad de vahículos a diesel"
                  , "Aceptar");

                return;
            }
            if (this.CantidadGas == 0 && this.km_Gas > 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor la cantidad de vahículos a gas"
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

        private void Maquinas()
        {
            this.IsVisibleFormMaquina = true;
            this.IsVisiblePregMaquina = false;

        }

        private async void CambioViewMaquina()
        {

            if (this.Can_Gasolina < 0 || this.Lts_Gasolina < 0 || this.Can_Diesel < 0 || this.lts_Diesel < 0 || this.Can_GasNatural < 0 || this.Lts_GasNatural < 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Algunos datos tienen valores negativos"
                  , "Aceptar");

                return;
            }
            if (this.Can_Gasolina > 0 && this.Lts_Gasolina <= 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor los galones utilizados en la semana por las máquinas a gasolina"
                  , "Aceptar");

                return;
            }
            if (this.Can_Diesel > 0 && this.lts_Diesel <= 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor los galones utilizados en la semana por las máquinas a diesel"
                  , "Aceptar");

                return;
            }
            if (this.Can_GasNatural > 0 && this.Lts_GasNatural <= 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor los galones utilizados en la semana por las máquinas a gas"
                  , "Aceptar");

                return;
            }

            if (this.Can_Gasolina == 0 && this.Lts_Gasolina > 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor la canridad de máquinas a gasolina"
                  , "Aceptar");

                return;
            }
            if (this.Can_Diesel == 0 && this.lts_Diesel > 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor la cantidad de máquinas a diesel"
                  , "Aceptar");

                return;
            }
            if (this.Can_GasNatural == 0 && this.Lts_GasNatural > 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Ingrese por favor la cantidad de máquinas a gas"
                  , "Aceptar");

                return;
            }

            var Litros_G = this.Lts_Gasolina * 3.78;
            var Litros_D = this.Lts_Diesel * 3.78;

            var oMaquinas = new Maquina
            {
                Can_Gasolina = this.Can_Gasolina,
                Lts_Gasolina = Math.Round(Litros_G, 2),
                Can_Diesel = this.Can_Diesel,
                Lts_Diesel = Math.Round(Litros_D, 2),
                Can_GasNatural = this.Can_GasNatural,
                Lts_GasNatural = this.Lts_GasNatural,
                IdProyecto = MainViewModel.GetInstance().oProyecto.IdProyecto
            };

            try
            {
                var response = await this.apiService._Post(
                                      MainViewModel.GetInstance().UrlServices,
                                      "api/Encuestas",
                                     "/RegristarMaquinas", oMaquinas);
            }
            catch (Exception e)
            {
                throw;
            }


            await Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(2));
            //Remover la ultima vista de la pila
            Application.Current.MainPage.Navigation.RemovePage
                       (Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);

        }

        private async void CambioViewResiduos()
        {
            if (this.Can_RediduosRecicla < 0 || this.Can_ResiduosSolidos < 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Algunos datos tienen valores negativos"
                  , "Aceptar");

                return;
            }

            var oResiduos = new Residuos
            {
                SeparacionResiduos = this.SeparacionResiduos,
                ProgramaReciclaje = this.ProgramaReciclaje,
                Compostaje = this.Compostaje,
                Can_RediduosRecicla = this.Can_RediduosRecicla,
                Can_ResiduosSolidos = this.Can_ResiduosSolidos,
                IdProyecto = MainViewModel.GetInstance().oProyecto.IdProyecto
            };

            try
            {
                var response = await this.apiService.Post<Residuos>(
                                      MainViewModel.GetInstance().UrlServices,
                                      "api/Encuestas",
                                     "/RegristarResiduos", oResiduos);
            }
            catch (Exception e)
            {

                throw;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(3));
            //Remover la ultima vista de la pila
            Application.Current.MainPage.Navigation.RemovePage
                       (Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);

        }

        private async void Calcular()
        {
            if (this.EnergiaKwh < 0 || this.Gas < 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                  , "Algunos datos tienen valores negativos"
                  , "Aceptar");

                return;
            }

            var oEnergia = new EnergiaM
            {
                EnergiaKwh = this.EnergiaKwh,
                Gas = this.Gas,
                EnergiaRenovable = this.EnergiaRenovable,
                IdProyecto = MainViewModel.GetInstance().oProyecto.IdProyecto
            };

            try
            {
                var response = await this.apiService._Post(
                                     MainViewModel.GetInstance().UrlServices,
                                      "api/Encuestas",
                                     "/RegristarEnergia", oEnergia);
            }
            catch (Exception e)
            {

                throw;
            }

            MainViewModel.GetInstance().Calculo = new CalculoViewModel();
            //MainPage = new MasterPage();
             //Application.Current.MainPage = new MasterPage();
            await Application.Current.MainPage.Navigation.PushAsync(new CalcularInsti());
        }

        
    }
}
