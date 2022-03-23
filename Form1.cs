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

                  /*MovePrey();*/

                  MoveAgents();
                  timeSpent += deltaTime;

                  pictureBox1.Invalidate();
            }
            
            private void UpdateGraphics(object sender, PaintEventArgs e)
            {
                  Graphics canvas = e.Graphics;
                  Brush brush, brush1, brush2;
                  brush = Brushes.Black;
                  brush1 = Brushes.Red;
                  brush2 = Brushes.Blue;
                  /*TraitSetup traitSetup = new TraitSetup();*/
/*                  preys[2].X += 100;
*/

/*                  canvas.FillEllipse(brush, new Rectangle(preys[0].X,
                                            preys[0].Y,
                                            this.traitSetup.preyWidth, traitSetup.preyHeight));*/

                  for(int i = 0; i<100; i++)
                  {
                        canvas.FillEllipse(brush, new Rectangle(preys[i].X, preys[i].Y, 
                              this.traitSetup.agentWidth, traitSetup.agentHeight));
                  }

                  for (int i = 0; i < 10; i++)
                  {
                        canvas.FillEllipse(brush1, new Rectangle(predators[i].X, predators[i].Y,
                              this.traitSetup.agentWidth, traitSetup.agentHeight));
                  }

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
                  */
            }

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
                  directionMultiplier = RandomDirecion1D();

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

                  for(int i =0; i<100; i++)
                  {
                        Prey p = new Prey();
                        p.X = random.Next(0 + 100, screenWidth - 100);
                        p.Y = screenHeight / 2;
                        preys.Add(p);
                  }

                  for (int i = 0; i < 10; i++)
                  {
                        Predator p = new Predator();
                        p.X = random.Next(0 + 100, screenWidth - 100);
                        p.Y = screenHeight / 2;
                        predators.Add(p);
                  }

                  /*                  Prey p2 = new Prey();
                                    p2.X = screenWidth/2;
                                    p2.Y = screenHeight/2;
                                    preys.Add(p2);*/


            }

            private void MoveAgents()
            {
                  interval++;


                  timedelay += deltaTime;
                  if (timedelay >= 1)
                  {
                        timedelay = 0;
/*                        directionMultiplier = RandomDirecion1D();
*/
                        // set random direction for each prey

                        for (int i = 0; i < preys.Count(); i++)
                        {
                              preys[i].moveDirection1D = RandomDirecion1D();
                        }
                        for (int i = 0; i < predators.Count(); i++)
                        {
                              predators[i].moveDirection1D = RandomDirecion1D();
                        }
                  }

                  PreyMovement();
                  PredatorMovement();
            }

            private void PreyMovement()
            {

                  // set random 1D movement for prey

                  for (int i = 0; i < preys.Count(); i++)
                  {
                        int position = preys[i].X;

                        if (position >= pictureBox1.Size.Width - 10)
                        {
                              preys[i].moveDirection1D = -1;
                        }
                        else if (position <= 0 + 10)
                        {
                              preys[i].moveDirection1D = 1;
                        }

                        preys[i].X += 10 * preys[i].moveDirection1D;

                  }
                  Console.WriteLine((int)timeSpent);

            }

            private void PredatorMovement()
            {

                  // set random 1D movement for prey

                  for (int i = 0; i < predators.Count(); i++)
                  {
                        int position = predators[i].X;

                        if (position >= pictureBox1.Size.Width - 10)
                        {
                              predators[i].moveDirection1D = -1;
                        }
                        else if (position <= 0 + 10)
                        {
                              predators[i].moveDirection1D = 1;
                        }

                        predators[i].X += 10 * preys[i].moveDirection1D;

                  }
                  Console.WriteLine((int)timeSpent);

            }

            private int RandomDirecion1D()
            {
                  int randomValue = random.Next(0, 2);

                  if (randomValue == 0)
                  {
                        return 1;
                  }

                  return -1;
            }

            private void MovePrey()
            {
                  interval++;


                  timedelay += deltaTime;
                  if(timedelay >= 1)
                  {
                        timedelay = 0;
                        directionMultiplier = RandomDirecion1D();

                        // set random direction for each prey

                        for (int i = 0; i < preys.Count(); i++)
                        {
                              preys[i].moveDirection1D = RandomDirecion1D();
                        }
                  }



                  // set random 1D movement for prey

                  for (int i = 0; i < preys.Count(); i++)
                  {
                        int position = preys[i].X;

                        if (position >= pictureBox1.Size.Width - 10)
                        {
                              preys[i].moveDirection1D = -1;
                        }
                        else if (position <= 0 + 10)
                        {
                              preys[i].moveDirection1D = 1;
                        }

                        preys[i].X += 10 * preys[i].moveDirection1D;

                  }
                        Console.WriteLine((int)timeSpent);



                  /*                  int position = preys[0].X;

                                    if (position >= pictureBox1.Size.Width - 10)
                                    {
                                          directionMultiplier = -1;
                                    }
                                    else if(position <= 0 + 10)
                                    {
                                          directionMultiplier = 1;
                                    }

                                    preys[0].X += 10 * directionMultiplier;

                                    Console.WriteLine((int)timeSpent);*/

            }

      }
}
