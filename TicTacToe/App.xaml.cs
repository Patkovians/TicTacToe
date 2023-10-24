using TicTacToe.Views;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new TicTacToePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
