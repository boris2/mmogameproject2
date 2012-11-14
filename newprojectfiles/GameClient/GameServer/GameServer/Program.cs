using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GameServer
{
#if WINDOWS || XBOX
    static class Program
    {
        
        static void Main(string[] args)
        {
            Login log;
            using (Game1 game = new Game1())
            {
                log = new Login();
                Application.EnableVisualStyles();
                Application.Run(new Form1(log));
                if (log.accepted)
                    game.Run();
            }
        }
    }
#endif
}

