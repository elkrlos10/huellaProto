using huellaProto.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace huellaProto.ViewModels
{
    public class CalculoViewModel: BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region atributos
        private double toneladasCo2;
        private string region;
        private string arbol;
        private bool precision;
        #endregion

        #region Propiedades

        public double ToneladasCo2
        {
            get { return this.toneladasCo2; }
            set { SetValue(ref this.toneladasCo2, value); }
        }
        public string Region
        {
            get { return this.region; }
            set { SetValue(ref this.region, value); }
        }
        public string Arbol
        {
            get { return this.arbol; }
            set { SetValue(ref this.arbol, value); }
        }
        public bool Precision
        {
            get { return this.precision; }
            set { SetValue(ref this.precision, value); }
        }
        #endregion

        #region Constructor
        public CalculoViewModel()
        {
            this.apiService = new ApiService();
            this.CalculoHuella();
        }

        #endregion


        #region Metodos
        private async void CalculoHuella()
        {
            try
            {
                var response = await this.apiService.Post<double>(
                                 MainViewModel.GetInstance().UrlServices,
                                 "api/Proyecto",
                                "/RegristarVehiculos", MainViewModel.GetInstance().IdProyecto);

                var cosa = response.Result;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        #endregion

    }
}
