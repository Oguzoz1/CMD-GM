using System;
using System.Collections.Generic;
using System.Text;

namespace MainThread
{
    public class Population
    {
        public int population { get; private set; } = 0;
        public int populationIncrease { get; private set; } = 3;

        public void UpdatePopulation()
        {
            population += populationIncrease;
        }
    }
}