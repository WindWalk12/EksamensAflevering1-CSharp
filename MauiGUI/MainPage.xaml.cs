using DTO.Model;
using System.Net.Http.Json;
namespace MauiGUI
{
    public partial class MainPage : ContentPage
    {
        bool updated = false;
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
            FerryPicker.SelectedIndex = 0;
        }

        protected async override void OnAppearing()
        {
            if (updated)
            {
                HttpClient client = new HttpClient();
                Ferry pickedFerry = (Ferry)FerryPicker.SelectedItem;
                Ferry ferryDetails = await client.GetFromJsonAsync<Ferry>($"http://localhost:5298/api/v1/Ferry/GetFerryDetails/{pickedFerry.Id}");
                List<Guest> ferryGuests = await AllGuestsOnFerry(ferryDetails);
                UpdateFields(ferryGuests, ferryDetails);
            }
        }

        private async void FerryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            Ferry pickedFerry = (Ferry)FerryPicker.SelectedItem;
            Ferry ferryDetails = await client.GetFromJsonAsync<Ferry>($"http://localhost:5298/api/v1/Ferry/GetFerryDetails/{pickedFerry.Id}");
            List<Guest> ferryGuests = await AllGuestsOnFerry(ferryDetails);
            UpdateFields(ferryGuests, ferryDetails);
        }

        private async void BtnUpdateFerry_Clicked(object sender, EventArgs e)
        {
            if (FerryPicker.SelectedItem != null)
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

        private async Task<List<Guest>> AllGuestsOnFerry(Ferry ferryDetails)
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

        public void UpdateFields(List<Guest> ferryGuests, Ferry ferryDetails)
        {
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
            updated = true;
        }

        private async void btnDeleteCar_Clicked(object sender, EventArgs e)
        {
            if (CarsView.SelectedItem != null)
            {
                HttpClient client = new HttpClient();
                Car selectedCar = (Car)CarsView.SelectedItem;
                Car carDetails = await client.GetFromJsonAsync<Car>($"http://localhost:5298/api/v1/Car/GetCarDetails/{selectedCar.Id}");
                await client.PostAsJsonAsync<List<Guest>>("http://localhost:5298/api/v1/Guest/DeleteGuests", carDetails.Guests);
                await client.PostAsJsonAsync<Car>("http://localhost:5298/api/v1/Car/DeleteCar", carDetails);
                Ferry pickedFerry = (Ferry)FerryPicker.SelectedItem;
                Ferry ferryDetails = await client.GetFromJsonAsync<Ferry>($"http://localhost:5298/api/v1/Ferry/GetFerryDetails/{pickedFerry.Id}");
                List<Guest> ferryGuests = await AllGuestsOnFerry(ferryDetails);
                UpdateFields(ferryGuests, ferryDetails);
            }
        }

        private async void btnDeleteGuest_Clicked(object sender, EventArgs e)
        {
            if (GuestsView.SelectedItem != null)
            {
                HttpClient client = new HttpClient();
                Guest selectedGuest = (Guest)GuestsView.SelectedItem;
                await client.PostAsJsonAsync<Guest>("http://localhost:5298/api/v1/Guest/DeleteGuest", selectedGuest);
                Ferry pickedFerry = (Ferry)FerryPicker.SelectedItem;
                Ferry ferryDetails = await client.GetFromJsonAsync<Ferry>($"http://localhost:5298/api/v1/Ferry/GetFerryDetails/{pickedFerry.Id}");
                List<Guest> ferryGuests = await AllGuestsOnFerry(ferryDetails);
                UpdateFields(ferryGuests, ferryDetails);
            }
        }
    }
}
