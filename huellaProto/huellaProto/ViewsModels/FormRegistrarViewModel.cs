

namespace huellaProto.ViewsModels
{
    using GalaSoft.MvvmLight.Command;
    using huellaProto.ViewModels;
    using huellaProto.Views;
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class FormRegistrarViewModel: BaseViewModel
    {
        #region Atributos
        private string password;
        private bool isRunning;
        private bool isEnabled;
        private string nombre;
        private string email;
        private string nit;
        private string direc;
        private bool isVisibleIns;
        private bool isVisibleEmp;

        #endregion

        #region Contructor
        public FormRegistrarViewModel(bool institucion, bool  empresa)
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
            this.IsVisibleIns = institucion;
            this.IsVisibleEmp = empresa;
           
        }
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public string Nit
        {
            get { return this.nit; }
            set { SetValue(ref this.nit, value); }
        }
        public string Direc
        {
            get { return this.direc; }
            set { SetValue(ref this.direc, value); }
        }
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public bool IsRemembered { get; set; }
        //Por medio de los atributos se deben actualizar las propiedades en tiempo de ejecucíon en la aplicación
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref isEnabled, value); }

        }
       
        public bool IsVisibleIns
        {
            get { return this.isVisibleIns; }
            set { SetValue(ref isVisibleIns, value); }

        }
        public bool IsVisibleEmp
        {
            get { return this.isVisibleEmp; }
            set { SetValue(ref isVisibleEmp, value); }

        }

        #endregion

        #region Commands

        public ICommand RegisCommand
        {
            get
            {
                return new RelayCommand(this.Regis);
            }
        }

        private void Regis()
        {
            if (string.IsNullOrEmpty(this.Nombre))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor el nombre"
                   , "Aceptar");

                return;
            }
            if (string.IsNullOrEmpty(this.Email))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor el Email"
                   , "Aceptar");

                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            if (string.IsNullOrEmpty(this.Password))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor la Contraseña"
                   , "Aceptar");

                return;
            }
            if (string.IsNullOrEmpty(this.Nit))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor el NIT"
                   , "Aceptar");

                return;
            }

            if (string.IsNullOrEmpty(this.Direc))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error"
                   , "Ingrese por favor la dirección"
                   , "Aceptar");

                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Nombre = string.Empty;
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.Nit = string.Empty;
            this.Direc = string.Empty;

            MainViewModel.GetInstance().Login = new LoginViewModel();
            Application.Current.MainPage.Navigation.PushAsync(new Login());

        }
        #endregion
    }
}
