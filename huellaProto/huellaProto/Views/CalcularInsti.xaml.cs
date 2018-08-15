using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace huellaProto.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalcularInsti : ContentPage
	{
		public CalcularInsti ()
		{
			InitializeComponent ();
            var image = new Image { Source = "Arbol.png" };
            var image2 = new Image { Source = "agua_icon.png" };
            var treeList = new List<Image>();
            
            treeList.Add(image);
            treeList.Add(image2);
            

            var picker = new Picker { Title = "Selecciona un arbol" };
            picker.ItemsSource = treeList;
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}