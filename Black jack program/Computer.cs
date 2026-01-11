using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_jack_program
{
    internal class Computer
    {
        public Hand ComputerHand { get; }

        public Computer()
        {
            ComputerHand = new Hand();
        }

        public void ComputersTurn(List<Card> newDeck)
        {
            Console.WriteLine("Dealer's turn\n");
         
            while (ComputerHand.GetTotalValue() < 17)//check if computer cards are below 16 they need to draw a card
            {
                Card drawnCard = newDeck[0];//get card from the shuffled deck 
                newDeck.RemoveAt(0);

                ComputerHand.AddCard(drawnCard);

                Console.WriteLine($"Dealer draws: {drawnCard.Value} of {drawnCard.Suit}");
                Console.WriteLine($"Dealer's new total: {ComputerHand.GetTotalValue()}");
            }

            if(ComputerHand.GetTotalValue() > 21 )
            {
                Console.WriteLine($"Dealer busts!");//if dealer cards go over 21
            }
            else
            {
                Console.WriteLine($"Dealer stands!");// if dealer cards value is 17 or more
            }
        }

        public void ShowFirstCard()
        {
            Card firstCard = ComputerHand.givenCardsList[0];
            Console.WriteLine($"Dealer's first card: {firstCard.Value} of {firstCard.Suit} and the hidden card is for later.");
        }
    }
}
