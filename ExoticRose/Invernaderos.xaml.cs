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
	public partial class Invernaderos : ContentPage
	{
		public Invernaderos ()
		{
			InitializeComponent ();
            pkInvernadero.Items.Add("Invernadero 1");
            pkInvernadero.Items.Add("Invernadero 2");
        }

        private void pkInvernadero_SelectedIndexChanged(object sender, EventArgs e)
        {
			
        }
    }
}