using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wilsi2D
{
      public partial class Form1 : Form
      {
            private List<Prey> preys = new List<Prey>();
            private List<Predator> predators = new List<Predator>();
            private List<Food> foods = new List<Food>();

            private Random random;

            private TraitSetup traitSetup;
            private int directionMultiplier = 10;
            private float deltaTime;
            private float timeSpent;
            private float timedelay;

            private int interval;
            private int screenWidth;
            private int screenHeight;


            public Form1()
            {
                  InitializeComponent();

                  InitializeVariables();
                  /*TraitSetup  ts =  new TraitSetup();*/
    
                  Timer.Interval = 1000 / traitSetup.updatesPerSecond;
                  Timer.Tick += Form1_Load;
                  Timer.Start();
                  StartSimulation();

            }

            private void Form1_Load(object sender, System.EventArgs e)
            {
 /*               pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateGraphics);
                  this.Controls.Add(pictureBox1);*/

                  MovePrey();
                  timeSpent += deltaTime;

                  pictureBox1.Invalidate();
            }
            
            private void UpdateGraphics(object sender, PaintEventArgs e)
            {
                  Graphics canvas = e.Graphics;
                  Brush brush, brush1, brush2;
                  brush = Brushes.Black;
                  brush1 = Brushes.Blue;
                  brush2 = Brushes.Red;
                  /*TraitSetup traitSetup = new TraitSetup();*/
/*                  preys[2].X += 100;
*/

                  canvas.FillEllipse(brush, new Rectangle(preys[0].X,
                                            preys[0].Y,
                                            this.traitSetup.preyWidth, traitSetup.preyHeight));

/*                  canvas.FillEllipse(brush1, new Rectangle(preys[1].X,
                                            preys[1].Y,
                                            traitSetup.preyWidth, traitSetup.preyHeight));
                  canvas.FillEllipse(brush2, new Rectangle(preys[2].X,
                                            preys[2].Y,
                                            traitSetup.preyWidth, traitSetup.preyHeight));
*/

/*                  Console.WriteLine(preys.Count());
                  Console.WriteLine(preys[2].X +" "+preys[1].Y+" "+preys[0].Y);
                  Console.WriteLine(preys[2].Y +" "+preys[1].Y+" "+preys[0].Y);*/
/*                  MovePrey();
*/            }

            /// <summary>
            /// Initialize the variables before we can use them
            /// </summary>
            private void InitializeVariables()
            {
                  random = new Random();
                  screenHeight = pictureBox1.Size.Height;
                  screenWidth = pictureBox1.Size.Width;

                  traitSetup = new TraitSetup();
                  deltaTime = 1 / (float)(1000 / traitSetup.updatesPerSecond);
                  directionMultiplier = RandomDirecion2D();

            }

            private void StartSimulation()
            {
                
/*                  preys.Clear();
                  Prey p = new Prey();
                  p.X = 32;
                  p.Y = 32;             
                  preys.Add(p);
                  
                  Prey p1 = new Prey();
                  p1.X = 52;
                  p1.Y = 52;                  
                  preys.Add(p1);*/
                  
                  Prey p2 = new Prey();
                  p2.X = screenWidth/2;
                  p2.Y = screenHeight/2;
                  preys.Add(p2);


            }

            private void MovePrey()
            {
                  /*TraitSetup ts = new TraitSetup();*/
                  /*Console.WriteLine(preys[2].X);*/
                  interval++;


                  timedelay += deltaTime;
                  if(timedelay >= 1)
                  {
                        timedelay = 0;
                        directionMultiplier = RandomDirecion2D();
                  }


                  int position = preys[0].X;
                  
                  if (position >= pictureBox1.Size.Width - 10)
                  {
                        /*Console.WriteLine("decrease X !!! ");*/
                        /*preys[2].X--;*/
                        directionMultiplier = -1;
                        /*preys[0].X -= 15 * 10;*/

                  }
                  else if(position <= 0 + 10)
                  {
                        /*Console.WriteLine("increase X !!! ");*/
                        /*preys[2].X++;*/
                        directionMultiplier = 1;
                        /*preys[0].X += 15 * 10;*/

                  }
                  else
                  {
                        /*preys[2].X+=10;*/

                  }
/*                        preys[2].X += directionMultiplier;
                        preys[1].X += directionMultiplier;*/
                  preys[0].X += 10 * directionMultiplier;



                  /*Console.WriteLine((float)(interval/60));*/
                  Console.WriteLine((int)timeSpent);

            }

            private int RandomDirecion2D()
            {
                  int randomValue = random.Next(0, 2);

                  if(randomValue == 0)
                  {
                        return 1;
                  }

                  return -1;
            }
      }
}
