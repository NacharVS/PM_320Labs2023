﻿using WeaponGame.Interfaces;

namespace WeaponGameConsole
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
