using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExoticRose
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private async void btIniciar_Clicked(object sender, EventArgs e)
        {

            string usuarioIngresado = txtUsuario.Text;
            string contrasenaIngresado = txtContrasena.Text;
            string nombreUsuario = string.Empty; // Variable para almacenar el nombre de usuario

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(usuarioIngresado) || string.IsNullOrWhiteSpace(contrasenaIngresado))
            {
                await DisplayAlert("Mensaje", "Ingrese un Usuario y Contraseña", "Aceptar");
            }
            else
            {
                // Realizar la consulta al servicio PHP
                string tabla = "usuario";
                string url = $"http://192.168.1.109/exotic/post.php?tabla={tabla}";
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(url);

                // Deserializar la respuesta JSON
                List<ExoticRose.WS.Usuarios> datos = JsonConvert.DeserializeObject<List<ExoticRose.WS.Usuarios>>(response);

                // Verificar si existe una coincidencia en los datos obtenidos
                ExoticRose.WS.Usuarios usuarioEncontrado = datos.FirstOrDefault(dato => dato.usuario == usuarioIngresado && dato.contraseña == contrasenaIngresado);

                // Verificar si se encontró el usuario y contraseña correctos
                if (usuarioEncontrado != null)
                {
                    nombreUsuario = usuarioEncontrado.nombre; // Almacenar el nombre de usuario en la variable

                    await DisplayAlert("Éxito", "Inicio de sesión exitoso", "Aceptar");
                    await Navigation.PushAsync(new Menu(nombreUsuario)); // Pasar el nombre de usuario a la ventana Menu
                }
                else
                {
                    await DisplayAlert("Error", "Usuario y/o contraseña incorrectos", "Aceptar");
                }
            }

        }
    }
}