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
    using huellaProto.Models;
	using huellaProto.ViewsModels;
    using System.Threading.Tasks;

    public class CalculoViewModel: BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region atributos
        private double toneladasCo2;
        #endregion

        #region Propiedades

        public double ToneladasCo2
        {
            get { return this.toneladasCo2; }
            set { SetValue(ref this.toneladasCo2, value); }
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
       

		public ICommand NoPrecisarCommand
		{
			get
			{
				return new RelayCommand(NoPrecisar);
			}
		}

		public ICommand PrecisarCommand
		{
			get
			{
				return new RelayCommand(PrecisarHuella);
			}
		}
		#endregion

		#region Metodos
		private async void NoPrecisar()
		{
			MainViewModel.GetInstance().Compensar = new CompensarViewModel();
			await Application.Current.MainPage.Navigation.PushAsync(new CompensarPage());
		}

		private async void PrecisarHuella()
		{
            MainViewModel.GetInstance().CuentaRegresiva = new CuentaRegresivaViewModel(true);
			await Application.Current.MainPage.Navigation.PushAsync(new cuentaRegresiva());
		}

        private async void CalculoHuella()
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

            MainViewModel.GetInstance().ToneladasCO2 = Math.Round(double.Parse(totalHuella.Paramatro1) / 1000, 2);
            this.ToneladasCo2 = MainViewModel.GetInstance().ToneladasCO2;
        }

        #endregion

    }
}
