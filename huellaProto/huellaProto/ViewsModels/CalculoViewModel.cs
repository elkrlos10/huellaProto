namespace huellaProto.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.Models.DTO;
    using huellaProto.Service;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using huellaProto.Views;

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
        private async void CalculoHuella()
        {
            try
            {
                var parametros = new ParametrosDTO
                {
                    Paramatro1 = MainViewModel.GetInstance().IdProyecto.ToString()
                };
                var response = await this.apiService.Post<ParametrosDTO>(
                                 MainViewModel.GetInstance().UrlServices,
                                 "api/Proyecto",
                                "/CalculoHuella", parametros);

                var totalHuella = (ParametrosDTO)response.Result;

                this.ToneladasCo2 = Math.Round(double.Parse(totalHuella.Paramatro1),2);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        private async void ConfCommand()
        {
            //MainViewModel.GetInstance().Tabs = new TabsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CompensarPage());
        }
        #endregion

    }
}
