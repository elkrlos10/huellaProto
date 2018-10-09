

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
        //private ObservableCollection<Currency> prueba;
        //private string cantidad;
        //private string combustible;

        private int cantidadTotal;
        private int cantidadGasolina;
        private float km_Gasolina;
        private int cantidadDiesel;
        private float km_Diesel;
        private int cantidadGas;
        private float km_Gas;

        #endregion

        #region Propiedades
        public int CantidadTotal
        {
            get { return this.cantidadTotal; }
            set { SetValue(ref this.cantidadTotal, value); }
        }
        public int CantidadGasolina
        {
            get { return this.cantidadGasolina; }
            set { SetValue(ref this.cantidadGasolina, value); }
        }
        public float Km_Gasolina
        {
            get { return this.km_Gasolina; }
            set { SetValue(ref this.km_Gasolina, value); }
        }
        public int CantidadDiesel
        {
            get { return this.cantidadDiesel; }
            set { SetValue(ref this.cantidadDiesel, value); }
        }
        public float Km_Diesel
        {
            get { return this.km_Diesel; }
            set { SetValue(ref this.km_Diesel, value); }
        }
        public int CantidadGas
        {
            get { return this.cantidadGas; }
            set { SetValue(ref this.cantidadGas, value); }
        }
        public float Km_Gas
        {
            get { return this.km_Gas; }
            set { SetValue(ref this.km_Gas, value); }
        }
    
        #endregion

        #region Constructor
        //public ListFlotaViewModel()
        //{
        //    //this.Prueba = Probando();
        //    //this.Cantidad = "Total vehículos " + NumCamiones;

        //}

        #endregion

        //#region Commands 
        //public ICommand CalcularCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(Calcular);
        //    }
        //}
        //#endregion

        #region Metodos

        //public ObservableCollection<Currency> Probando()
        //{
        //    var obj = new List<Currency>();
        //    for (int i = 2; i < 6; i++)
        //    {
        //        var obj1 = new Currency();
        //        obj1.Motor = "Kenworth" + "-201" + i.ToString() + "-Gas" + "-13.6";
        //        obj1.Combustible = "diesel" + i.ToString();
        //        obj1.CC = "400" + i.ToString();
        //        obj.Add(obj1);
        //    }

        //    return new ObservableCollection<Currency>(obj);
        //}

        //private async void Calcular()
        //{
        //    MainViewModel.GetInstance().huellaProto = new huellaViewModel();
        //    await Application.Current.MainPage.Navigation.PushAsync(new CalcularInsti());
        //}

        #endregion


    }

    public class Currency
    {

        public string Motor { get; set; }

        public string Combustible { get; set; }

        public string CC { get; set; }
    }
}
