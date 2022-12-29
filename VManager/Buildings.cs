using System;
using System.Linq;
using Tools;

namespace MainThread
{
    public static class Buildings
    {
        public static Building Build(Building x)
        {
            var tempList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(domainAssembly => domainAssembly.GetTypes())
                .Where(type => typeof(Building).IsAssignableFrom(type)).ToArray();

            foreach (var item in tempList)
            {
                if (x.GetType() == item)
                {
                    x.isPurchased = true;
                    x.NumberOfThisBuilding++;
                    return x;
                }
            }
            if (x == null) Debug.Info("\n BUILD IS NULL!",Debug.LineNumber());
            return null;
        }
    }
    #region Building Classes
    public class WoodCutter : Building
    {
        public WoodCutter()
        {
            name = "Wood Cutter";
        }

    }
    public class CoalMine : Building
    {

        public CoalMine()
        {
            name = "Coal Mine";
        }
    }
    public class Farm : Building
    {
        public Farm()
        {
            name = "Farm";
            
        }
    }
    #endregion
}