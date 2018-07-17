
namespace huellaProto.ViewModels
{
    using GalaSoft.MvvmLight.Command;
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



        private void Remember()
        {
            
            if (string.IsNullOrEmpty(this.Email))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor el Email"
                   , "Aceptar");

                return;
            }

          

            this.IsRunning = false;
            this.IsEnabled = true;

           
            this.Email = string.Empty;

           
            MainViewModel.GetInstance().huellaProto = new huellaViewModel();
            Application.Current.MainPage.DisplayAlert(
                    "Enviado!"
                  , "Su contraseña a sido enviada a su correo"
                  , "Aceptar");
            Application.Current.MainPage.Navigation.PushAsync(new Login());

        }



        #endregion
    }
}
