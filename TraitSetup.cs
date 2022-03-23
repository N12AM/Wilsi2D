using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilsi2D
{
      public class TraitSetup
      {
            public int preyHeight { get; set; }
            public int preyWidth { get; set; }
            public int updatesPerSecond { get; set; }

            public TraitSetup()
            {
                  preyHeight = 10;
                  preyWidth = 10;

                  // how many times in 1000 miliseconds (1 second) should the update happen
                  updatesPerSecond = 30;
            }
      }
}
