using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace huellaProto.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormRegistrar : ContentPage
	{
		public FormRegistrar ()
		{
			InitializeComponent ();

            //NavigationPage.SetHasNavigationBar(this, false);
        }


        //private async Task ValidarFormulario()
        //{
        //    //Valida si el valor en el Entry se encuentra vacio o es igual a Null
        //    if (String.IsNullOrWhiteSpace(Nombre.Text))
        //    {
        //        await this.DisplayAlert("Advertencia", "El campo del nombre es obligatorio.", "OK");
        //        return;
        //    }
        //    //Valida que solo se ingresen letras
        //    //else if (!Nombre.Text.ToCharArray().All(Char.IsLetter))
        //    //{
        //    //    await this.DisplayAlert("Advertencia", "Tu información contiene números, favor de validar.", "OK");
        //    //    return;
        //    //}
        //    if (String.IsNullOrWhiteSpace(NombreE.Text))
        //    {
        //        await this.DisplayAlert("Advertencia", "El campo del nombre es obligatorio.", "OK");
        //        return;
        //    }
        //    //Valida que solo se ingresen letras
        //    //else if (!Nombre.Text.ToCharArray().All(Char.IsLetter))
        //    //{
        //    //    await this.DisplayAlert("Advertencia", "Tu información contiene números, favor de validar.", "OK");
        //    //    return;
        //    //}
        //    //else
        //    //{
        //    //    //Valida si se ingresan caracteres especiales
        //    //    string caractEspecial = @"^[^ ][a-zA-Z ]+[^ ]$";
        //    //    bool resultado = Regex.IsMatch(UserName.Text, caractEspecial, RegexOptions.IgnoreCase);
        //    //    if (!resultado)
        //    //    {
        //    //        await this.DisplayAlert("Advertencia", "No se aceptan caracteres especiales, intente de nuevo.", "OK");
        //    //        return false;
        //    //    }
        //    //}
            
        //    //Valida que solo se ingresen letras
        //    //else if (!UserLastName.Text.ToCharArray().All(Char.IsLetter))
        //    //{
        //    //    await this.DisplayAlert("Advertencia", "Tu información contiene números, favor de validar.", "OK");
        //    //    return false;
        //    //}
        //    //else
        //    //{
        //    //    //Valida si se ingresan caracteres especiales
        //    //    string caractEspecial = @"^[^ ][a-zA-Z ]+[^ ]$";
        //    //    bool resultado = Regex.IsMatch(UserLastName.Text, caractEspecial, RegexOptions.IgnoreCase);
        //    //    if (!resultado)
        //    //    {
        //    //        await this.DisplayAlert("Advertencia", "No se aceptan caracteres especiales, intente de nuevo.", "OK");
        //    //        return false;
        //    //    }
        //    //}

        //    if (String.IsNullOrWhiteSpace(Email.Text))
        //    {
        //        await this.DisplayAlert("Advertencia", "El campo del correo electronico es obligatorio.", "OK");
        //        return;
        //    }
        //    else
        //    {
        //        //Valida que el formato del correo sea valido
        //        bool isEmail = Regex.IsMatch(Email.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        //        if (!isEmail)
        //        {
        //            await this.DisplayAlert("Advertencia", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
        //            return;
        //        }
        //    }

        //    if (String.IsNullOrWhiteSpace(Nit.Text))
        //    {
        //        await this.DisplayAlert("Advertencia", "El campo Nit es obligatorio.", "OK");
        //        return;
        //    }
        //    else
        //    {
        //        //Valida que solo se ingresen numeros
        //        if (!Nit.Text.ToCharArray().All(Char.IsDigit))
        //        {
        //            await this.DisplayAlert("Advertencia", "El formato del celular es incorrecto, solo se aceptan numeros.", "OK");
        //            return;
        //        }
        //    }

        //    //Valida si la cantidad de digitos ingresados es menor a 10
        //    if (Password.Text.Length < 6)
        //    {
        //        await this.DisplayAlert("Advertencia", "La contraseña debe tener al menos 6 caracteres.", "OK");
        //        return;
        //    }
           
        //}

        //async void Continue_Tapped(object sender, EventArgs e)
        //{
        //    await this.ValidarFormulario();
            
        //}

    }
}