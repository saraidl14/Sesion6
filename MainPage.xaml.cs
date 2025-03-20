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
                Console.WriteLine(ex);
            }
        }
        private void ClickedGPS(object sender, EventArgs e)
        {

        }
        private void ClickedHuellas(object sender, EventArgs e)
        {

        }
    }

}
