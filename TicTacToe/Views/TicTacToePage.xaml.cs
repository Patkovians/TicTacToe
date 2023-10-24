using System;
using Xamarin.Forms;
using TicTacToe.ViewModels;

namespace TicTacToe.Views
{
    public partial class TicTacToePage : ContentPage
    {
        public TicTacToePage()
        {
            InitializeComponent();
            SetupGameGrid();
        }

        private void SetupGameGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var button = new Button
                    {
                        BackgroundColor = Color.LightGray,
                        TextColor = Color.Black,
                        FontSize = 24
                    };
                    button.Clicked += OnGridButtonClicked;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    GameGrid.Children.Add(button);
                }
            }
        }

        private void OnGridButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);

            // Assuming you will have a PlayCommand in the ViewModel to handle the logic
            var viewModel = BindingContext as TicTacToeViewModel;
            if (viewModel?.PlayCommand.CanExecute(new Tuple<int, int>(row, col)) == true)
            {
                viewModel.PlayCommand.Execute(new Tuple<int, int>(row, col));

                // Update the button's text based on the ViewModel's game state
                button.Text = viewModel.GetCellSymbol(row, col);
            }
        }
    }
}
