
namespace huellaProto.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Views;
    using huellaProto.ViewsModels;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class RegistroViewModel : BaseViewModel
    {
        //Evento de la interfaz INotifyPropertyChanged para refrescar las vistas
        #region Eventos
        //kpublic event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Atributos
      
        private bool isVisibleEmp;
        private bool isVisibleInst;
        #endregion

        #region Propiedades
      
        public bool IsVisibleEmp
        {
            get { return this.isVisibleEmp; }
            set { SetValue(ref isVisibleEmp, value); }

        }
        public bool IsVisibleInst
        {
            get { return this.isVisibleInst; }
            set { SetValue(ref isVisibleInst, value); }

        }
        #endregion

        #region Contructor
        public RegistroViewModel()
        {
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#61edb9");
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
            //MainPage = new NavigationPage(new Login()) { BarBackgroundColor = Color.FromHex("#61edb9"), BarTextColor = Color.White };
        }
        #endregion

        //Comandos
        #region Commands 
        public ICommand InstitucionCommand
        {
            get
            {
                return new RelayCommand(this.Insti);
            }
        }

        public ICommand EmpresaCommand
        {
            get
            {
                return new RelayCommand(this.Empre);
            }
        }

        private void Insti()
        {
           
            this.IsVisibleInst = true;
            this.isVisibleEmp = false;
            MainViewModel.GetInstance().FormRegistrar = new FormRegistrarViewModel(this.IsVisibleInst, this.isVisibleEmp);
            Application.Current.MainPage.Navigation.PushAsync(new FormRegistrar());
        }

        private void Empre()
        {
            this.IsVisibleInst = false;
            this.isVisibleEmp = true;

            MainViewModel.GetInstance().FormRegistrar = new FormRegistrarViewModel(this.IsVisibleInst, this.isVisibleEmp);
            Application.Current.MainPage.Navigation.PushAsync(new FormRegistrar());
            var page = new NavigationPage(new FormRegistrar());
            page.BarBackgroundColor = Color.FromRgb(26, 179, 148);
        }
        #endregion
    }
}
