using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace LoopAnimation
{
    public partial class Form1 : Form
    {
        //Creates Boolean values for the paint event
        bool printTitle = false;
        bool printInstructions = false;
        bool printPlane = false;
        bool printBall = false;
        bool printExplosion = false;

        //Creates two sound players
        SoundPlayer themeSong = new SoundPlayer(Properties.Resources.John_Williams___Star_Wars_Main_Theme_FULL_);
        SoundPlayer explosion = new SoundPlayer(Properties.Resources._69230__lex0myko1__giant_explosion);
        SoundPlayer torpedo = new SoundPlayer(Properties.Resources._317843__vumseplutten1709__whistler1);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;//Changes the layout of the background image

            this.Size = new Size(720, 615);//Changes the size of the form

            printTitle = true;//Calls print title
            Refresh();//Refreshes to call the paint event
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            printInstructions = true;//Calls print instructions
            Refresh();//Refreshes to call the paint event

            printPlane = true;//Calls print plane
            Refresh();//Refreshes to call the paint event

            printBall = true;//Calls print ball
            Refresh(); //Refreshes to call the paint event

            printExplosion = true;//Calls print explosion
            Refresh();//Refreshes to call the paint event
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Font drawFont = new Font("Consolas", 19, FontStyle.Bold);//Creates a font type
            Font scrollFont = new Font("Arial", 20, FontStyle.Bold);//Creates a font type
            SolidBrush whiteBrush = new SolidBrush(Color.White);//Creates a white brush
            SolidBrush greenBrush = new SolidBrush(Color.Green);//Creates a green brush
            Pen greenPen = new Pen(Color.Green, 2);//Creates a green pen
            Pen blackPen = new Pen(Color.Black, 2);//Creates a black pen
            Pen whitePen = new Pen(Color.White, 2);//Creates a white pen
            Pen redPen = new Pen(Color.Red, 20);//Creates a red pen

            if (printTitle)
            {
                e.Graphics.DrawString("CLICK ON THE SCREEN TO RECIEVE YOUR MISSON", drawFont, whiteBrush, 25, 250);//Prints title to sreen
                themeSong.PlayLooping();//Plays the theme song on loop
            }
            printTitle = false;//Makes print title false and unable to be called

            if (printInstructions)
            {
                for (int i = this.Height; i >= -400; i--)//Loops until i is equal to -400
                {
                    e.Graphics.Clear(Color.Black);//Clears the screen and makes it black

                    //Writes instructions to screen
                    e.Graphics.DrawString("The battle station is heavily shielded and carries a", scrollFont, greenBrush, 25, i);
                    e.Graphics.DrawString("firepower greater than half the star fleet.", scrollFont, greenBrush, 25, i + 40);
                    e.Graphics.DrawString("It's defenses are centered around a large scale", scrollFont, greenBrush, 25, i + 80);
                    e.Graphics.DrawString("attack. A small one man fighter should be able to", scrollFont, greenBrush, 25, i + 120);
                    e.Graphics.DrawString("penetrate the outer defense. The approach will not", scrollFont, greenBrush, 25, i + 160);
                    e.Graphics.DrawString("be easy. The target area is only two meters wide.", scrollFont, greenBrush, 25, i + 200);
                    e.Graphics.DrawString("It's a small thermal port which leads to the reactor.", scrollFont, greenBrush, 25, i + 240);
                    e.Graphics.DrawString("Only a direct hit will set off a chain reaction.", scrollFont, greenBrush, 25, i + 280);
                    e.Graphics.DrawString("You will have to use proton torpedoes. Good Luck!", scrollFont, greenBrush, 25, i + 320);
                    e.Graphics.DrawString("Following is a visual representation of the attack. ", scrollFont, greenBrush, 25, i + 400);

                    Thread.Sleep(10);//Delays for 10 milliseconds
                }
            }
            printInstructions = false;//Makes print instructions false and unable to be called upon
            
            if (printPlane)
            {
                themeSong.Stop();//Stops playing the theme song

                for (int i = this.Width; i >= 345; i--)
                {
                    e.Graphics.Clear(Color.Black);//Clears the screen and makes it black

                    //Draws the death star outer shell
                    e.Graphics.DrawEllipse(greenPen, 130, 120, 450, 450);
                    e.Graphics.DrawLine(blackPen, 345, 121, 365, 121);

                    //Draws the port leading to the core
                    e.Graphics.DrawLine(greenPen, 345, 121, 345, 350);
                    e.Graphics.DrawLine(greenPen, 365, 121, 365, 350);

                    //Draws the death star core
                    e.Graphics.DrawEllipse(greenPen, 329, 345, 50, 50);
                    e.Graphics.DrawLine(blackPen, 345, 347, 365, 347);
                    e.Graphics.DrawLine(blackPen, 340, 346, 370, 346);

                    //Draws the x-wing approaching the death star
                    e.Graphics.DrawPie(whitePen, i, 100, 20, 20, 0, 15);

                    Thread.Sleep(10);//Delays for 10 milliseconds
                }
            }
            printPlane = false;//Makes print plane false and unable to be called upon

            if (printBall)
            {
                //Creates integer variables
                int x = 345;
                int y = 100;

                torpedo.Play();//Plays torpedo sound

                for (int i = 115; i <= 360; i++)//loops untill i equals 360
                {
                    e.Graphics.Clear(Color.Black);//Clears the screen and makes it black

                    //Draws the shell of the death star
                    e.Graphics.DrawEllipse(greenPen, 130, 120, 450, 450);
                    e.Graphics.DrawLine(blackPen, 345, 121, 365, 121);

                    //Draws the port to the core of the death star
                    e.Graphics.DrawLine(greenPen, 365, 121, 365, 350);
                    e.Graphics.DrawLine(greenPen, 345, 121, 345, 350);

                    //Draws the core of the death star
                    e.Graphics.DrawEllipse(greenPen, 329, 345, 50, 50);
                    e.Graphics.DrawLine(blackPen, 345, 347, 365, 347);
                    e.Graphics.DrawLine(blackPen, 340, 346, 370, 346);

                    //Draws the x-wing and torpedo 
                    e.Graphics.FillEllipse(whiteBrush, 349, i, 10, 10);
                    e.Graphics.DrawPie(whitePen, x, y, 20, 20, 0, 15);

                    Thread.Sleep(10);//Delays for 10 milliseconds

                    //Subtracts 1 from each variable
                    x--;
                    y--;
                }
            }
            printBall = false;//Makes printball false and unable to be called

            if (printExplosion)
            {
                //Declares 4 variables and gives them a value
                int x1 = 355;
                int x2 = 355;
                int y1 = 370;
                int y2 = 370;

                explosion.Play();//Plays a sound

                for (int i = 0; i <= 200; i++)//Loops 200 times
                {
                    e.Graphics.Clear(Color.Black);//Clears the screen and makes it black

                    //Draws the death star
                    e.Graphics.DrawEllipse(greenPen, 130, 120, 450, 450);
                    e.Graphics.DrawLine(blackPen, 345, 121, 365, 121);

                    //Draws the path to the core
                    e.Graphics.DrawLine(greenPen, 345, 121, 345, 350);
                    e.Graphics.DrawLine(greenPen, 365, 121, 365, 350);

                    //Draws the core of the death star
                    e.Graphics.DrawEllipse(greenPen, 330, 345, 50, 50);
                    e.Graphics.DrawLine(blackPen, 345, 347, 365, 347);
                    e.Graphics.DrawLine(blackPen, 340, 346, 370, 346);

                    //Side to side lines
                    e.Graphics.DrawLine(redPen, 355, 370, x1, 370);
                    e.Graphics.DrawLine(redPen, x2, 370, 355, 370);

                    //Top and bottom lines
                    e.Graphics.DrawLine(redPen, 355, 370, 355, y1);
                    e.Graphics.DrawLine(redPen, 355, y2, 355, 370);

                    //Diagonal lines
                    e.Graphics.DrawLine(redPen, 355, 370, x1, y2);
                    e.Graphics.DrawLine(redPen, 355, 370, x2, y1);
                    e.Graphics.DrawLine(redPen, x2, y2, 355, 370);
                    e.Graphics.DrawLine(redPen, x1, y1, 355, 370);

                    Thread.Sleep(5);//Delays for 5 milliseconds

                    x1++;//Adds one to x1
                    x2--;//Subtracts one from x2
                    y1++;//Adds one to y1
                    y2--;//Subtracts one from y2
                }
            }
            printExplosion = false;//Makes print explosion false and unable to be called upon
        }
    }
}
