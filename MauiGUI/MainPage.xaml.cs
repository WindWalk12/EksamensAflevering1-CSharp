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
            List<Guest> ferryGuests = await AllGuestsOnFerry();
            int guestCount = ferryGuests.Count;
            int carCount = ferryDetails.Cars.Count;
            int guestPrice = ferryDetails.PricePerGuest;
            int carPrice = ferryDetails.PricePerCar;
            EntryPricePerGuest.Text = ferryDetails.PricePerGuest.ToString();
            EntryPricePerCar.Text = ferryDetails.PricePerCar.ToString();
            EntryGuests.Text = guestCount.ToString();
            EntryCars.Text = carCount.ToString();
            EntryTotalPrice.Text = CalcTotalPrice(guestCount, guestPrice, carCount, carPrice);
            EntrySpaceForGuests.Text = ferryDetails.MaxGuests.ToString();
            EntrySpaceForCars.Text = ferryDetails.MaxCars.ToString();
            CarsView.ItemsSource = ferryDetails.Cars;
            GuestsView.ItemsSource = ferryGuests;
        }

        private async void BtnUpdateFerry_Clicked(object sender, EventArgs e)
        {
            if (FerryPicker.SelectedItem != null && ferryDetails != null)
            {
                HttpClient client = new HttpClient();
                int guestCount = Convert.ToInt32(EntryGuests.Text);
                int carCount = Convert.ToInt32(EntryCars.Text);
                int guestPrice = Convert.ToInt32(EntryPricePerGuest.Text);
                int carPrice = Convert.ToInt32(EntryPricePerCar.Text);
                int spaceForGuest = Convert.ToInt32(EntrySpaceForGuests.Text);
                int spaceForCars = Convert.ToInt32(EntrySpaceForCars.Text);
                Ferry updateFerry = (Ferry)FerryPicker.SelectedItem;
                updateFerry.PricePerGuest = guestPrice;
                updateFerry.PricePerCar = carPrice;
                updateFerry.MaxGuests = spaceForGuest;
                updateFerry.MaxCars = spaceForCars;
                await client.PostAsJsonAsync<Ferry>("http://localhost:5298/api/v1/Ferry/UpdateFerry", updateFerry);
                EntryTotalPrice.Text = CalcTotalPrice(guestCount, guestPrice, carCount, carPrice);
            }
        }

        private string CalcTotalPrice(int guestCount, int guestPrice, int carCount, int carPrice)
        {
            return ((guestCount * guestPrice) + (carCount * carPrice)).ToString();
        }

        private async Task<List<Guest>> AllGuestsOnFerry()
        {
            List<Guest> guests = new List<Guest>();
            HttpClient client = new HttpClient();
            foreach (Car car in ferryDetails.Cars)
            {
                Car carDetails = await client.GetFromJsonAsync<Car>($"http://localhost:5298/api/v1/Car/GetCarDetails/{car.Id}");
                guests.AddRange(carDetails.Guests);
            }
            guests.AddRange(ferryDetails.Guests);
            return guests;
        }
    }
}
