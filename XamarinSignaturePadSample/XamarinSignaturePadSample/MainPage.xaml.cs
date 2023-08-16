using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinSignaturePadSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        // https://parallelcodes.com/xamarin-forms-using-signaturepad-get-image-and-base64-value/
        private async void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var image = await signature.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
                var mStream = (MemoryStream)image;
                byte[] data = mStream.ToArray();
                string base64Val = Convert.ToBase64String(data);
                lblBase64Value.Text = base64Val;
                imgSignature.Source = ImageSource.FromStream(() => mStream);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }


        // https://github.com/xamarin/SignaturePad#readme
        // https://xamarinlatino.com/agregando-firmas-en-xamarin-forms-7b34dafe9e7f
        /// https://medium.com/@esmerlinmoya/using-xamarin-controls-signaturepad-forms-b2a63512ae80
        /// https://vicenteguzman.mx/2018/signaturepad-xamarin-forms/

        public async void Save(object sender, EventArgs eventArgs)
        {
            Stream stream = await signature.GetImageStreamAsync(SignatureImageFormat.Jpeg);

            // Obteniendo los puntos que construyen la firma para recargarla en nuestra pantalla
            // Este es un formato importante ya que por medio de el puedes recrear alguna firma creada en tu pantalla.Esta se obtiene por medio a un arreglo de puntos al cual puedes acceder de la siguiente manera:
            //var strokesSignature = signature.Strokes;

            // ¿Y cómo puedo recrear esta firma..?
            //signature.Strokes = strokesSignature;



            // Obtaining the Signature Points
            // In addition to retrieving the signature as an image, the signature can also be retrieved as as an array of points:
            var strokes = signature.Strokes;

            // These strokes can be used to save and restore a signature:
            // - restore strokes (iOS, Android, Windows)
            //signature.LoadStrokes(strokes);
            // - restore strokes (Xamarin.Forms)
            //signature.Strokes = newStrokes;
        }

    }
}
