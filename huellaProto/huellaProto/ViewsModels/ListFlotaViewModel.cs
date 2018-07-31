

namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ListFlotaViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<Currency> prueba;
        private string cantidad;
        private string combustible;

        #endregion

        #region Propiedades
        public string Cantidad
        {
            get { return this.cantidad; }
            set { SetValue(ref this.cantidad, value); }
        }

        public string Combustible
        {
            get { return this.combustible; }
            set { SetValue(ref this.combustible, value); }
        }
        public ObservableCollection<Currency> Prueba
        {
            get { return this.prueba; }
            set { SetValue(ref this.prueba, value); }
        }
        #endregion

        #region Constructor
        public ListFlotaViewModel(string NumCamiones)
        {
            this.Prueba = Probando();
            this.Cantidad = "Total vehículos " + NumCamiones;

        }

        #endregion

        #region Commands 
        public ICommand CalcularCommand
        {
            get
            {
                return new RelayCommand(Calcular);
            }
        }
        #endregion

        #region Metodos

        public ObservableCollection<Currency> Probando()
        {
            var obj = new List<Currency>();
            for (int i = 2; i < 6; i++)
            {
                var obj1 = new Currency();
                obj1.Motor = "Kenworth" + "-201" + i.ToString() + "-Gas" + "-13.6";
                obj1.Combustible = "diesel" + i.ToString();
                obj1.CC = "400" + i.ToString();
                obj.Add(obj1);
            }

            return new ObservableCollection<Currency>(obj);
        }

        private async void Calcular()
        {
            MainViewModel.GetInstance().huellaProto = new huellaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CalcularInsti());
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
