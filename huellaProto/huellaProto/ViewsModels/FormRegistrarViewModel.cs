

namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Models;
    using huellaProto.Service;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class FormRegistrarViewModel : BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region Atributos
        private string password;
        private bool isRunning;
        private bool isEnabled;
        private string nombre;
        private string email;
        private string nit;
        private string direc;
        private bool isVisibleIns;
        private bool isVisibleEmp;

        #endregion

        #region Contructor
        public FormRegistrarViewModel(bool institucion, bool empresa)
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
            this.IsVisibleIns = institucion;
            this.IsVisibleEmp = empresa;
            this.apiService = new ApiService();
        }
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public string Nit
        {
            get { return this.nit; }
            set { SetValue(ref this.nit, value); }
        }
        public string Direc
        {
            get { return this.direc; }
            set { SetValue(ref this.direc, value); }
        }
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public bool IsRemembered { get; set; }
        //Por medio de los atributos se deben actualizar las propiedades en tiempo de ejecucíon en la aplicación
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref isEnabled, value); }

        }

        public bool IsVisibleIns
        {
            get { return this.isVisibleIns; }
            set { SetValue(ref isVisibleIns, value); }

        }
        public bool IsVisibleEmp
        {
            get { return this.isVisibleEmp; }
            set { SetValue(ref isVisibleEmp, value); }

        }

        #endregion

        #region Commands

        public ICommand RegisCommand
        {
            get
            {
                return new RelayCommand(this.Regis);
            }
        }

        private async void Regis()
        {
            if (string.IsNullOrEmpty(this.Nombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor el nombre"
                   , "Aceptar");

                return;
            }
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor el Email"
                   , "Aceptar");

                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor la Contraseña"
                   , "Aceptar");

                return;
            }
            if (string.IsNullOrEmpty(this.Nit))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor el NIT"
                   , "Aceptar");

                return;
            }

            if (string.IsNullOrEmpty(this.Direc))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor la dirección"
                   , "Aceptar");

                return;
            }
            var conexion = $"http://10.3.240.88:8083//api/Area/ConsultarAreas";



            try
            {
                //var conexion = $"http://10.3.240.88:8083//api/Area/ConsultarAreas";

                var response = await this.apiService.Get<Usuario>(
                                      "http://10.3.240.88:8083//",
                                      "api/Area",
                                     "/ConsultarAreas");

                using (var cliente = new HttpClient())
                {
                    //ralizando la petición
                    var peticion = await cliente.GetAsync(conexion);

                    if (peticion != null)
                    {
                        //sacando el json que devuelve la peticion
                        var json = peticion.Content.ReadAsStringAsync().Result;
                        //var json = await peticion.Content.ReadAsStringAsync();


                        var datos = (JContainer)JsonConvert.DeserializeObject(json);

                        if (datos != null)
                        {
                            //var clima = new Clima();
                            //clima.Titulo = (string)datos["name"];
                            //clima.Temperatura = ((float)datos["main"]["temp"] - 273.15).ToString("N2") + " °C";
                            //clima.Viento = (string)datos["wind"]["speed"] + " mph";
                            //clima.Humedad = (string)datos["main"]["humidity"] + " %";
                            //clima.Visibilidad = (string)datos["weather"][0]["main"];

                            //var fechaBase = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                            //var amanecer = fechaBase.AddSeconds((double)datos["sys"]["sunrise"]);
                            //var ocaso = fechaBase.AddSeconds((double)datos["sys"]["sunset"]);
                            //clima.Amanecer = amanecer.ToString() + " UTC";
                            //clima.Ocaso = ocaso.ToString() + " UTC";
                            //return clima;

                        }

                    }
                    //return default(Clima);
                }
            }
            catch (Exception e)
            {

                throw;
            }



            this.IsRunning = false;
            this.IsEnabled = true;

            this.Nombre = string.Empty;
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.Nit = string.Empty;
            this.Direc = string.Empty;

            MainViewModel.GetInstance().Login = new LoginViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new Login());

        }
        #endregion
    }
}
