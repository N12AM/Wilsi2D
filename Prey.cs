using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilsi2D
{
      class Prey
      {
            public int X{get; set;}
            public int Y{get; set;}
            public int MoveDirection1D { get; set; }

/*            public float prey_growth_rate = 0.0009f;
            public float prey_death_rate = 0.0001f;*/
            public float prey_growth_rate { get; set; }
            public float prey_death_rate { get; set; }

            public float Growth { get; set; }
            public float LifeSpan { get; set; }
/*            public int HalfLife { get; set; }
*/
            private Random random;


            /// <summary>
            /// 
            /// </summary>
            public Prey()
            {
                  random = new Random();
                  X = 0;
                  Y = 0;
                  Growth = 0;
                  LifeSpan = 4f;
                  prey_growth_rate = 0.02f;
/*                  prey_growth_rate = 0.02f;
*/                  prey_growth_rate = RandomValue(1,4,0.01f);
/*                  prey_death_rate = 0.004f;
*/                  prey_death_rate = RandomValue(2, 4, 0.01f);
                  /*HalfLife = 4;*/

            }

            private float RandomValue(int min, int max, float decimaMultiplier)
            {
                  return (float)random.Next(min, max) * decimaMultiplier;
            }
      }
}
