using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_5_OOP_201902
{
     public class VIsualization
    {

        public void ShowHand(Hand hand)
        {
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].GetType().Name==nameof(Cards.CombatCard))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("| (" + i + ") " + hand.Cards[i].Name + " (" + hand.Cards[i].Type + ")  AttackPoints: ("+ (Cards.CombatCard)hand.Cards[i].+ ") |");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                
            }
            Console.ResetColor();
        }
        public void ShowDecks(List<Deck> decks)
        {
            Console.WriteLine("Select a Deck to play with");
            for (int i = 0; i < decks.Count; i++)
            {
                Console.WriteLine("("+i+") Deck "+i);
            }
        }
        public void ShowCaptains(List<Cards.SpecialCard> captains)
        {

            Console.WriteLine("Select a captain to represent your team");
            for (int i = 0; i < captains.Count; i++)
            {
                Console.WriteLine("("+i+") "+captains[i].Name+" / Effect: "+captains[i].Effect);
            }
        }
        public void GetUserInput(int maxInput, bool stopper = false)
        {
            while (true)
            {
                string auxAnswer = Console.ReadLine();
                int answer;
                if (int.TryParse(auxAnswer, out answer))
                {
                    answer = Convert.ToInt32(auxAnswer);

                    if (stopper == false)
                    {
                        if (0 >= answer && answer >= maxInput)
                        {
                            ConsoleError("Enter a valid answer");
                        }
                    }
                    else
                    {
                        if (-1 >= answer && answer >= maxInput)
                        {
                           ConsoleError("Enter a valid answer");
                        }
                    }
                }
                else
                {
                    ConsoleError("Please enter a number");
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
            Console.ForegroundColor = ConsoleColor.Blue;
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
