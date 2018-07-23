
namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;


    public class FlotaViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<Currency> prueba;
        //private bool isVisible;
        //private int NumCamiones; 

        #endregion

        #region Propiedades
        public ObservableCollection<Currency> Prueba
        {
            get { return this.prueba; }
            set { SetValue(ref this.prueba, value); }
        }
        #endregion

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
            var obj = new List<Currency>();
            for (int i = 0; i < 3; i++)
            {
                var obj1 = new Currency();
                obj1.Motor = "v10" + i.ToString();
                obj1.Combustible = "diesel" + i.ToString();
                obj1.CC = "400" + i.ToString();
                obj.Add(obj1);
            }

            this.Prueba = new ObservableCollection<Currency>(obj);

            MainViewModel.GetInstance().huellaProto = new huellaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ListFlota());
        }

        #endregion
    }

 

    public class Currency
    {
      
        public string Motor { get; set; }

        public string Combustible { get; set; }
        
        public string CC { get; set; }
    }
}
