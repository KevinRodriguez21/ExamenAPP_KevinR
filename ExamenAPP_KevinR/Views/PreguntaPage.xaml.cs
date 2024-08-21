using ExamenAPP_KevinR.ViewModels;
using ExamenAPP_KevinR.Models;

namespace ExamenAPP_KevinR.Views;

public partial class PreguntaPage : ContentPage
{
    AskViewModel? vm;
    public PreguntaPage()
	{
		InitializeComponent();

        BindingContext = vm = new AskViewModel();

        LoadUserList();

        LoadStatusList();
    }

    private async void LoadUserList()
    {
        LstUser.ItemsSource = await vm.VmGetUserAsync();
    }
    private async void LoadStatusList()
    {
        LstStatus.ItemsSource = await vm.VmGetAskStatusAsync();
    }


    private async void BtnAdd_Clicked(object sender, EventArgs e)
    {
        var answer = await DisplayAlert("Confirmation Required", "Adding new user. Are you sure?", "Yes", "No");

        if (answer)
        {
            
            User SelectedUser = LstUser.SelectedItem as User;
            AskStatus SelectedAsk = LstStatus.SelectedItem as AskStatus;

            bool R = await vm.VmAddAsk(DateTime.Parse(TxtDate.Text.Trim()), TxtAsk.Text.Trim(), bool.Parse(TxtStrike.Text.Trim()), TxtUrlImage.Text.Trim(), TxtAskDetail.Text.Trim(), SelectedUser.UserId, SelectedAsk.AskStatusId);

            if (R)
            {
                await DisplayAlert(":)", "Ask added!!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Error: ", "OK");
            }

        }
    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}