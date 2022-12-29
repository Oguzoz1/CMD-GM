using System;
using System.Collections.Generic;
using System.Text;
using Tools;

namespace MainThread
{
    public class Purchase
    {
        private bool _purchaseComplete = false;
        private ConsoleColor colour;
        private string[] options;

        public bool PurchaseBuilding(string[] options, ConsoleColor color)
        {
            colour = color;
            this.options = options;

            string answer = ReturnAnswer(options);
            InvokePurchaseSequenceUponSelection(options, answer);
            return _purchaseComplete;
        }
        private string ReturnAnswer(string [] options)
        {
            Option option = new Option();

            option.DisplayOptions(options, "Type the number.", "Option Selected!", colour);
            string answer = option.ReturnSelectedOption();
            while (String.IsNullOrEmpty(answer))
                answer = option.ReturnSelectedOption();
            return answer;
        }
        private void InvokePurchaseSequenceUponSelection(string[] options, string answer)
        {
            foreach (string item in options)
            {
                if (item == answer)
                {
                    string name = "MainThread." + item.RemoveWhite();
                    object instanceObject = name.GetInstance();
                    Building building = Buildings.Build((Building)instanceObject);

                    if (GameManager.Money >= building.BuildingPrice()) PurchaseSuccess(building);
                    else PurchaseFail();
                }
            }
        }
        //Create a purchasable object which will be base class for anything that is purchasable.
        private void PurchaseSuccess(Building x)
        {
            Displayer.Write("Price For: ", colour);
            Displayer.Write(x.name, ConsoleColor.Yellow);
            Displayer.Write(" is: ", colour);
            Displayer.Write(x.BuildingPrice().ToString(), ConsoleColor.Yellow);
            Displayer.WriteLine("\nType 'Buy' to purchase, 'Back' to show options or Type 'Skip' to skip buy phase", colour);

            string nextInput = Console.ReadLine();
            if (nextInput == "Buy")
            {
                GameManager.ChangeMoney(-x.BuildingPrice());
                GameManager.s_Buildings.Add(x);
                GameManager.RestartSequence(); //B
                _purchaseComplete = true;
            }
            else if (nextInput == "Skip") GameManager.RestartSequence(); //B
            else if (nextInput == "Back") PurchaseBuilding(options, colour);
            else { Displayer.WriteLine("ENTERED A TYPO", ConsoleColor.Red); PurchaseSuccess(x); }
        }
        private void PurchaseFail()
        {
            Displayer.WriteLine("\nYOU DON'T HAVE ENOUGH MONEY", ConsoleColor.Red);
            PurchaseBuilding(options, colour);
        }
    }
}