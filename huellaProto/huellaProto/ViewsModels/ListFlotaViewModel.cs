

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
        private string motor;
        private string combustible;

        #endregion

        #region Propiedades
        public string Motor
        {
            get { return this.motor; }
            set { SetValue(ref this.motor, value); }
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

        public ListFlotaViewModel()
        {
            this.Prueba = Probando();

        }

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

        #endregion
    }

    public class Currency
    {

        public string Motor { get; set; }

        public string Combustible { get; set; }

        public string CC { get; set; }
    }
}
