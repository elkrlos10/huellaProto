using GalaSoft.MvvmLight.Command;
using huellaProto.Models.DTO;
using huellaProto.Service;
namespace huellaProto.ViewsModels
{
	using huellaProto.ViewModels;
	using huellaProto.Views;
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Windows.Input;
	using Xamarin.Forms;

	public class CompensarViewModel : BaseViewModel
	{
		#region Service
		private ApiService apiService;
		#endregion

		#region atributos
		private double toneladasCo2;
		private string zona;
		private string arbol;
		private bool precisar;
		private double porcentaje;
		#endregion

		#region Propiedades

		public double ToneladasCo2
		{
			get { return this.toneladasCo2; }
			set { SetValue(ref this.toneladasCo2, value); }
		}
		public string Zona
		{
			get { return this.zona; }
			set { SetValue(ref this.zona, value); }
		}
		public string Arbol
		{
			get { return this.arbol; }
			set { SetValue(ref this.arbol, value); }
		}
		public bool Precisar
		{
			get { return this.precisar; }
			set { SetValue(ref this.precisar, value); }
		}
		public double Porcentaje
		{
			get { return this.porcentaje; }
			set { SetValue(ref this.porcentaje, value); }
		}
		#endregion

		#region Constructor
		public CompensarViewModel()
		{
			this.apiService = new ApiService();
			this.CalculoHuella();
			Application.Current.MainPage.DisplayAlert(
			"Información",
			"Si deseas compensar la huella de carbono que dejas en el medio ambiente, a continuación encontrarás un programa de siembra de árboles donde podrás seleccionar la zona, el tipo de árbol y el porcentaje a compensar.",
			"Aceptar");
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

		public ICommand CompensarCommand
		{
			get
			{
				return new RelayCommand(GuargarCalculo);
			}
		}

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

				this.ToneladasCo2 = Math.Round(double.Parse(totalHuella.Paramatro1), 2);
			}
			catch (Exception e)
			{
				throw;
			}

		}

		private async void ConfCommand()
		{
			//MainViewModel.GetInstance().Tabs = new TabsViewModel();
			Application.Current.MainPage = new MasterPage();
			//await Application.Current.MainPage.Navigation.PushAsync(new CompensarPage());
		}

		private async void GuargarCalculo()
		{

			var oHuella = new HuellaDTO
			{
				IdProyecto = MainViewModel.GetInstance().IdProyecto,
				Toneledas = this.ToneladasCo2,
				Fecha = DateTime.Now,
				TipoArbol = this.Arbol,
				Zona = this.Zona,
				Precisar = this.Precisar,
				Porcentaje = this.Porcentaje
			};

			try
			{
				var response = await this.apiService._Post(
									  MainViewModel.GetInstance().UrlServices,
									  "api/Proyecto",
									 "/Guardarcalculo", oHuella);
			}
			catch (Exception e)
			{
				throw;
			}


			//await Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(2));
		}

		private async void NoPrecisar()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new CompensarPage());
		}

		private async void PrecisarHuella()
		{
            MainViewModel.GetInstance().CuentaRegresiva = new CuentaRegresivaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new cuentaRegresiva());
		}

		#endregion


	}
}
