using System;
using System.Collections.Generic;
using System.Text;

using GalaSoft.MvvmLight.Command;
using huellaProto.ViewModels;
using huellaProto.Views;
using huellaProto.Models;
using System.Windows.Input;
using Xamarin.Forms;
using huellaProto.Service;
using System.Threading.Tasks;

namespace huellaProto.ViewsModels
{
    class CalcularInstiViewModel
    {

		private void AlertaCompensar()
		{
			Application.Current.MainPage.DisplayAlert(
			"Información",
			"Si deseas compensar la huella de carbono que dejas en el medio ambiente, a continuación encontrarás un programa de siembra de árboles donde podrás seleccionar la zona, el tipo de árbol y el porcentaje a compensar.",
			"Aceptar");
		}
		}
}
