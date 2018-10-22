namespace huellaProto.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Models.DTO;
    using huellaProto.Service;
    using huellaProto.Views;
    using huellaProto.ViewsModels;
    using System;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
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

            this.Email = "a@a.com";
            this.Password = "123456";

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

        #endregion

        #region Metodos
        private async void Login()
        {

            //Validar campos 
            #region Validaciones
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

            #endregion

            var oUsuario = new UsuarioDTO
            {
                NombreUsuario = this.Email,
                Password = this.Password,
            };

            var connection = await this.apiService.CheckConnection();
            this.IsRunning = true;
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                //Probar conexión a internet
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Aceptar");

                return;
            }

            var response = await this.apiService.Post<UsuarioDTO>(
                                  MainViewModel.GetInstance().UrlServices,
                                  "api/Usuario",
                                 "/IniciarSesion", oUsuario);

            //Validar la respuesta del api
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                this.IsRunning = false;
                return;
            }
            if (response.Result == null)
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", "Ingresaste un correo o contraseña incorrecta", "Aceptar");
                return;
            }

            oUsuario = (UsuarioDTO)response.Result;
            MainViewModel.GetInstance().oUsuarioDTO = oUsuario;
            MainViewModel.GetInstance().NombreEmpresa = oUsuario.NombreEmpresa;
            //MainViewModel.GetInstance().User = oUsuario.NombreUsuario;
            //MainViewModel.GetInstance().TipoEmpresa = oUsuario.TipoEmpresa;
            //MainViewModel.GetInstance().IdEmpresa = oUsuario.IdEmpresa;
            //MainViewModel.GetInstance().Bienvenida = new BienvenidaViewModel();
            //await Application.Current.MainPage.Navigation.PushAsync(new Bienvenida());

            if (MainViewModel.GetInstance().oUsuarioDTO.Proyectos)
            {
                MainViewModel.GetInstance().MenuProyectos = new MenuItemViewModel();
                MainViewModel.GetInstance().ListaProyectos = new ListaProyectosViewModel();
                Application.Current.MainPage = new MasterPage();
            }
            else
            {
                MainViewModel.GetInstance().Bienvenida = new BienvenidaViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new Bienvenida());
            }

            this.IsRunning = false;

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