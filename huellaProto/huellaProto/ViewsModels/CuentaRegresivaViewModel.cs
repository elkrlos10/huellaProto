using huellaProto.Helpers;
using huellaProto.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace huellaProto.ViewsModels
{
    public class CuentaRegresivaViewModel : BaseViewModel
    {
        #region atributos
        static Countdown countdown;
        //private Countdown countdown;
        #endregion

        #region atributos
        private string contador;
        #endregion

        #region Propiedades

        public string Contador
        {
            get { return this.contador; }
            set { SetValue(ref this.contador, value); }
        }


        #endregion

        public CuentaRegresivaViewModel()
        {
            CountdownConverter oCountdownConverter = new CountdownConverter();
            countdown = new Countdown();
            countdown.StartUpdating(3600 * 24);

            this.Contador = oCountdownConverter.Convert1(countdown).ToString();

        }



    }
}
