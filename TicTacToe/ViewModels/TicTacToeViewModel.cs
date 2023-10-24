using System;
using System.Windows.Input;
using Xamarin.Forms;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class TicTacToeViewModel : BindableObject
    {
        private readonly Game _game;
        private string[,] _gridSymbols;

        public ICommand PlayCommand { get; }

        public TicTacToeViewModel()
        {
            _game = new Game();
            PlayCommand = new Command<Tuple<int, int>>(PlayCell);
            _gridSymbols = new string[3, 3];
        }

        public string GetCellSymbol(int x, int y)
        {
            return _gridSymbols[x, y];
        }

        private void PlayCell(Tuple<int, int> cellPosition)
        {
            int x = cellPosition.Item1;
            int y = cellPosition.Item2;

            if (!_game.Grid[x, y].IsOccupied)
            {
                _game.PlayTurn(x, y);
                _gridSymbols[x, y] = _game.Grid[x, y].OccupyingPlayer.Symbol;

                // Notify the view that the grid state has changed
                OnPropertyChanged(nameof(_gridSymbols));

                if (_game.IsGameOver)
                {
                    // Handle end of game (you can show an alert, reset the game, etc.)
                }
            }
        }
    }
}
