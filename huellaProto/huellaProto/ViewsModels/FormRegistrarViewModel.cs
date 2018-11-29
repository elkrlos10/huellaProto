namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Helpers;
    using huellaProto.Models;
    using huellaProto.Models.DTO;
    using huellaProto.Service;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.RegularExpressions;
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
            //Validaciones Campos
            #region validaciones_Campos
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
            else
            {
                bool isEmail = Regex.IsMatch(this.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    await Application.Current.MainPage.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
                    return;
                }
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor la Contraseña"
                   , "Aceptar");

                return;
            }
            else
            {
                if (this.Password.Length < 6)
                {
                    await Application.Current.MainPage.DisplayAlert("Advertencia", "La contraseña debe tener al menos 6 caracteres.", "OK");
                    return;
                }
            }

            if (string.IsNullOrEmpty(this.Nit))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor el NIT"
                   , "Aceptar");

                return;
            }
            else
            {
                if (this.Nit.Length < 6)
                {
                    await Application.Current.MainPage.DisplayAlert("Advertencia", "El nit debe tener por lo menos 6 numeros.", "OK");
                    return;
                }
            }

            if (string.IsNullOrEmpty(this.Direc))
            {
                await Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor la dirección"
                   , "Aceptar");

                return;
            }

            #endregion

            var tipoEmpresa = 0;

            if (this.isVisibleIns)
            {
                tipoEmpresa = 1;
            }
            else
            {
                tipoEmpresa = 2;
            }

            var encriptar = SecurityEncode.Encriptar(this.Password);
            var Empresa = new EmpresaDTO
            {
                NombreEmpresa = this.Nombre,
                Email = this.Email,
                Password = encriptar,
                Nit = this.Nit,
                Direccion = this.Direc,
                TipoEmpresa = tipoEmpresa,
                TipoUsuario = 1
            };

            //var connection = await this.apiService.CheckConnection();

            //if (!connection.IsSuccess)
            //{
            //    //Probar conexión a internet
            //    await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");

            //    return;
            //}

            try
            {
                var response = await this.apiService._Post(
                                    MainViewModel.GetInstance().UrlServices,
                                    "api/Usuario",
                                    "/RegistarEmpresa", Empresa);


                if (!(bool)response.Result)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "El correo ya existe", "Aceptar");
                      return;
                }

                this.Nombre = string.Empty;
                this.Email = string.Empty;
                this.Password = string.Empty;
                this.Nit = string.Empty;
                this.Direc = string.Empty;

            }
            catch (Exception e)
            {

                throw;
            }

            //Validar la respuesta del api
            //if (!response.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
            //    return;
            //}
            await Application.Current.MainPage.DisplayAlert("Información", "Registro Exitoso", "Aceptar");
            
            MainViewModel.GetInstance().Login = new LoginViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new Login());


        }
        #endregion
    }
}
