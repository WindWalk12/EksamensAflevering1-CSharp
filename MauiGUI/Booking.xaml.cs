using DTO.Model;
using System.Net.Http.Json;

namespace MauiGUI;

public partial class Booking : ContentPage
{
	public Booking()
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

    private void FerryPicker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        lblNumberPlate.IsVisible = chkUsingCar.IsChecked;
        EntryNumberPlate.IsVisible = chkUsingCar.IsChecked;
    }
}