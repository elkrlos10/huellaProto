using huellaProto.Models;
using huellaProto.Models.DTO;
using huellaProto.Service;
using huellaProto.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
            set { SetValue(ref this.selectedItem, value); }
        }


        #endregion

        #region Constructor
        public ListaProyectosViewModel()
        {
            this.apiService = new ApiService();
            this.ConsultarProyectos();
        }
        #endregion

        #region Metodos
        private async void ConsultarProyectos()
        {

            //var IdEmpresa = MainViewModel.GetInstance().oProyecto.IdEmpresa;
            //var parametrosDTO = new ParametrosDTO
            //{
            //    Paramatro1 = IdEmpresa
            //};

            try
            {
                var response = await this.apiService._GetList<HuellaDTO>(
                                 MainViewModel.GetInstance().UrlServices,
                                 "api/Proyecto",
                                "/ConsultarProyectos", 31);

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
            var answer = await .DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
            //Debug.WriteLine("Answer: " + answer);
        }
        #endregion

    }
}
