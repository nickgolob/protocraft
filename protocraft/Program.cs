using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace protocraft
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Protocraft game = new Protocraft())
            {
                game.Run();
            }
        }
    }


}

