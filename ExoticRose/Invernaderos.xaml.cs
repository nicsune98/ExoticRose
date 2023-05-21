using ExoticRose.WS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExoticRose
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Invernaderos : ContentPage
	{
        private List<Invernadero> invernaderos;
        private string tabla = "invernadero";
        private int idInvernadero;
        public Invernaderos ()
		{
			InitializeComponent ();
            Obtener();
            dtFecha.Date = DateTime.Now;
        }
        public void Obtener()
        {
            // Construir la URL del script PHP con el nombre de la tabla como parámetro
            string url = $"http://192.168.1.109/exotic/post.php?tabla={tabla}";

            // Realizar la solicitud HTTP al script PHP
            WebClient client = new WebClient();
            string response = client.DownloadString(url);

            // Deserializar la respuesta JSON en una lista de objetos Invernadero
            invernaderos = JsonConvert.DeserializeObject<List<Invernadero>>(response);

            // Asignar la lista de nombres al Picker
            pkInvernadero.ItemsSource = invernaderos.Select(i => i.nombre).ToList();
        }
        private void pkInvernadero_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedInvernadero = picker.SelectedItem as Invernadero;

            if (selectedInvernadero != null)
            {
                idInvernadero = selectedInvernadero.id;
                lblprue.Text = idInvernadero.ToString();
                DisplayAlert("Mensaje", "El id del inver es: "+idInvernadero, "cerrar");
            }
        }
    }
}