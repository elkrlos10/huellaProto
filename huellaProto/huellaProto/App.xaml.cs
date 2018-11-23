namespace huellaProto
{
    using huellaProto.Helpers;
    using huellaProto.ViewModels;
    using huellaProto.ViewsModels;
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
            //Settings.FechaProyecto = string.Empty;
            if (!string.IsNullOrEmpty(Settings.FechaProyecto))
            {
                MainViewModel.GetInstance().CuentaRegresiva = new CuentaRegresivaViewModel();
                //await Application.Current.MainPage.Navigation.PushAsync(new cuentaRegresiva());
                Application.Current.MainPage = new NavigationPage(new cuentaRegresiva());

                return;
            }
            //Settings.User = string.Empty;
            //Settings.Proyectos = string.Empty;
            if (string.IsNullOrEmpty(Settings.User) || bool.Parse(Settings.Proyectos) == false)
            {
                MainViewModel.GetInstance().Login = new LoginViewModel();

                MainPage = new NavigationPage(new Login()) { BarBackgroundColor = Color.FromHex("#82a20d"), BarTextColor = Color.White };
            }
            else
            {

                MainViewModel.GetInstance().MenuProyectos = new MenuItemViewModel();
                MainViewModel.GetInstance().ListaProyectos = new ListaProyectosViewModel();
                MainViewModel.GetInstance().IdEmpresa = int.Parse(Settings.IdEmpresa);
                MainPage = new MasterPage();
            }

            //MainPage = new MasterPage();
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
