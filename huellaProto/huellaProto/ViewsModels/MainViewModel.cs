namespace huellaProto.ViewModels
{
    using huellaProto.ViewsModels;
    using System;
    using System.Collections.ObjectModel;

    public class MainViewModel
    {
        #region ViewModel

        public LoginViewModel Login { get; set; }
        public huellaViewModel huellaProto { get; set; }
        public RegistroViewModel Registro { get; set; }
        public CalculoViewModel Calculo { get; set; }
        public RecordarViewModel Recordar { get; set; }
        public FlotaViewModel FlotaC { get; set; }
        public ListFlotaViewModel ListaFlota { get; set; }
        public FormRegistrarViewModel FormRegistrar { get; set; }
        public BienvenidaViewModel Bienvenida { get; set; }
        public TabsViewModel Tabs { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }


        public string User { get; set; }
        public int IdProyecto { get; set; }
        public int TipoEmpresa { get; set; }
        public string Etapa { get; set; }
        public int IdEmpresa { get; set; }
        public string UrlServices { get; set; }

        #endregion

        #region Contructores

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.UrlServices = "http://10.3.240.88:8089//";
            //this.Registro = new RegistroViewModel();
            //this.Recordar = new RecordarViewModel();
            //this.FlotaC = new FlotaViewModel();
            //this.ListaFlota = new ListFlotaViewModel("");
            this.CargarMenu();
        }

        
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion

        #region Metodos
        private void CargarMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel
            {
                Icon= "users",
                PageName="",
                Title="Sena",
				WidthRequest = "40"
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "sprout",
                PageName = "",
                Title = "Proyectos",
				WidthRequest = "50"

			});

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "salir",
                PageName = "",
                Title = "Cerrar sesión",
				WidthRequest = "40"

			});

        }
        #endregion

    }
}
