using GalaSoft.MvvmLight.Command;
using huellaProto.Helpers;
using huellaProto.Models.DTO;
using huellaProto.Service;
using huellaProto.ViewModels;
using huellaProto.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace huellaProto.ViewsModels
{
    public class CuentaRegresivaViewModel : BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region Atributos
        private string fechaFinal;
        private string link;
        private bool visibleInicio;
        private bool visibleFIn;
        private double toneladasCo2;
        #endregion

        #region Propiedades
        public string FechaFinal
        {
            get { return this.fechaFinal; }
            set { SetValue(ref this.fechaFinal, value); }
        }

        public string Link
        {
            get { return this.link; }
            set { SetValue(ref this.link, value); }
        }

        public bool VisibleInicio
        {
            get { return this.visibleInicio; }
            set { SetValue(ref this.visibleInicio, value); }
        }

        public bool VisibleFIn
        {
            get { return this.visibleFIn; }
            set { SetValue(ref this.visibleFIn, value); }
        }
        public double ToneladasCo2
        {
            get { return this.toneladasCo2; }
            set { SetValue(ref this.toneladasCo2, value); }
        }

        #endregion

        #region Constructor
        public CuentaRegresivaViewModel()
        {
            this.apiService = new ApiService();
            this.VisibleInicio = true;
            this.VisibleFIn = false;
            this.Precisar();
        }
        #endregion

        #region Commands

        public ICommand AbrirUrlCommand
        {
            get
            {
                return new RelayCommand(AbrirUrl);
            }
        }

        public ICommand CompensarCommand
        {
            get
            {
                return new RelayCommand(Compensar);
            }
        }

        public ICommand CorreoCommand
        {
            get
            {
                return new RelayCommand(CompartirLink);
            }
        }

        
        #endregion

        #region Metodos
        private async void Precisar()
        {
            var Fecha = MainViewModel.GetInstance().oProyecto.FechaProyecto.AddDays(15);
            if (Fecha < DateTime.Now)
            {
                this.VisibleInicio = false;
                this.VisibleFIn = true;
                try
                {
                    var parametros = new ParametrosDTO
                    {
                        Paramatro1 = MainViewModel.GetInstance().oProyecto.IdProyecto.ToString()
                    };

                    var response = await this.apiService.Post<ParametrosDTO>(
                                     MainViewModel.GetInstance().UrlServices,
                                     "api/Proyecto",
                                    "/PrecisarCalculoHuella", parametros);
                    var totalHuella = (ParametrosDTO)response.Result;

                    MainViewModel.GetInstance().ToneladasCO2 = Math.Round(double.Parse(totalHuella.Paramatro1) / 1000, 2);
                    this.ToneladasCo2 = MainViewModel.GetInstance().ToneladasCO2;
                }
                catch (Exception e)
                {
                    throw;
                }

                return;
            }

            var horas = (DateTime.Now - Fecha).ToString(@"dd\-\ hh\-\ mm\m\ ");
            string[] split = horas.Split(new Char[] { '-', 'm' });

            string Cadena = "";

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Cadena = split[i] + " días";
                }
                if (i == 1)
                {
                    Cadena = Cadena + " " + split[i] + " horas";
                }
            }
            //this.FechaFinal = horas.ToString();
            this.FechaFinal = Cadena;
            this.Link = "Click aquí";

        }

        private void AbrirUrl()
        {
            var IdProyecto = MainViewModel.GetInstance().oProyecto.IdProyecto;
            //Device.OpenUri(new Uri("http://huellacarbonoweb20180918120510.azurewebsites.net/#!/Encuesta"));
            Device.OpenUri(new Uri("http://10.3.240.88:8089/#!/Encuesta?IdProyecto=" + IdProyecto));
            //Device.OpenUri(new Uri(" https://huellaapi.azurewebsites.net//#!/Encuesta?IdProyecto=" + IdProyecto));
            //Device.OpenUri(new Uri("https://huellacarbono2.azurewebsites.net//#!/Encuesta?IdProyecto=" + IdProyecto));

        }

        private async void Compensar()
        {
            MainViewModel.GetInstance().Compensar = new CompensarViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CompensarPage());
        }

        private async void CompartirLink()
        {
            Device.OpenUri(new Uri("mailto:ryan.hatfield@test.com"));
        }


        #endregion

    }
}
