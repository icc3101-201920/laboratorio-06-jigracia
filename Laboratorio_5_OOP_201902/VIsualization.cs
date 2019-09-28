using System;
using System.Collections.Generic;
using System.Text;
using Laboratorio_5_OOP_201902.Cards;

namespace Laboratorio_5_OOP_201902
{
     public class Visualization
    {
        public void printSeparator()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }
        public void ShowHand(Hand hand)
        {
            Console.WriteLine("Your Hand:");
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].GetType().Name==nameof(CombatCard))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    CombatCard auxCombatCard = hand.Cards[i] as CombatCard;
                    Console.Write("| (" + i + ") " + hand.Cards[i].Name + " (" + hand.Cards[i].Type + ")  AttackPoints: ("+auxCombatCard.AttackPoints+ ") |");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("| (" + i + ") " + hand.Cards[i].Name + " (" + hand.Cards[i].Type + ") |");
                }

                Console.ResetColor();
            }
            Console.WriteLine("");
        }
        public void ShowDecks(List<Deck> decks)
        {
            Console.WriteLine("Select a Deck to play with");
            for (int i = 0; i < decks.Count; i++)
            {
                Console.WriteLine("("+i+") Deck "+i);
            }
        }
        public void ShowCaptains(List<SpecialCard> captains)
        {

            Console.WriteLine("Select a captain to represent your team");
            for (int i = 0; i < captains.Count; i++)
            {
                Console.WriteLine("("+i+") "+captains[i].Name+" / Effect: "+captains[i].Effect);
            }
        }
        public int GetUserInput(int maxInput, bool stopper = false)
        {
            if (stopper==false)
            {
                while (true)
                {
                    string auxAnswer = Console.ReadLine();
                    int answer;
                    if (int.TryParse(auxAnswer, out answer))
                    {
                        answer = Convert.ToInt32(auxAnswer);
                        if (0 <= answer && answer <= maxInput-1)
                        {
                            return answer;
                        }
                        else
                        {
                            ConsoleError("Enter a valid answer");
                        }
                    }
                    else
                    {
                        ConsoleError("Please enter a number");
                    }
                }
            }
            else
            {
                while (true)
                {
                    string auxAnswer = Console.ReadLine();
                    int answer;
                    if (int.TryParse(auxAnswer, out answer))
                    {
                        answer = Convert.ToInt32(auxAnswer);
                        if (answer==-1)
                        {
                            return answer;
                        }
                        if (0 <= answer && answer <= maxInput - 1)
                        {
                            return answer;
                        }
                        else
                        {
                            ConsoleError("Enter a valid answer");
                        }
                    }
                    else
                    {
                        ConsoleError("Please enter a number");
                    }
                }
            }

            
        }
        public void ConsoleError(string errorMessage)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();

        }
        public void ShowProgramMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void ShowListOptions(List<string> options, string message = null)
        {
            if (message is null)
            {
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine("("+i+") "+options[i]);
                }
            }
            else
            {
                Console.WriteLine(message);
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine("(" + i + ") " + options[i]);
                }
            }
        }
        public void ClearConsole()
        {
            Console.Clear();
        }

    }
}
