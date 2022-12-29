using System;
using System.Collections.Generic;
using System.Text;
using Tools;

namespace MainThread
{
    public class Building
    {
        public string name = "";
        public float profit = 5;
        public float deficit = 2;
        public int NumberOfThisBuilding = 0;
        public bool isPurchased = false;

        private float _price = 50f;

        #region Update Methods
        public void UpdateBuilding()
        {
            UpdateMoney();
        }
        private void UpdateMoney()
        {
            GameManager.ChangeMoney(NetIncome());

        }
        #endregion
        #region Display and Public Methods
        public void DisplayInfo()
        {
            Displayer.WriteLine("\n" + name, ConsoleColor.Blue);
            Displayer.WriteLine("Building Count: " + NumberOfThisBuilding, ConsoleColor.Cyan);
            Displayer.WriteLine("Income: " + NetIncome(), ConsoleColor.Cyan);

            //how to display info from derived classes
        }
        public float NetIncome()
        {
            return (profit - deficit) * NumberOfThisBuilding;
        }
        public float BuildingPrice()
        {
            return _price * NumberOfThisBuilding;
        }
        #endregion
    }
}