namespace huellaProto.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Models.DTO;
    using huellaProto.Service;
    using huellaProto.Views;
    using huellaProto.ViewsModels;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        //Evento de la interfaz INotifyPropertyChanged para refrescar las vistas
        #region Eventos

        #endregion

        #region Service
        private ApiService apiService;
        #endregion

        #region Atributos
        private string password;
        private bool isRunning;
        private bool isEnabled;
        private string email;
        #endregion

        #region Propiedades

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
        #endregion

        #region Contructor
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;

            this.Email = "Colegio";
            this.Password = "123";

            this.apiService = new ApiService();
        }
        #endregion

        //Comandos
        #region Commands 
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public ICommand RegistroCommand
        {
            get
            {
                return new RelayCommand(Regi);
            }
        }

        public ICommand CalcularCommand
        {
            get
            {
                return new RelayCommand(Calcu);
            }
        }

        public ICommand ForgotPasswordCommand
        {
            get
            {
                return new RelayCommand(Forgot);
            }
        }

        public ICommand RegisCommand
        {
            get
            {
                return new RelayCommand(Regi);
            }
        }


        private async void Login()
        {

            //Validar si es null o vacio la propiedad
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                      "Error"
                    , "Ingrese por favor el Email"
                    , "Aceptar");

                return;
            }

            //this.IsRunning = true;
            //this.IsEnabled = false;

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                      "Error"
                    , "Ingrese por favor la Contraseña"
                    , "Aceptar");

                return;
            }

            var oUsuario = new UsuarioDTO
            {
                NombreUsuario = this.Email,
                Password = this.Password,
            };

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                //Probar conexión a internet
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");
               
                return;
            }

            var response = await this.apiService.Post<UsuarioDTO>(
                                  "http://apihuella.azurewebsites.net//",
                                  "api/Usuario",
                                 "/IniciarSesion", oUsuario);

            //Validar la respuesta del api
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");

                return;
            }
            if (response.Result == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingresaste un correo o contraseña incorrecta", "Aceptar");
                return;
            }

            oUsuario = (UsuarioDTO)response.Result;

            MainViewModel.GetInstance().Bienvenida = new BienvenidaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new Bienvenida());


            this.Email = string.Empty;
            this.Password = string.Empty;

        }

        private async void Regi()
        {

            MainViewModel.GetInstance().Registro = new RegistroViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new registroInsti());

        }

        private async void Calcu()
        {

            MainViewModel.GetInstance().huellaProto = new huellaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CalcularInsti());

        }

        private async void Forgot()
        {

            MainViewModel.GetInstance().Recordar = new RecordarViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ForgotPass());


        }
        #endregion
    }
}