using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HovlandWarGame
{
    class War : CardDeck
    {

        private CardDeck gameDeck;

        //Create vars for each player and their hand
        private int p1Hand;
        private int p2Hand;

        //Create a bool to check if the cards have been compared yet.
        private bool compared;

        //Create ints for round wins per player.
        private int player1Wins;
        private int player2Wins;
        private int playerTies = 0;


        //Shuffles deck.
        public void shuffle() {
            ShuffleDeck();
        }


        public int PlayNextCards()
        {

            //Each player draws a card and we assign it to their hand variable.
            p1Hand = getOneCard();
            p2Hand = getOneCard();


            //Display which cards each player recieved. 
            Console.WriteLine("\n\tPlayer one drew a " + getCardPip(p1Hand));
            Console.WriteLine("\tPlayer two drew a " + getCardPip(p2Hand));




            return 0;
        }

        protected internal int DetermineRoundWinner()
        {

            compared = false;

            while(compared == false)
            {

                //The CardDeck is set up where each suit takes up 13 spaces in the array. [0] is empty.
                //So [1] - [13] are Spades ascending, [14] - [26] are Hearts ascending, and so on.

                //To compare hands subtract the number of the last highest card, of the last suit.
                //0 for spades, -12 for hearts, -26 for diamonds, and -39 for clubs.
                //In this way, we only have to compare hands for numbers 1-13. 


            //Player 1
            if(p1Hand > 13 && p1Hand < 27)
                {
                    p1Hand -= 12;
                }else if(p1Hand > 26 && p1Hand < 40)
                {
                    p1Hand -= 26;
                }else if(p1Hand > 39 && p1Hand < 53)
                {
                    p1Hand -= 39 ;
                }
                else if(p1Hand == 0)
                {
                    Console.WriteLine("\nNo more cards are left. Exit to see results.");
                }            


            //Player 2
            if(p2Hand > 13 && p2Hand < 27)
                {
                    p2Hand -= 13;
                }else if(p2Hand > 26 && p2Hand < 39)
                {
                    p2Hand -= 26;
                }else if(p2Hand > 38 && p2Hand < 52)
                {
                    p2Hand -= 38;
                }
                else if (p2Hand == 0)
                {
                    Console.WriteLine("\nNo more cards are left. Exit to see results.");
                }


                //Debugging subtraction math:
                //Console.WriteLine("\tPlayer one drew a " + p1Hand);
                //Console.WriteLine("\tPlayer two drew a " + p2Hand);


                //Determining the winner
                //Compare the two, print result, and update playerwins.
                if (p1Hand > p2Hand)
                {
                    player1Wins++;
                    compared = true;
                    Console.WriteLine("\tPlayer one wins!");

                }else if (p1Hand < p2Hand)
                {
                    player2Wins++;
                    compared = true;
                    Console.WriteLine("\tPlayer two wins!");

                }else if (p1Hand == p2Hand)
                {
                    playerTies++;
                    compared = true;
                    Console.WriteLine("\tIt's a tie!");

                }
                else
                {
                    Console.WriteLine("\tAn error occured");
                    compared = false;
                }
            }
            return 0;
        }
        
        //Displays players scores.
        public int PlayerScores()
        {
            Console.WriteLine("\tPlayer One has " + player1Wins + " points");
            Console.WriteLine("\tPlayer Two has " +  player2Wins + " points");
            return 0;
        }

        //Determines the game's winner.
        public string DetermineGameWinner()
        {
            Console.WriteLine("\nResults: \n");
            Console.WriteLine("\tPlayer one had: " + player1Wins + " round wins.");
            Console.WriteLine("\tPlayer two had: " + player2Wins + " round wins.");
            Console.WriteLine("\tThere were: " + playerTies + " ties. \n");

            if(player1Wins > player2Wins)
            {
                Console.WriteLine("Player one has won the game!");
            }else if(player2Wins > player1Wins)
            {
                Console.WriteLine("Player two has won the game!");
            }else if(player2Wins == player1Wins)
            {
                Console.WriteLine("The game has ended in a tie.");
            }

            Console.WriteLine("\nPress RETURN to exit.");
            Console.ReadLine();

            return "";
        }


    }



}
