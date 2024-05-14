using BusinessLogic;
using DTO.Model;
using System.Net.Http.Json;
namespace MauiGUI
{
    public partial class MainPage : ContentPage
    {
        Ferry ferryDetails;
        public MainPage()
        {
            InitializeComponent();
            PopulateFerryPicker();
        }

        private async void PopulateFerryPicker()
        {
            HttpClient client = new HttpClient();
            List<Ferry> ferries = await client.GetFromJsonAsync<List<Ferry>>("http://localhost:5298/api/v1/Ferry/GetAllFerries");
            FerryPicker.ItemsSource = ferries;
        }

        private async void FerryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            Ferry pickedFerry = (Ferry)FerryPicker.SelectedItem;
            ferryDetails = await client.GetFromJsonAsync<Ferry>($"http://localhost:5298/api/v1/Ferry/GetFerryDetails/{pickedFerry.Id}");
            int guestCount = ferryDetails.Guests.Count;
            int carCount = ferryDetails.Cars.Count;
            int guestPrice = ferryDetails.PricePerGuest;
            int carPrice = ferryDetails.PricePerCar;
            EntryPricePerGuest.Text = ferryDetails.PricePerGuest.ToString();
            EntryPricePerCar.Text = ferryDetails.PricePerCar.ToString();
            EntryGuests.Text = guestCount.ToString();
            EntryCars.Text = carCount.ToString();
            EntryTotalPrice.Text = ((guestCount * guestPrice) + (carCount * carPrice)).ToString();
            EntrySpaceForGuests.Text = ferryDetails.MaxGuests.ToString();
            EntrySpaceForCars.Text = ferryDetails.MaxCars.ToString();
        }

        private async void BtnUpdateFerry_Clicked(object sender, EventArgs e)
        {
            if (ferryDetails != null)
            {
                HttpClient client = new HttpClient();
                int guestCount = ferryDetails.Guests.Count;
                int carCount = ferryDetails.Cars.Count;
                int guestPrice = Convert.ToInt32(EntryPricePerGuest.Text);
                int carPrice = Convert.ToInt32(EntryPricePerCar.Text);
                int spaceForGuest = Convert.ToInt32(EntrySpaceForGuests.Text);
                int spaceForCars = Convert.ToInt32(EntrySpaceForCars.Text);
                ferryDetails.PricePerGuest = guestPrice;
                ferryDetails.PricePerCar = carPrice;
                ferryDetails.MaxGuests = spaceForGuest;
                ferryDetails.MaxCars = spaceForCars;
                FerryBLL.UpdateFerry(ferryDetails);
                EntryTotalPrice.Text = ((guestCount * guestPrice) + (carCount * carPrice)).ToString();
            }
        }
    }
}
