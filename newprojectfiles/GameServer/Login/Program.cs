using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GameServer
{
if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                Application.EnableVisualStyles();
                Application.Run(new Login.Form1());
                game.Run();
            }
        }
    }
#endif
}

