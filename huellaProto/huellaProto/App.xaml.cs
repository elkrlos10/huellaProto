
namespace huellaProto
{
    using Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        #region Propiedades
        public static object Navigator { get; internal set; }
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new CalcularInsti()) { BarBackgroundColor = Color.FromHex("#82a20d"), BarTextColor = Color.White };
            //MainPage = new  MasterPage();
        }

        #endregion

        #region Metodos
        protected override void OnStart()
        {
            // Cuando la app de ejecuta
        }

        protected override void OnSleep()
        {
            //Dormir la app
        }

        protected override void OnResume()
        {
            // Despertar la app
        }
        #endregion
    }
}
