using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Tools;

namespace MainThread
{
    public class GameManager
    {
        //public static GameManager Instance
        //{
        //    get
        //    {
        //        if (s_instance == null)
        //        {
        //            Console.WriteLine("GameManager is null");
        //        }
        //        return s_instance;
        //    }
        //    set
        //    {
        //        s_instance = value;
        //    }
        //}
        public static Population population = new Population();

        private static GameManager s_instance;
        public static List<Building> s_Buildings = new List<Building>();
        public static float Money { get; private set; } = 100;
        public static int Turn { get; private set; } = 0;

        private static TimeElapse _time = new TimeElapse();

        #region Global Methods
        public static void Update()
        {
            _time.DisplayEveryXMs("Time Passes...\n\n", 2000, 3);
            Debug.Info("AAAA", Debug.LineNumber());
            UpdateCycle();
            DisplayCycle();
            PurchaseCycle();
        }
        public static void ChangeMoney(float money)
        {
            Money += money;
        }
        public static void RestartSequence() => Update();
        #endregion
        #region Cycle Update Methods
        private static void UpdateCycle()
        {
            Turn++;
            UpdateBuildings();
            UpdatePopulation();
        }
        private static void UpdateBuildings()
        {
            foreach (Building building in s_Buildings)
            {
                if (building.isPurchased) building.UpdateBuilding();
            }
        }
        private static void UpdatePopulation()
        {
            population.UpdatePopulation();
        }
        #endregion
        #region Display Methods
        private static void DisplayCycle()
        {
            DisplayTurnInfo();
            DisplayBuildingInfo();
        }
        private static void DisplayTurnInfo()
        {
            Displayer.WriteLine("Turn: " + Turn.ToString(), ConsoleColor.Blue);
            Displayer.WriteLine("Turn Income: " + TotalIncome().ToString(), ConsoleColor.Green);
            Displayer.WriteLine("Turn Population Increase: " + population.populationIncrease.ToString(), ConsoleColor.Green);
            Console.WriteLine("");
            Displayer.WriteLine("Current:", ConsoleColor.Blue);
            Displayer.WriteLine("Current Population:" + population.population.ToString(), ConsoleColor.Green);
            Displayer.WriteLine("Current Money:" + Money.ToString(), ConsoleColor.Green);
        }
        private static void DisplayBuildingInfo()
        {
            foreach(Building building in s_Buildings)
            {
                if (building.isPurchased) building.DisplayInfo();
            }
        }
        #endregion
        #region Purchase Methods
        private static void PurchaseCycle()
        {
            PurchaseProductionBuilding();
        }
        private static void PurchaseProductionBuilding()
        {
            Purchase purchase = new Purchase();
            string[] options = new string[3] { "Wood Cutter", "Farm", "Coal Mine" }; //Find a way to get this automatically updated.
            while (true)
            {
                if (purchase.PurchaseBuilding(options, ConsoleColor.Magenta)) break;
                else continue;
            }
        }
        #endregion
        #region Calculate Methods
        private static float TotalIncome()
        {
            float totalIn = 0;
            foreach (var item in s_Buildings.Where(a => a.isPurchased)) totalIn += item.NetIncome();
            return totalIn;
        }
        #endregion
    }
}