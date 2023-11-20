using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ServiceReference1;
using System.Net.Http;
using System.Xml.Serialization;
using Exception = System.Exception;
using System.ServiceModel;
using static BuscaCep.CEP;

namespace BuscaCep
{
    public partial class MainPage : ContentPage
    {
        private bool habilita = true;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Desabilitar elementos da interface antes da operação assíncrona
            if (string.IsNullOrEmpty(cepEntry.Text))
            {
                await DisplayAlert("Atenção", "CEP inválido", "OK");
                return;
            }

            habilita = false;
            MudaEstado();

            CEP cepService = new CEP();
            CEPData cepData = await cepService.ConsultarCEP(cepEntry.Text);

            if (cepData != null)
            {
                pCepEncontrado pageCepEncontrado = new pCepEncontrado(cepData);
                await Navigation.PushModalAsync(pageCepEncontrado);
            }
            else
            {
                await DisplayAlert("Atenção", "CEP não encontrado", "OK");
            }
            habilita = true;
            MudaEstado();
        }

        private void MudaEstado()
        {
            cepEntry.IsEnabled = habilita;
            loadingIndicator.IsRunning = !habilita;
            loadingIndicator.IsVisible = !habilita;
        }

    }
}
