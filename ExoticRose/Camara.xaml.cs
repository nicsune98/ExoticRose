using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
namespace ExoticRose
{	
	public partial class Camara : ContentPage
	{	
		public Camara ()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "Camara";
        }
        private async void btnCamara_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }
                var foto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    DefaultCamera = CameraDevice.Rear,
                    Name = "Usuario: Ivan" + DateTime.Now.ToString(),
                    Directory = "Fotos",
                    SaveToAlbum = true

                });
                //				if (foto != null)
                //			{
                //					imageCamara.Source = ImageSource.FromStream(() => { return foto.GetStream(); });
                //			}


                if (foto == null)
                    return;

                await DisplayAlert("File Location", foto.Path, "OK");

                imageCamara.Source = ImageSource.FromStream(() =>
                {
                    var stream = foto.GetStream();
                    return stream;
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

    }
}

