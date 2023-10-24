using System;
using System.Collections.Generic;
using TicTacToe.ViewModels;
using TicTacToe.Views;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
