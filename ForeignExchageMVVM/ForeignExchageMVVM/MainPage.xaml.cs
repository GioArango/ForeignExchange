using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ForeignExchage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ConvertButton.Clicked += ConvertButton_Clicked;
            ClearButton.Clicked += ClearButton_Clicked;
        }


        private void ConvertButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PesosEntry.Text))
            {
                DisplayAlert("Error", "You must enter a value in pesos...", "Accept");
                return;
            }
            decimal pesos = 0;
            if (!decimal.TryParse(PesosEntry.Text, out pesos))
            {
                DisplayAlert("Error", "You must enter a value numeric in pesos...", "Accept");
                return;
            }

            var dollars = pesos / 3003.003M;
            var euros = pesos / 3531.050M;
            var pounds = pesos / 3907.2372M;

            DollarsEntry.Text = String.Format("{0:C2}", dollars);
            EurosEntry.Text = String.Format("{0:C2}", euros);
            PoundsEntry.Text = String.Format("{0:C2}", pounds);
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            PesosEntry.Text = "";
            DollarsEntry.Text = "";
            EurosEntry.Text = "";
            PoundsEntry.Text = "";
        }
    }
}
