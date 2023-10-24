using System;
using System.Linq;

namespace TicTacToe.Models
{
    public class Game
    {
        public Cell[,] Grid { get; }
        public Player CurrentPlayer { get; private set; }
        public bool IsGameOver { get; private set; }

        private Player _playerX;
        private Player _playerO;

        public Game()
        {
            _playerX = new Player("X");
            _playerO = new Player("O");
            CurrentPlayer = _playerX;
            Grid = new Cell[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Grid[i, j] = new Cell();
                }
            }
        }

        public void PlayTurn(int x, int y)
        {
            if (IsGameOver) throw new InvalidOperationException("Game is already over!");
            if (x < 0 || x >= 3 || y < 0 || y >= 3) throw new ArgumentOutOfRangeException("Invalid cell coordinates!");

            Grid[x, y].ClaimCell(CurrentPlayer);

            if (CheckForWinner())
            {
                IsGameOver = true;
                return;
            }

            // Switch player
            CurrentPlayer = CurrentPlayer == _playerX ? _playerO : _playerX;
        }

        private bool CheckForWinner()
        {
            // Check rows, columns and diagonals
            for (int i = 0; i < 3; i++)
            {
                if (Enumerable.Range(0, 3).All(j => Grid[i, j].IsOccupied && Grid[i, j].OccupyingPlayer == CurrentPlayer) ||
                    Enumerable.Range(0, 3).All(j => Grid[j, i].IsOccupied && Grid[j, i].OccupyingPlayer == CurrentPlayer))
                {
                    return true;
                }
            }

            if (Enumerable.Range(0, 3).All(i => Grid[i, i].IsOccupied && Grid[i, i].OccupyingPlayer == CurrentPlayer) ||
                Enumerable.Range(0, 3).All(i => Grid[i, 2 - i].IsOccupied && Grid[i, 2 - i].OccupyingPlayer == CurrentPlayer))
            {
                return true;
            }

            return false;
        }
    }
}
