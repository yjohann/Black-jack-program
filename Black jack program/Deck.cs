using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_jack_program
{
    internal class Deck
    {
        public List<Card> CreateDeck()
        {
            List<Card> deck = new List<Card>();
            string[] suits = { "Clubs", "Hearts", "Spades", "Diamonds" };
            int numOfDecks = 3;
            for(int x = 0; x < numOfDecks; x++)
            {
                foreach (string suit in suits)
                {
                    for (int i = 1; i <= 13; i++)
                    {
                        int value = i;
                        if (i > 10)
                        {
                            value = 10;
                        }
                        if (i == 1)
                        {
                            value = 11;
                        }
                        deck.Add(new Card(suit, value));//create an instance of the cards
                    }
                }
            }           
            return deck;
        }

        public void Shuffle(List<Card> shuffledCards)
        {
            Random random = new Random();

            for(int x = shuffledCards.Count - 1;x > 0; x--)//fisher yates shuffle 
            {
                int cardToMove = random.Next(x + 1);

                Card tempHolder = shuffledCards[cardToMove];
                shuffledCards[cardToMove] = shuffledCards[x];
                shuffledCards[x] = tempHolder;

            }
        }

        public List<Card>GetShuffledDeck()
        {
            List<Card> finalDeck = CreateDeck();
            Shuffle(finalDeck);
            return finalDeck;
        }

    }
}
