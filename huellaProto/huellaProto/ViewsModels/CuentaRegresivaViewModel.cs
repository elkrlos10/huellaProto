using GalaSoft.MvvmLight.Command;
using huellaProto.Helpers;
using huellaProto.Service;
using huellaProto.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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

        #region Commands

        public ICommand AbrirUrlCommand
        {
            get
            {
                return new RelayCommand(AbrirUrl);
            }
        }

        #endregion

        #region Metodos
        private void Precisar(bool _precisar)
        {
            if (_precisar)
            {
                var Fecha =  MainViewModel.GetInstance().oProyecto.FechaProyecto.AddDays(15);
                var horas = (DateTime.Now - Fecha).ToString(@"dd\-\ hh\-\ mm\m\ ");
                string[] split = horas.Split(new Char[] {'-','m'});

                string Cadena = "";
               
                for (int i = 0; i < 3; i++)
                {
                    if (i==0)
                    {
                        Cadena = split[i] + " días";
                    }
                    if (i == 1)
                    {
                        Cadena = Cadena + " " +split[i] + " horas";
                    }
                }
                //this.FechaFinal = horas.ToString();
                this.FechaFinal = Cadena;
                this.Link = "http://10.3.240.88:8089/#!/Encuesta";
            }
        }

        private void AbrirUrl()
        {
            Device.OpenUri(new Uri("http://10.3.240.88:8089/#!/Encuesta"));
        }
        #endregion

    }
}
