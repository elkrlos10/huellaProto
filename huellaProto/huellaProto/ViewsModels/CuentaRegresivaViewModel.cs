using huellaProto.Helpers;
using huellaProto.Service;
using huellaProto.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace huellaProto.ViewsModels
{
    public class CuentaRegresivaViewModel : BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region Atributos
        private string fechaFinal;
        private string link;
        #endregion

        #region Propiedades
        public string FechaFinal
        {
            get { return this.fechaFinal; }
            set { SetValue(ref this.fechaFinal, value); }
        }

        public string Link
        {
            get { return this.link; }
            set { SetValue(ref this.link, value); }
        }
        #endregion

        #region Constructor
        public CuentaRegresivaViewModel(bool _precisar)
        {
            this.Precisar(_precisar);
        }
        #endregion

        #region Metodos
        private void Precisar(bool _precisar)
        {
            if (_precisar)
            {
                var Fecha = DateTime.Parse("2018-09-17").AddDays(15);
                var horas = (DateTime.Now - Fecha).ToString(@"dd\d\ hh\h\ mm\m\ ");
                this.FechaFinal = horas.ToString();
            }
            else
            {
                this.Link = "http://10.3.240.88:8089/#!/Encuesta";
            }

        }
        #endregion

    }

    
}
