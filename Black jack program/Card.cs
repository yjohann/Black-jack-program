using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_jack_program
{
    internal class Card
    {
        public string Suit { get; } 
        public int Value {  get; }

        public Card(string cardType, int cardNumber )
        {
            Suit = cardType;
            Value = cardNumber;
        }

    }
}
