using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HovlandWarGame
{
	class Program : War
	{
		static void Main(string[] args)
		{
			bool running = true;


			//Starts Client
			while (running)
			{
				Console.WriteLine(
					"1. Start New Game" + Environment.NewLine +
					"2. Exit" + Environment.NewLine
					);



				//Starts Game
				string userEntry = Console.ReadLine();

				switch (userEntry)
				{

					//Initializes game and shuffles deck.
					case "1":
						War gdeck = new War();
						gdeck.shuffle();
						while (running)
						{

							//User input for game commands.
							Console.WriteLine(
								"\n1. Play Next Round" + Environment.NewLine +
								"2. Display Current Scores" + Environment.NewLine +
								"3. Exit" + Environment.NewLine);

							string gameEntry = Console.ReadLine();

							switch (gameEntry)
							{
								case "1":
									gdeck.PlayNextCards();
									gdeck.DetermineRoundWinner();
									Console.WriteLine();
									break;
								case "2":
									gdeck.PlayerScores();
									Console.WriteLine();
									break;
								case "3":
									gdeck.DetermineGameWinner();
									running = false;
									break;
							}
						}
						break;
					case "2":
						running = false;
						break;


				}

			}
		}
	}
}
