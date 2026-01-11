using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_jack_program
{
    internal class Player
    {
        public string Name { get; }
        public Hand PlayerHand { get; }
        public Player(string name)
        {          
            Name = name;
            PlayerHand = new Hand();
        }
       
    }
}
