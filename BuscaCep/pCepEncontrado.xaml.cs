using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuscaCep
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class pCepEncontrado : ContentPage
    {
        public pCepEncontrado(CEP.CEPData cEPData)
        {
            InitializeComponent();
            this.BindingContext = cEPData;        
        }

        private async void btnMaps_Clicked(object sender, EventArgs e)
        {
            CEP.CEPData cEPData = (CEP.CEPData)this.BindingContext;


            ///string googleMapsUrl = $"https://www.google.com/maps?q={cEPData.Cep.Replace("-","")}";
            string googleMapsUrl = $"https://www.google.com/maps/search/?api=1&query={cEPData.Cep}";
            // Abre a URL no navegador padrão
            await Launcher.OpenAsync(new Uri(googleMapsUrl));
        }
    }
}