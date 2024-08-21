using ExamenAPP_KevinR.Views;

namespace ExamenAPP_KevinR
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BienvenidaPage());
        }
    }
}
