using ExamenAPP_KevinR.ViewModels;

namespace ExamenAPP_KevinR.Views;

public partial class BienvenidaPage : ContentPage
{
    private UserViewModel _viewModel;
    public BienvenidaPage()
    {
		InitializeComponent();
        _viewModel = new UserViewModel();
        BindingContext = _viewModel;
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        int fixedUserId = 3;
        var user = await _viewModel.VmConsultarUsuarioPorID(fixedUserId);

        if (user != null)
        {
            if (user.UserName == TxtUserName.Text)
            {
                
                await Navigation.PushAsync(new PreguntaPage());
            }
            else
            {
                await DisplayAlert("Error", "Nombre de usuario o contraseña incorrectos.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Usuario no encontrado.", "OK");
        }
    }

    private void SwshowPassword_Toggled(object sender, ToggledEventArgs e)
    {
        TxtPassword.IsPassword = true;

        if (SwshowPassword.IsToggled)
        {
            TxtPassword.IsPassword = false;
        }
    }
    
}