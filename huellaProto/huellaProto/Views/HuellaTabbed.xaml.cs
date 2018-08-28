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
    public partial class HuellaTabbed : TabbedPage
    {


        public HuellaTabbed (int opc)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);

            switch (opc)
            {
                case 1:
                    this.Children.Add(new Maquinas() { Title = "MAQUINAS" });
                    CurrentPage = Children[1];
                    break;
                case 2:

                    this.Children.Add(new Maquinas() { Title = "MAQUINAS" });
                    this.Children.Add(new ResiduosPage() { Title = "RESIDUOS" });
                    CurrentPage = Children[2];
                    break;
                case 3:
                    this.Children.Add(new Maquinas() { Title = "MAQUINAS" });
                    this.Children.Add(new ResiduosPage() { Title = "RESIDUOS" });
                    this.Children.Add(new Energia() { Title = "ENERGIA" });
                    CurrentPage = Children[3];
                    break;
              
            }
        }

    }
}