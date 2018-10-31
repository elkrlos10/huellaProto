using GalaSoft.MvvmLight.Command;
using huellaProto.Models.DTO;
using huellaProto.Service;
namespace huellaProto.ViewsModels
{
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class CompensarViewModel : BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region atributos
        private double toneladasCo2;
        private string zona;
        private string arbol;
        private bool precisar;
        private double porcentaje;
        private string densidad;
        private double diferencia;
        #endregion

        #region Propiedades

        public double ToneladasCo2
        {
            get { return this.toneladasCo2; }
            set { SetValue(ref this.toneladasCo2, value); }
        }
        public string Zona
        {
            get { return this.zona; }
            set { SetValue(ref this.zona, value); }
        }
        public string Arbol
        {
            get { return this.arbol; }
            set { SetValue(ref this.arbol, value); }
        }
        public bool Precisar
        {
            get { return this.precisar; }
            set { SetValue(ref this.precisar, value); }
        }
        public double Porcentaje
        {
            get { return this.porcentaje; }
            set { SetValue(ref this.porcentaje, value); }
        }
        public string Densidad
        {
            get { return this.densidad; }
            set { SetValue(ref this.densidad, value); }
        }
        public double Diferencia
        {
            get { return this.diferencia; }
            set { SetValue(ref this.diferencia, value); }
        }

        #endregion

        #region Constructor
        public CompensarViewModel()
        {

            this.apiService = new ApiService();
            //if (MainViewModel.GetInstance().TipoEmpresa == 2)
            //{
              
            //}
            this.CalculoHuella();
            this.ToneladasCo2 = MainViewModel.GetInstance().ToneladasCO2;
            Application.Current.MainPage.DisplayAlert(
            "Información",
            "Si deseas compensar la huella de carbono que dejas en el medio ambiente, a continuación encontrarás un programa de siembra de árboles donde podrás seleccionar la zona, el tipo de árbol y el porcentaje a compensar.",
            "Aceptar");


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

        public ICommand CompensarCommand
        {
            get
            {
                return new RelayCommand(GuargarCalculo);
            }
        }


        #endregion

        #region Metodos
        private async void CalculoHuella()
        {
            try
            {
                var parametros = new ParametrosDTO
                {
                    Paramatro1 = MainViewModel.GetInstance().oProyecto.IdProyecto.ToString()
                };


                var response = await this.apiService.Post<ParametrosDTO>(
                                 MainViewModel.GetInstance().UrlServices,
                                 "api/Proyecto",
                                "/CalculoHuellaTransporte", parametros);
                var totalHuella = (ParametrosDTO)response.Result;

                MainViewModel.GetInstance().ToneladasCO2 = Math.Round(double.Parse(totalHuella.Paramatro1) / 1000, 2);
                this.ToneladasCo2 = MainViewModel.GetInstance().ToneladasCO2;


            }
            catch (Exception e)
            {
                throw;
            }

        }

        private async void ConfCommand()
        {
            //MainViewModel.GetInstance().Tabs = new TabsViewModel();
            Application.Current.MainPage = new MasterPage();
            //await Application.Current.MainPage.Navigation.PushAsync(new CompensarPage());
        }

        private async void GuargarCalculo()
        {

            if (this.Porcentaje>100 || this.Porcentaje == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "El porcentaje a compensar deebe estar entre 1% y 100%"
                   , "Aceptar");

                return;
            }
            if (string.IsNullOrEmpty(this.Zona))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Por favor seleccione una zona"
                   , "Aceptar");

                return;
            }
            if (string.IsNullOrEmpty(this.Arbol))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Por favor seleccione un especie de árbol"
                   , "Aceptar");

                return;
            }
            if (string.IsNullOrEmpty(this.Densidad))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Por favor seleccione la densidad de árboles por hectárea"
                   , "Aceptar");

                return;
            }

            var oHuella = new HuellaDTO
            {
                IdProyecto = MainViewModel.GetInstance().oProyecto.IdProyecto,
                Toneledas = this.ToneladasCo2,
                Fecha = DateTime.Now,
                TipoArbol = this.Arbol,
                Zona = this.Zona,
                Precisar = this.Precisar,
                Porcentaje = this.Porcentaje,
                Estado = false,
                Area = EstimacionCompensacion().Item1,
                Cant_arboles = EstimacionCompensacion().Item2,
                DensidadArbolHectarea = DensidadArbolHectarea()
            };

            try
            {
                var response = await this.apiService._Post(
                                      MainViewModel.GetInstance().UrlServices,
                                      "api/Proyecto",
                                     "/Guardarcalculo", oHuella);

                MainViewModel.GetInstance().MenuProyectos = new MenuItemViewModel();
                MainViewModel.GetInstance().ListaProyectos = new ListaProyectosViewModel();
                Application.Current.MainPage = new MasterPage();
            }
            catch (Exception e)
            {
                throw;
            }


            //await Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(2));
        }

        private Tuple<double, double> EstimacionCompensacion()
        {
            var arbol = this.Arbol;
            double Co2Compensar = 0, Area=0, Cant_arboles=0;
            var Den_arbol = new DensidadArbol();

            switch (arbol)
            {
                case "Acacia":

                    Co2Compensar = ((Den_arbol.Acacia * DensidadArbolHectarea())/1000);
                    Area = this.toneladasCo2 / Co2Compensar;
                    Cant_arboles = Area * DensidadArbolHectarea();

                    break;

                case "Ciprés":

                    Co2Compensar = ((Den_arbol.Cipres * DensidadArbolHectarea()) / 1000);
                    Area = this.toneladasCo2 / Co2Compensar;
                    Cant_arboles = Area * DensidadArbolHectarea();

                    break;

                case "Eucalipto":

                    Co2Compensar = ((Den_arbol.Eucalipto * DensidadArbolHectarea()) / 1000);
                    Area = this.toneladasCo2 / Co2Compensar;
                    Cant_arboles = Area * DensidadArbolHectarea();

                    break;

                case "Guayacán":

                    Co2Compensar = ((Den_arbol.Guayacán * DensidadArbolHectarea()) / 1000);
                    Area = this.toneladasCo2 / Co2Compensar;
                    Cant_arboles = Area * DensidadArbolHectarea();

                    break;


                case "Pino":

                    Co2Compensar = (Den_arbol.Pino * DensidadArbolHectarea()) / 1000;
                    Area = this.toneladasCo2 / Co2Compensar;
                    Cant_arboles = Area * Den_arbol.Acacia;

                    break;
            }
         
            return new Tuple<double, double>(Math.Round(Area, 2), Math.Round(Cant_arboles, 2));
        }

        private  double DensidadArbolHectarea()
        {
            var valor = 0;
            switch (this.Densidad)
            {
                case "555  árboles":
                    valor = 555;
                    break;

                case "1111 árboles":
                    valor = 1111;
                    break;


                case "1333 árboles":
                    valor = 1333;
                    break;

                case "1666 árboles":
                    valor = 1666;
                    break;

                case "2500 árboles":
                    valor = 2500;
                    break;
            }

               return valor;
        }
        #endregion

    }

    public class DensidadArbol
    {

        public double Acacia { get; set; }
        public double Cipres { get; set; }
        public double Eucalipto { get; set; }
        public double Guayacán { get; set; }
        public double Pino { get; set; }

        public DensidadArbol()
        {
            this.Acacia = 1585;
            this.Cipres = 2583;
            this.Eucalipto = 2289;
            this.Guayacán = 3375;
            this.Pino = 1350;
        }

    }
}
