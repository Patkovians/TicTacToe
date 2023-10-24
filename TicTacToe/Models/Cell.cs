using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TicTacToe.Models
{
    public class Cell
    {
        public Player OccupyingPlayer { get; private set; }
        public bool IsOccupied => OccupyingPlayer != null;

        public void ClaimCell(Player player)
        {
            if (IsOccupied) throw new InvalidOperationException("Cell is already occupied!");
            OccupyingPlayer = player;
        }
    }
}
