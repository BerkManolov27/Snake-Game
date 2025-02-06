using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Food
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public char Symbole { get; set; }

        private char[] foodSymbols = new char[] { '#', '@', '%', '*', '&' };

        public Food(int windowHeight, int windowWidth)
        {
            Random random = new Random();

            this.XCoordinate = random.Next(2, windowHeight);
            this.YCoordinate = random.Next(2, windowWidth);

            this.Symbole = foodSymbols[random.Next(0, foodSymbols.Length)];
        }
    }


}

