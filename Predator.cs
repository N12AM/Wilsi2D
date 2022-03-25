using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wilsi2D
{

      class Predator
      {
            public int X { get; set; }
            public int Y { get; set; }
            public int moveDirection1D { get; set; }

/*            public float predator_growth_rate = 0.0001f;
            public float predator_death_rate = 0.0004f;*/
            public float predator_growth_rate { get; set; }
            public float predator_death_rate { get; set;}

            public float Growth { get; set; }
            public float LifeSpan { get; set; }
            /*public int HalfLife { get; set; }*/

            private Random random;


            public Predator()
            {
                  random = new Random();

                  X = 0;
                  Y = 0;
                  Growth = 0;
                  LifeSpan = 9f;
                  predator_growth_rate = 0.0085f;
                  predator_growth_rate = RandomValue(6, 12, 0.001f);
                  predator_death_rate = 0.004f;
                  predator_death_rate = RandomValue(2, 5, 0.001f);
                  /*HalfLife = 5;*/
            }

            private float RandomValue(int min, int max, float decimaMultiplier)
            {
                  return (float)random.Next(min, max) * decimaMultiplier;
            }
      }
}
