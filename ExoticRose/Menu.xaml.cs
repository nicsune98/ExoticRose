using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExoticRose
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{
		public Menu ()
		{
			InitializeComponent ();
		}

        private void btInvernadero_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Invernaderos());
        }

        private void btMapa_Clicked(object sender, EventArgs e)
        {

        }

        private void btProceso_Clicked(object sender, EventArgs e)
        {

        }

        private void btGraficos_Clicked(object sender, EventArgs e)
        {

        }
    }
}