using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Wilsi2D
{
      public partial class Form1 : Form
      {
            private List<Prey> preys = new List<Prey>();
            private List<Predator> predators = new List<Predator>();

            private Random random;

            private TraitSetup traitSetup;
            private int directionMultiplier = 10;
            private float deltaTime;
            private float timeSpent;
            private float timedelay;

            private int screenWidth;
            private int screenHeight;

            private int[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            private int[] y = { 1, 2, 3, 4, 1, 2, 12, 5, 3, 8};

            private bool startGame = false;

            public Form1()
            {
                  InitializeComponent();
                        
                  InitializeVariables();
                  /*TraitSetup  ts =  new TraitSetup();*/
    
                  Timer.Interval = 1000 / traitSetup.updatesPerSecond;
                  Timer.Tick += Form1_Load;
                  Timer.Start();
/*                  StartSimulation();
*/
                  chart1.Series[0].ChartType = SeriesChartType.Line;
                  chart1.Series[0].IsValueShownAsLabel = true;
                  chart1.Series[1].ChartType = SeriesChartType.Line;
                  chart1.Series[1].IsValueShownAsLabel = true;
            }

            private void Form1_Load(object sender, System.EventArgs e)
            {
                  /*               pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateGraphics);
                                   this.Controls.Add(pictureBox1);*/

                  /*MovePrey();*/

                  MoveAgents();
                  timeSpent += deltaTime;

                  //show the predator-prey graph
/*                  chart1.Series[0].Points.DataBindXY(x, y);
*/
                  // update the screen
                  pictureBox1.Invalidate();
            }
            
            private void UpdateGraphics(object sender, PaintEventArgs e)
            {
                  Graphics canvas = e.Graphics;
                  Brush brush, brush1;
                  brush = Brushes.Black;
                  brush1 = Brushes.Red;

                  for(int i = 0; i<preys.Count(); i++)
                  {
                        canvas.FillEllipse(brush, new Rectangle(preys[i].X, preys[i].Y, 
                              this.traitSetup.agentWidth, traitSetup.agentHeight));
                  }

                  for (int i = 0; i < predators.Count(); i++)
                  {
                        canvas.FillEllipse(brush1, new Rectangle(predators[i].X, predators[i].Y,
                              this.traitSetup.agentWidth, traitSetup.agentHeight));
                  }
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

                  startGame = true;

                  StartSimulation();
            }

            private void StartSimulation()
            {
                  // initially clear the list
                  preys.Clear();
                  predators.Clear();

                  for(int i =0; i<10; i++)
                  {
                        Prey p = new Prey();
                        p.X = random.Next(0 + 100, screenWidth - 100);
                        p.Y = screenHeight / 2;
                        preys.Add(p);
                  }

                  for (int i = 0; i <2 ; i++)
                  {
                        Predator p = new Predator();
                        p.X = random.Next(0 + 100, screenWidth - 100);
                        p.Y = screenHeight / 2;
                        predators.Add(p);
                  }
            }

            private void MoveAgents()
            {
                  if (!startGame)
                  {
                        return;
                  }
                  timedelay += deltaTime;
                  if (timedelay >= 1)
                  {
                        timedelay = 0;

                        // set random direction for each prey
                        for (int i = 0; i < preys.Count(); i++)
                        {
                              preys[i].MoveDirection1D = RandomDirecion1D();
                        }
                        for (int i = 0; i < predators.Count(); i++)
                        {
                              predators[i].moveDirection1D = RandomDirecion1D();
                        }

                        chart1.Series[0].Points.AddXY((int)timeSpent, preys.Count());
                        chart1.Series[1].Points.AddXY((int)timeSpent, predators.Count());
                  }

                  PreyMovement();
                  PredatorMovement();

                  if(preys.Count() == 0 && predators.Count() == 0)
                  {
                        startGame = false;
                  }
            }

            private void PreyMovement()
            {
                  // set random 1D movement for prey
                  for (int i = 0; i < preys.Count(); i++)
                  {
                        int position = preys[i].X;

                        if (position >= pictureBox1.Size.Width - 10)
                        {
                              preys[i].MoveDirection1D = -1;
                        }
                        else if (position <= 0 + 10)
                        {
                              preys[i].MoveDirection1D = 1;
                        }

                        preys[i].X +=  preys[i].MoveDirection1D;

                        //if the growth rate is 1 then add a new prey
                        if(preys[i].Growth >= 1)
                        {
                              Prey p = new Prey();
                              p.X = random.Next(0 + 100, screenWidth - 100);
                              p.Y = screenHeight / 2;
                              preys.Add(p);

                              // set growth to 0
                              preys[i].Growth = 0;
                        }
                        
                        else
                        {
                              preys[i].Growth += preys[i].prey_growth_rate;
                              preys[i].prey_growth_rate = preys[i].prey_growth_rate;                        }

                        if (preys[i].LifeSpan > 0)
                        {
                              preys[i].LifeSpan -= preys[i].prey_death_rate;
                        }
                        else
                        {
                              preys.Remove(preys[i]);
                        }
                  }
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

                        predators[i].X +=  predators[i].moveDirection1D;

                        //if the growth rate is 1 then add a new prey
                        if (predators[i].Growth >= 1 && preys.Count()>0)
                        {
                              Predator p = new Predator();
                              p.X = random.Next(0 + 100, screenWidth - 100);
                              p.Y = screenHeight / 2;
                              predators.Add(p);

                              predators[i].Growth = 0;
                        }
                        else
                        {
                              predators[i].Growth += predators[i].predator_growth_rate;
                              predators[i].predator_growth_rate = predators[i].predator_growth_rate;// * (float)preys.Count()/10 /** (1 / (float)(Math.Exp(preys.Count()) + 1))*/;
                        }
                        Console.WriteLine("pd: " + predators[i].LifeSpan);

                        // check lifetime
                        if (predators[i].LifeSpan > 0)
                        {
                              predators[i].LifeSpan -= predators[i].predator_death_rate;
                              // check and eat prey
                              try
                              {
                                    EatPrey(position, predators[i]);
                                    //naturally decrease lifetime due to not eating
                                    predators[i].LifeSpan -= 0.02f;
                              }
                              catch (Exception iex)
                              {
                                    //ignore
                              }
                        }
                        else
                        {
                              predators.Remove(predators[i]);
                        }
                  }
            }

            private void EatPrey(int predatorPositionX, Predator predator)
            {
                  for(int i = 0; i< preys.Count(); i++)
                  {
                        // using offset 5 for better accuracy
                        if(preys[i].X <= predatorPositionX+1 && preys[i].X >= predatorPositionX-1)
                        {
                              Console.WriteLine("eating");
                              preys.Remove(preys[i]);

                              if(predator.LifeSpan < 9f)
                              {
                                    predator.LifeSpan += 0.01f;
                              }
                              // only eat 1 at a time
                              return;
                        }
                  }
            }

            private float LotkaVolterraPrey(Prey prey)
            {
                  float prey_growth_dx = (prey.prey_growth_rate * preys.Count()) 
                                          - (prey.prey_death_rate * preys.Count()) 
                                          * predators.Count();
                  Console.WriteLine("py_growthRate =" + prey_growth_dx);
                  return prey_growth_dx;
            }
            private float LotkaVolterraPredator(Predator predator)
            {
                  float predator_growth_dy = (predator.predator_growth_rate * preys.Count() * predators.Count())
                                          - (predator.predator_death_rate * predators.Count());
                  Console.WriteLine("pd_growthRate =" + predator_growth_dy);

                  return predator_growth_dy;
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
                  timedelay += deltaTime;
                  if(timedelay >= 1)
                  {
                        timedelay = 0;
                        directionMultiplier = RandomDirecion1D();

                        // set random direction for each prey

                        for (int i = 0; i < preys.Count(); i++)
                        {
                              preys[i].MoveDirection1D = RandomDirecion1D();
                        }
                  }

                  // set random 1D movement for prey
                  for (int i = 0; i < preys.Count(); i++)
                  {
                        int position = preys[i].X;

                        if (position >= pictureBox1.Size.Width - 10)
                        {
                              preys[i].MoveDirection1D = -1;
                        }
                        else if (position <= 0 + 10)
                        {
                              preys[i].MoveDirection1D = 1;
                        }

                        preys[i].X += 10 * preys[i].MoveDirection1D;

                  }
/*                        Console.WriteLine((int)timeSpent);
*/


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

            private void chart1_Click(object sender, EventArgs e)
            {

            }
      }
}
