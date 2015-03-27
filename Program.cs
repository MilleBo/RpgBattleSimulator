using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgBattleSimulator
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var game = new RpgBattleSimulatorGame())
            {
                game.Run();
            }
        }
    }
}
