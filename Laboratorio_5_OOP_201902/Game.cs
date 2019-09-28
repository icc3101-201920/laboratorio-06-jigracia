using Laboratorio_5_OOP_201902.Cards;
using Laboratorio_5_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Laboratorio_5_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private List<SpecialCard> captains;
        private Board boardGame;
        Random random = new Random();
        private bool endGame;
        private int turn;
        Visualization visualization;
        List<string> changeCardOptionList = new List<string> { "Change Card", "FIGHT TILL DEATH" };
        string readyOrNot = "Change 3 cards or READY TO FIGHT????:";

        //Constructor
        public Game()
        {
            
            visualization = new Visualization();
            decks = new List<Deck>();
            captains = new List<SpecialCard>();
            players = new Player[] { new Player(), new Player() };
            int rndnumber = random.Next(0,2);
            activePlayer = players[rndnumber];
            boardGame = new Board();
            endGame = false;
            turn = 0;
            players[0].Board = boardGame;
            players[1].Board = boardGame;
            AddDecks();
            AddCaptains();
        }
        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public List<SpecialCard> Captains
        {
            get
            {
                return this.captains;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0 && players[1].LifePoints > 0)
            {
                return 1;
            }
            else if (players[1].LifePoints == 0 && players[0].LifePoints > 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public void Play()
        {
            for (int readyPlayers = 0; readyPlayers < 2; readyPlayers++)
            {
                visualization.ShowProgramMessage("Player " + (activePlayer.Id + 1) + " Please choose your Deck and Captain");
                visualization.printSeparator();
                visualization.ShowDecks(decks);
                int deckNumberAnswer = visualization.GetUserInput(decks.Count, false);
                visualization.printSeparator();
                activePlayer.Deck = decks[deckNumberAnswer];
                activePlayer.FirstHand();
                visualization.ShowCaptains(captains);
                visualization.printSeparator();
                int captainNumberAnswer = visualization.GetUserInput(Captains.Count, false);
                visualization.printSeparator();
                activePlayer.ChooseCaptainCard(Captains[captainNumberAnswer]);
                visualization.ShowHand(activePlayer.Hand);
                visualization.printSeparator();
                visualization.ShowListOptions(changeCardOptionList, readyOrNot);
                visualization.printSeparator();
                int answerReadyOrNot = visualization.GetUserInput(changeCardOptionList.Count, false);
                
                if (answerReadyOrNot == 0)
                {
                    visualization.printSeparator();
                    visualization.ShowProgramMessage("Player " + (activePlayer.Id + 1) + " change your cards");
                    visualization.printSeparator();

                    for (int i = 0; i < 3; i++)
                    {
                        visualization.ShowHand(activePlayer.Hand);
                        visualization.printSeparator();
                        visualization.ShowProgramMessage("Input the number of the cards you want to change (Max 3). Input -1 to stop " + i);
                        int loopAnswer = visualization.GetUserInput(activePlayer.Hand.Cards.Count, true);
                        visualization.printSeparator();
                        if (loopAnswer == -1)
                        {
                            i = 4;
                        }
                        else
                        {
                            activePlayer.ChangeCard(loopAnswer);
                        }
                    }

                    visualization.printSeparator();
                    visualization.ShowProgramMessage("Done those all your changes. Now youre ready to fight!!!");
                }
                visualization.printSeparator();
                visualization.ShowProgramMessage("OK Thats all you need Player " + (activePlayer.Id + 1) + " now ... PREPARE TO FIGHT TILL YOUR LAST BREATH");
                visualization.printSeparator();
                visualization.ShowProgramMessage("Press any key to clear console and change player");
                Console.ReadKey();
                visualization.ClearConsole();
                if (activePlayer.Id == players[0].Id)
                {
                    activePlayer = players[1];
                }
                else
                {
                    activePlayer = players[0];
                }
            }
            
        }
        public void AddDecks()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"\Files\Decks.txt";
            StreamReader reader = new StreamReader(path);
            int deckCounter = 0;
            List<Card> cards = new List<Card>();


            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string [] cardDetails = line.Split(",");

                if (cardDetails[0] == "END")
                {
                    decks[deckCounter].Cards = new List<Card>(cards);
                    deckCounter += 1;
                }
                else
                {
                    if (cardDetails[0] != "START")
                    {
                        if (cardDetails[0] == nameof(CombatCard))
                        {
                            cards.Add(new CombatCard(cardDetails[1], (EnumType) Enum.Parse(typeof(EnumType),cardDetails[2]), cardDetails[3], Int32.Parse(cardDetails[4]), bool.Parse(cardDetails[5])));
                        }
                        else
                        {
                            cards.Add(new SpecialCard(cardDetails[1], (EnumType)Enum.Parse(typeof(EnumType), cardDetails[2]), cardDetails[3]));
                        }
                    }
                    else
                    {
                        decks.Add(new Deck());
                        cards = new List<Card>();
                    }
                }

            }
            
        }
        public void AddCaptains()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"\Files\Captains.txt";
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] cardDetails = line.Split(",");
                captains.Add(new SpecialCard(cardDetails[1], (EnumType)Enum.Parse(typeof(EnumType), cardDetails[2]), cardDetails[3]));
            }
        }
    }
}
