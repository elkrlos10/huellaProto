

namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class TabsViewModel: BaseViewModel
    {
        #region Atributos
        private bool isVisibleForm;
        private bool isVisiblePreg;
        private bool isVisibleFormMaquina;
        private bool isVisiblePregMaquina;
       
        #endregion

        #region Propiedades
        public bool IsVisibleForm
        {
            get { return this.isVisibleForm; }
            set { SetValue(ref this.isVisibleForm, value); }
        }

        public bool IsVisiblePreg
        {
            get { return this.isVisiblePreg; }
            set { SetValue(ref this.isVisiblePreg, value); }
        }

        public bool IsVisibleFormMaquina
        {
            get { return this.isVisibleFormMaquina; }
            set { SetValue(ref this.isVisibleFormMaquina, value); }
        }

        public bool IsVisiblePregMaquina
        {
            get { return this.isVisiblePregMaquina; }
            set { SetValue(ref this.isVisiblePregMaquina, value); }
        }
       
        #endregion

        #region Constructor
        public TabsViewModel()
        {
            this.IsVisibleForm = false;
            this.IsVisiblePreg = true;

            this.IsVisibleFormMaquina = false;
            this.IsVisiblePregMaquina = true;

            
        }
        #endregion

        #region Commands

        public ICommand VehiculosCommand
        {
            get
            {
                return new RelayCommand(Vehiculos);
            }
        }

        public ICommand OmitirCommand
        {
            get
            {
                return new RelayCommand(CambioViewVehiculo);
            }
        }

        public ICommand MaquinasCommand
        {
            get
            {
                return new RelayCommand(Maquinas);
            }
        }

        public ICommand OmitirMaquinaCommand
        {
            get
            {
                return new RelayCommand(CambioViewMaquina);
            }
        }


        public ICommand ResiduosCommand
        {
            get
            {
                return new RelayCommand(CambioViewResiduos);
            }
        }

        public ICommand CalcularCommand
        {
            get
            {
                return new RelayCommand(Calcular);
            }
        }
        #endregion

        private void Vehiculos()
        {
            this.IsVisibleForm = true;
            this.IsVisiblePreg = false;
        }

        private void CambioViewVehiculo()
        {
            if (!this.IsVisiblePreg)
            {
                this.IsVisibleForm = true;
                this.IsVisiblePreg = false;
            }
            

            
            Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(1));
            //Remover la ultima vista de la pila
            Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);

          
        }


        private void Maquinas()
        {
            this.IsVisibleFormMaquina = true;
            this.IsVisiblePregMaquina = false;
        }

        private void CambioViewMaquina()
        {
            
            Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(2));
            //Remover la ultima vista de la pila
            Application.Current.MainPage.Navigation.RemovePage
                       (Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);

        }

       

        private void CambioViewResiduos()
        {

            Application.Current.MainPage.Navigation.PushAsync(new HuellaTabbed(3));
            //Remover la ultima vista de la pila
            Application.Current.MainPage.Navigation.RemovePage
                       (Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 2]);

        }

        private async void Calcular()
        {
            MainViewModel.GetInstance().huellaProto = new huellaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CalcularInsti());
        }
    }
}
