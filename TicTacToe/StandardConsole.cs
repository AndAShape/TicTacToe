using System;
using Domain.Game.Abstract;

namespace App
{
    public class StandardConsole : IInputOutput
    {
        public string Input() => Console.ReadLine();

        public void Output(string text) => Console.WriteLine(text);
    }
}