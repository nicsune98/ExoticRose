using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ExoticRose
{	
	public partial class Mapa : ContentPage
	{	
		public Mapa ()
		{
			InitializeComponent ();
            //Localizar(0.041119, -78.145220, "Cayambe");
            Localizar(-12.0271214, -77.152989, "Lima");
        }

        private async void Localizar(double latitud, double longitud, string ubicacion)
        {
            Pin pin = new Pin()
            {
                Type = PinType.Place,
                Label = ubicacion,
                Position = new Position(latitud, longitud)
            };
            MyMap.Pins.Add(pin);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMeters(300)));

        }


        private async void Ubicar_Clicked(System.Object sender, System.EventArgs e)
        {
            if (CrossGeolocator.Current.IsGeolocationAvailable)
            {
                if (CrossGeolocator.Current.IsGeolocationEnabled)
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;

                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                   
                    Device.BeginInvokeOnMainThread(() => {
                        latitude.Text = $"Latitud : {position.Latitude}";
                        longitude.Text = $"Longitud : {position.Longitude}";
                        
                    });
                    Localizar(position.Latitude, position.Longitude, "Ubicacion Actual");
                }
                else
                {
                    await DisplayAlert("Message", "GPS Not Enabled", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Message", "GPS Not Available", "Ok");
            }

           

        }
    }
}

