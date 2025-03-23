using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System.Threading.Tasks;

namespace Sesion6
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ClickedCamera(object sender, EventArgs e)
        {
            try
            {
                var foto = await MediaPicker.CapturePhotoAsync();//FUNCION ASINCRONA Conviene poner await antes
                if (foto != null)
                {
                    var stream = await foto.OpenReadAsync();
                    //cosas que queremos hacer con la foto

                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Localizacion", ex.Message, "Cancelar");
            }
        }
        private async void ClickedGPS(object sender, EventArgs e)
        {
            try
            {
                var loc = await Geolocation.GetLastKnownLocationAsync(); //FUNCION ASINCRONA Conviene poner await antes
                if (loc != null)
                {
                    await DisplayAlert("Localizacion", "Hey hey hey tengo tu ubicacion:" +loc.Latitude + loc.Longitude + "" , "Cancelar" ); 
                  
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Localizacion",ex.Message, "Cancelar");
            }
        }
        private async void ClickedHuellas(object sender, EventArgs e)
        {
            var request = new AuthenticationRequestConfiguration("Autenticacion", "Por favor autentiquese" );
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            
            if(result.Authenticated)
            {
                await DisplayAlert("Autenticacion", "Autenticacion exitosa", "Aceptar");
            }
            else
            {
                await DisplayAlert("Fallo en Autenticacion", "Autenticacion fallida", "Aceptar");
            }


        }
    }

}
