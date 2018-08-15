namespace huellaProto.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Views;
    using huellaProto.ViewsModels;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        //Evento de la interfaz INotifyPropertyChanged para refrescar las vistas
        #region Eventos
       
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

            this.Email = "a@a.co";
            this.Password = "123";

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

            if (this.Email != "a@a.com" || this.Password != "123")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                //await Application.Current.MainPage.DisplayAlert(
                //      "Error"
                //    , "Email o Contraseña Incorrectas"
                //    , "Aceptar");
                //this.Password = string.Empty;
                //return;
                MainViewModel.GetInstance().Bienvenida = new BienvenidaViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new Bienvenida());
            }
            else
            {
                MainViewModel.GetInstance().FlotaC = new FlotaViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new Flota());
            }
            this.IsRunning = false;
            this.IsEnabled = true;

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