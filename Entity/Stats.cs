using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;

namespace RpgBattleSimulator.Entity
{
    class Stats
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Speed { get; set; }
    }
}
