

namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class BienvenidaViewModel: BaseViewModel
    {
        #region Commands 
        public ICommand SiguienteCommand
        {
            get
            {
                return new RelayCommand(ConfCommand);
            }
        }
        #endregion

        #region Metodos

        private async void ConfCommand()
        {
           
            MainViewModel.GetInstance().Tabs = new TabsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(4));

        }

        #endregion
    }
}
