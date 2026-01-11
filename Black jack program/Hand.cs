using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_jack_program
{
    internal class Hand
    {
        public List<Card> givenCardsList = new List<Card>();

        public void AddCard(Card shuffledCard)
        {
            givenCardsList.Add(shuffledCard);
        }

        public int GetTotalValue()
        {
            int totalValue = 0;
            int totalAces = 0;  

            foreach (Card card in givenCardsList)
            {
                totalValue += card.Value;//add all the cards 
                if(card.Value == 11)//if we have an ace
                {
                    totalAces++;
                }
            }
            while(totalValue > 21 && totalAces > 0)//if we have ace and our total is over make the ace value 1 
            {
                totalValue -= 10;
                totalAces--;
              
            }

            return totalValue;
        }

        public void DisplayHand()
        {
            foreach (Card card in givenCardsList)
            {
                Console.Write($"{card.Value} of {card.Suit}");
            }
            Console.WriteLine($"Total: {GetTotalValue()}");
        }

        public void ResetHand()
        {
            givenCardsList.Clear();
        }
    }
}
