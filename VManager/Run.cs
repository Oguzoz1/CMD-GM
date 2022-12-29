using System;
using Tools;

namespace MainThread
{
    class Run
    {
        static void Main(string[] args)
        {
            Execute();
        }
        static void Execute()
        {
            GameManager.Update();
        }

       
    }
}