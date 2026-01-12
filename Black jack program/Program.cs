using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Black_jack_program
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Game of BlackJack starting!");
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Deck deck = new Deck();
            List<Card> deckToUse =  deck.GetShuffledDeck();

            Player player = new Player("Player 1");
            Computer computer = new Computer();

            bool play = true;

            while( play )
            {
                Console.Clear();
                if (deckToUse.Count < 10) // If less than 10 cards left, get a fresh deck
                {
                    Console.WriteLine("Reshuffling the deck...");
                    deckToUse = deck.GetShuffledDeck();
                }
                Console.WriteLine($"Your avaialable balance:{player.MoneyBalance}\n");

                
                bool validInpt = false;
                int currentBet = 0;

                while( !validInpt )
                {
                    Console.Write($"Place your bet: ");
                    if (int.TryParse(Console.ReadLine(),out currentBet) && currentBet > 0 && currentBet <= player.MoneyBalance)
                    {
                        validInpt = true;   
                    }
                    else
                    {
                        Console.WriteLine("Invalid bet! You must bet more than 0 and no more than you have.");
                    }
                    
                   
                }
                player.PlayerHand.ResetHand();
                computer.ComputerHand.ResetHand();

                for (int i = 0; i < 2; i++)
                {
                    // Give to player cards
                    player.PlayerHand.AddCard(deckToUse[0]);
                    deckToUse.RemoveAt(0);

                    // Give to computer cards
                    computer.ComputerHand.AddCard(deckToUse[0]);
                    deckToUse.RemoveAt(0);
                }
                Console.Write("Your cards: ");
                player.PlayerHand.DisplayHand();

                Console.Write("Dealer Hand: ");
                computer.ShowFirstCard();

                bool playersTurn = true;
                while (playersTurn)
                {
                    Console.Write($"Press H for hit and S for Stand: ");
                    string inpt1 = Console.ReadLine().ToUpper();

                    if (inpt1 == "H")
                    {
                        player.PlayerHand.AddCard(deckToUse[0]);
                        deckToUse.RemoveAt(0);
                        Console.Write("Your cards: ");
                        player.PlayerHand.DisplayHand();
                        if (player.PlayerHand.GetTotalValue() > 21)
                        {

                            Console.WriteLine("Bust! You went over 21");
                            computer.ComputerHand.DisplayHand();
                            playersTurn = false;
                        }
                    }
                    else if (inpt1 == "S")
                    {
                        playersTurn = false;
                    }
                }

                if (player.PlayerHand.GetTotalValue() <= 21)
                {
                    Console.WriteLine($"Shwoing dealer's cards: ");//show the hidden card
                    computer.ComputerHand.DisplayHand();
                    computer.ComputersTurn(deckToUse);//computer moves
                }
                int playerScore = player.PlayerHand.GetTotalValue();
                int computerScore = computer.ComputerHand.GetTotalValue();

                if (playerScore > 21)
                {
                    Console.WriteLine($"Dealer wins!");
                    player.MoneyBalance -= currentBet;
                }
                else if (computerScore > 21 || playerScore > computerScore)
                {
                    Console.WriteLine("You win!");
                    player.MoneyBalance += currentBet;
                }
                else if (playerScore < computerScore)
                {
                    Console.WriteLine($"Dealer wins!");
                    player.MoneyBalance -= currentBet;
                }
                else
                {
                    Console.WriteLine($"It's a tie! ");
                }

                if(player.MoneyBalance == 0)
                {
                    Console.WriteLine($"You are out of money!");
                    play = false; 
                }
                else
                {
                    Console.WriteLine("\nWould you like to play another round? (Y/N)");
                    string inpt2 = Console.ReadLine().ToUpper();
                    if (inpt2 != "Y")
                    {
                        play = false;
                        Console.WriteLine("Goodbye!");
                    }
                }

                   
            }
              

           

                       
        }
    }
}
