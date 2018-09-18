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
			this.ToneladasCo2 = MainViewModel.GetInstance().ToneladasCO2;
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

			await Application.Current.MainPage.Navigation.PushAsync(new cuentaRegresiva());
		}

		#endregion

	}
}
