
namespace huellaProto.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Models.DTO;
    using huellaProto.Service;
    using huellaProto.Views;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class RecordarViewModel : BaseViewModel
    {
        //Evento de la interfaz INotifyPropertyChanged para refrescar las vistas
        #region Eventos
        //kpublic event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Atributos
       
        private bool isRunning;
        private bool isEnabled;
        
        private string email;

        #endregion

        #region Service
        private ApiService apiService;
        #endregion

        #region Propiedades

        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public bool IsRemembered { get; set; }
        //Por medio de los atributos se deben actualizar las propiedades en tiempo de ejecucíon en la aplicación
       
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
        public RecordarViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;
            this.apiService = new ApiService();
        }
        #endregion

        //Comandos
        #region Commands 
        public ICommand RecordarCommand
        {
            get
            {
                return new RelayCommand(this.Remember);
            }
        }

        private async void Remember()
        {
            
            if (string.IsNullOrEmpty(this.Email))
            {
              await  Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor el Email"
                   , "Aceptar");

                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;
           
            this.Email = string.Empty;
            var oUsuario = new UsuarioDTO
            {
                NombreUsuario = this.Email,
            };

            var response = await this.apiService.Post<UsuarioDTO>(
                                MainViewModel.GetInstance().UrlServices,
                                "api/Usuario",
                               "/RecuperarContraseña", oUsuario);

            var respuesta = (bool)response.Result;

            if (!respuesta)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error!"
                 , "El correo no existe."
                 , "Aceptar");
            }

            MainViewModel.GetInstance().huellaProto = new huellaViewModel();
            await Application.Current.MainPage.DisplayAlert(
                    "Enviado!"
                  , "Su contraseña a sido enviada a su correo"
                  , "Aceptar");
            await Application.Current.MainPage.Navigation.PushAsync(new Login());

        }

        #endregion
    }
}
