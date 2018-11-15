using GalaSoft.MvvmLight.Command;
using huellaProto.Helpers;
using huellaProto.Models;
using huellaProto.Models.DTO;
using huellaProto.Service;
using huellaProto.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace huellaProto.ViewsModels
{
    public class ListaProyectosViewModel : BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region Atributos 
        //PaisItemViewModel es un espejo del modelo o clase land de la cual hereda, para no dañar
        //la arquitectura y poder agregar el command en la itemViewModel
        private ObservableCollection<HuellaDTO> proyectos;
        private bool isRefreshing;
        private HuellaDTO selectedItem;


        #endregion

        #region Propiedades 
        public ObservableCollection<HuellaDTO> Proyectos
        {
            get { return this.proyectos; }
            set { SetValue(ref this.proyectos, value); }
        }

        public HuellaDTO SelectedItem
        {
            get { return this.selectedItem; }
            set
            {
                SetValue(ref this.selectedItem, value);
                this.CompletarCompensacion();
            }
        }

       


        #endregion

        #region Constructor
        public ListaProyectosViewModel()
        {
            this.apiService = new ApiService();
            this.ConsultarProyectos();
        }
        #endregion

        #region Comandos

        public ICommand CompletarCommand
        {
            get
            {
                return new RelayCommand(CompletarCompensacion);
            }
        }

        #endregion

        #region Metodos
        private async void ConsultarProyectos()
        {

            var IdEmpresa = int.Parse(Settings.IdEmpresa);

            try
            {
                var response = await this.apiService._GetList<HuellaDTO>(
                                 MainViewModel.GetInstance().UrlServices,
                                 "api/Proyecto",
                                "/ConsultarProyectos", IdEmpresa);

                var ListaHuella = (List<HuellaDTO>)response.Result;

                //Validar la respuesta del api
                if (!response.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");

                    return;
                }
                this.Proyectos = new ObservableCollection<HuellaDTO>(ListaHuella);
              
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        private async void CompletarCompensacion()
        {
            var Huella = this.SelectedItem;
            if (Huella== null)
            {
                return;
            }
            var answer =  await App.Current.MainPage.DisplayAlert("Compensar", "¿Desea compensar el porcentaje faltante de su huella de carbono calculada sobre este proyecto?", "Si", "No");
          
            if (answer)
            {
               
                if (Huella.EstadoCompensacion)
                {
                    await Application.Current.MainPage.DisplayAlert("Información", "La compesación de este proyecto se completo al 100%", "Aceptar");
                    this.SelectedItem = null;
                    return;
                }
                //if (Huella.Porcentaje == 100)
                //{
                //    await Application.Current.MainPage.DisplayAlert("Información", "La compesación de huella de este proyecto ejecuto al 100%", "Aceptar");
                //    this.SelectedItem = null;
                //    return;
                //}
                if (Huella.Estado != true)
                {
                    await Application.Current.MainPage.DisplayAlert("Información", "Este proyecto aún no se ha aprobado, por lo tanto no se puede completar su compensación", "Aceptar");
                    this.SelectedItem = null;
                    return;
                }
                try
                {
                    Huella.Estado = false;
                       var response = await this.apiService._PostList<HuellaDTO>(
                                          MainViewModel.GetInstance().UrlServices,
                                          "api/Proyecto",
                                         "/CompletarCompensacion", Huella);
                    var ListaHuella = (List<HuellaDTO>)response.Result;

                    if (!response.IsSuccess)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                        return;
                    }
                    this.Proyectos = new ObservableCollection<HuellaDTO>(ListaHuella);
                    //MainViewModel.GetInstance().ListaProyectos = new ListaProyectosViewModel();
                    //await Application.Current.MainPage.Navigation.PushAsync(new ListaProyectosPage());
                }
                catch (Exception e)
                {
                    throw;
                }

            }

        }
        #endregion

    }
}
