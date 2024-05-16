using DTO.Model;
using System.Net.Http.Json;

namespace MauiGUI;

public partial class Booking : ContentPage
{
    List<Entry> guestNameEntries = new List<Entry>();
    List<Entry> guestSexEntries = new List<Entry>();
    int numberOfguests = 1;
    public Booking()
	{
		InitializeComponent();
        PopulateFerryPicker();
        guestNameEntries.Add(entryGuestName);
        guestSexEntries.Add(entryGuestSex);
    }

    private async void PopulateFerryPicker()
    {
        HttpClient client = new HttpClient();
        List<Ferry> ferries = await client.GetFromJsonAsync<List<Ferry>>("http://localhost:5298/api/v1/Ferry/GetAllFerries");
        FerryPicker.ItemsSource = ferries;
        FerryPicker.SelectedIndex = 0;
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        lblNumberPlate.IsVisible = chkUsingCar.IsChecked;
        entryNumberPlate.IsVisible = chkUsingCar.IsChecked;
    }

    private void btnAddPerson_Clicked(object sender, EventArgs e)
    {
        if (numberOfguests < 5)
        {
            Label lblName = new Label();
            lblName.Text = "Name";
            Entry entryName = new Entry();
            guestNameEntries.Add(entryName);
            Label lblSex = new Label();
            lblSex.Text = "Sex";
            Entry entrySex = new Entry();
            guestSexEntries.Add(entrySex);
            
            if (numberOfguests >= 3)
            {
                vslGuests2.Add(lblName);
                vslGuests2.Add(entryName);
                vslGuests2.Add(lblSex);
                vslGuests2.Add(entrySex);
            } else
            {
                vslGuests.Add(lblName);
                vslGuests.Add(entryName);
                vslGuests.Add(lblSex);
                vslGuests.Add(entrySex);
            }
            numberOfguests++;
        }
    }

    private async void btnBook_Clicked(object sender, EventArgs e)
    {
        if (FerryPicker.SelectedItem != null)
        {
            HttpClient client = new HttpClient();
            Ferry ferry = (Ferry)FerryPicker.SelectedItem;
            int ferryId = ferry.Id;
            Ferry ferryDetails = await client.GetFromJsonAsync<Ferry>($"http://localhost:5298/api/v1/Ferry/GetFerryDetails/{ferryId}");
            if (entryGuestName.Text != null && entryGuestSex.Text != null && ferryDetails.Guests.Count + guestNameEntries.Count <= ferryDetails.MaxGuests )
            {
                if (chkUsingCar.IsChecked == true && entryNumberPlate.Text.Length == 7 && ferryDetails.Cars.Count < ferryDetails.MaxCars)
                {
                    Car newCar = new Car(entryNumberPlate.Text, ferryId);
                    newCar.Guests = new List<Guest>();
                    await client.PostAsJsonAsync<Car>("http://localhost:5298/api/v1/Car/AddCar", newCar);
                    List<Car> cars = await client.GetFromJsonAsync<List<Car>>("http://localhost:5298/api/v1/Car/GetAllCars");
                    int newCarId = cars.Last().Id;
                    if (newCarId != 0)
                    {
                        for (int i = 0; i < guestNameEntries.Count; i++)
                        {
                            if (guestNameEntries[i].Text != null && guestSexEntries[i].Text != null)
                            {
                                Guest newGuest = new Guest(guestNameEntries[i].Text, guestSexEntries[i].Text, newCarId, null);
                                await client.PostAsJsonAsync<Guest>("http://localhost:5298/api/v1/Guest/AddGuest", newGuest);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < guestNameEntries.Count; i++)
                    {
                        if (guestNameEntries[i].Text != null && guestSexEntries[i].Text != null)
                        {
                            Guest newGuest = new Guest(guestNameEntries[i].Text, guestSexEntries[i].Text, null, ferryId);
                            await client.PostAsJsonAsync<Guest>("http://localhost:5298/api/v1/Guest/AddGuest", newGuest);
                        }
                    }
                }
                lblBookingResponse.Text = "Booking successful";
                
            } else
            {
                lblBookingResponse.Text = "Booking unsuccessful";
            }
        } else
        {
            lblBookingResponse.Text = "Booking unsuccessful";
        }
        lblBookingResponse.IsVisible = true;
    }
}