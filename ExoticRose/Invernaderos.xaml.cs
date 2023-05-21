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

            // Asignar la lista de invernaderos al Picker
            pkInvernadero.ItemsSource = invernaderos;

            // Establecer el binding para mostrar el nombre en el Picker
            pkInvernadero.ItemDisplayBinding = new Binding("nombre");

            // Asignar el evento de selección al Picker
            pkInvernadero.SelectedIndexChanged += pkInvernadero_SelectedIndexChanged;
        }
        private void pkInvernadero_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var selectedInvernadero = (Invernadero)picker.SelectedItem;

            if (selectedInvernadero != null)
            {
                int idInvernadero = selectedInvernadero.id;
                string nombreInvernadero = selectedInvernadero.nombre;

                DisplayAlert("Mensaje", $"El ID del invernadero seleccionado es: {idInvernadero}", "Cerrar");
                ///////////////////listar
                // Realizar la consulta anidada para obtener las variedades del invernadero seleccionado
                // Realizar la consulta anidada para obtener las variedades del invernadero seleccionado
                // Realizar la consulta anidada para obtener las variedades del invernadero seleccionado
                WebClient client = new WebClient();
                string urlVariedades = $"http://192.168.1.109/exotic/anidadas.php?idInvernadero={idInvernadero}";
                string responseVariedades = client.DownloadString(urlVariedades);
                List<Invernadero_Variedad> invernaderoVariedades = JsonConvert.DeserializeObject<List<Invernadero_Variedad>>(responseVariedades);

                // Obtener los IDs de las variedades del invernadero seleccionado
                List<int> idVariedades = invernaderoVariedades.Select(iv => iv.idVariedad).ToList();

                // Obtener las variedades correspondientes a los IDs obtenidos
                List<Variedad> variedades = new List<Variedad>();
                foreach (int idVariedad in idVariedades)
                {
                    // Realizar la consulta para obtener cada variedad por su ID
                    string urlVariedad = $"http://192.168.1.109/exotic/post.php?Variedad&id={idVariedad}";
                    string responseVariedad = client.DownloadString(urlVariedad);
                    Variedad variedad = JsonConvert.DeserializeObject<Variedad>(responseVariedad);
                    variedades.Add(variedad);
                }

                // Asignar la lista de variedades al ListView
                lstVariedades.ItemsSource = variedades;
            }
            else 
            {
                DisplayAlert("Mensaje","Error al obtener ID","Cerrar");
            }
        }
    }
}