using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// $G$ SFN-012 (+6) Bonus: Graphic

// $G$ SFN-999 (-3) you should not show a message box each computer move

namespace Ex02_Othelo_UI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ////Application.Run(new GameSettingsForm());
            Application.Run(new GameMainForm());
        }
    }
}
