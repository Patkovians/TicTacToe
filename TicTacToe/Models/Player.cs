using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Models
{
    public class Player
    {
        public string Symbol { get; }

        public Player(string symbol)
        {
            Symbol = symbol ?? throw new ArgumentNullException(nameof(symbol));
        }
    }
}
