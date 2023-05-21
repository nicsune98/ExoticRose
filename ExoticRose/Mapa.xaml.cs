using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ExoticRose
{	
	public partial class Mapa : ContentPage
	{	
		public Mapa ()
		{
			InitializeComponent ();
            Pin pin = new Pin()
            {
                Type = PinType.Place,
                Label = "Cayambe",
                Position = new Position(0.041119, -78.145220)
            };
            MyMap.Pins.Add(pin);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(300)));
        }

        void Ubicar_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

