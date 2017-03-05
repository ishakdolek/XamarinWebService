using System;
using AppWebServis.Provider;
using Xamarin.Forms;

namespace AppWebServis.View
{
    public partial class SampleWebServis : ContentPage
    {
        private readonly ServiceManager _serviceManager = new ServiceManager();
        public SampleWebServis()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var collection = _serviceManager.GetAll();
                lstWebService.BindingContext = collection;
            }
            catch (Exception exception)
            {
                DisplayAlert("Error", "Hata!:" + exception.Message, "Tamam");
            }
        }
    }
}
