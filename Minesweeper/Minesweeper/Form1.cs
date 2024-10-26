using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Minesweeper : Form
    {
        int[,] MineArray = new int[15, 15];  //-1: Mine  0-8: Number of mines in adjacent cells
        //declares the mine array
        int[,] CoverArray = new int[15, 15];   //-1: Not open  1:Open  2:Flag
        //declares the grid array
        Random rndGen = new Random();
        //creates a random number
        int FlagCounter = 40, Timer = 0;
        // creating counter to count flags
        bool GameOverChecker = true, WinGameChecker = false;
        //Game over checker and win game checker


        public Minesweeper()
        {
            InitializeComponent();
            int r, c; //declares rows and columns

            for (c = 0; c < 15; c = c + 1)
            {
                for (r = 0; r < 15; r = r + 1)
                //goes through the columns and rows to initialize the array's values to closed
                {
                    CoverArray[c, r] = -1;   // not Open
                    MineArray[c, r] = 0; 
                    /*-1 equals closed and applies it to the grid when initialized
                     * Mine array set to 0 pre-mine plant
                     */
                }
            }
        }

        public void PlantMines()
        //method to be called for planting the mines in the mine array at the start button
        {
            int MineCounter = 40, r = 0, c = 0;
            //sets the number of mines to 40 to be placed and declares rows and columns

            while (MineCounter != 0) //when the mine counter still has unplaced mines
            {
                r = rndGen.Next(0, 15);
                c = rndGen.Next(0, 15);
                //randomly generates rows and columns
                if (MineArray[c, r] != -1)
                //checks the rows and columns for mines
                {
                    MineArray[c, r] = -1;
                    //places a mine
                    MineCounter--;
                    //removes a mine from the mine counter     
                }
            }
        }

        public void OpenUp (int c, int r)
            //if the user clicks on a 0, it will open the surrounding squares til it reaches a number
        {
            if (MineArray [c, r] == 0) //checks if there aren't any mines in that x y pos
            {
                if (r >= 1 && c>= 1) //checks if there's any squares out of bounds to the top left corner
                {
                    if(CoverArray [c - 1, r - 1] == -1) //checks if it's closed
                    {
                        CoverArray [c- 1, r - 1] = 1;    //opens the square

                        if (MineArray [c - 1, r -1] == 0) //if it's not adjacent to any mines
                        {
                            OpenUp(c - 1, r - 1);
                        }
                    }
                }
                if (r >= 1 && c <= 13) //checks if there's any squares out of bounds to the top right corner
                {
                    if(CoverArray [c+1, r-1] == -1) //check if it's closed
                    {
                        CoverArray[c + 1, r - 1] = 1; //if not, opens square

                        if (MineArray [c + 1, r-1] == 0) //if opened square has no mines adjacent
                        {
                            OpenUp(c + 1, r - 1); //recall the method with those parameters to open the surrounding squares
                        }
                    }
                }
               if (r <= 13 && c <= 13) //checks if there's any squares out of bounds to the bottom right corner
                {
                    if(CoverArray [c+1, r+1] == -1) //check if it's closed
                    {
                        CoverArray[c + 1, r + 1] = 1; //opens square
                        if (MineArray [c + 1, r +1] == 0) //if opened square has no mines adjacent, 
                        {
                            OpenUp(c + 1, r + 1); //recalls the method with the those parameters to open the surrounding squares
                        }
                    }
                }
               if (r <= 13 && c >= 1) //bottom left corner
                {
                    if(CoverArray [c-1, r+1] == -1)
                    {
                        CoverArray[c - 1, r + 1] = 1; 
                        if (MineArray[c-1, r+1 ] == 0)
                        {
                            OpenUp(c - 1, r + 1);
                        }
                    }
                }
               if (r >= 1) //top side
                {
                    if (CoverArray [c, r-1] == -1)
                    {
                        CoverArray[c, r - 1] = 1;
                        if (MineArray[c, r-1] == 0)
                        {
                            OpenUp(c, r - 1);
                        }
                    }
                }
               if (c <= 13)//right side
                {
                    if (CoverArray [c +1, r] == -1)
                    {
                        CoverArray[c + 1, r] = 1;
                        if (MineArray[c+ 1, r] == 0)
                        {
                            OpenUp(c + 1, r);
                        }
                    }
                }
               if (r <=13)//bottom side
                {
                    if (CoverArray [c, r+1] == -1)
                    {
                        CoverArray[c, r + 1] = 1;
                        if (MineArray[c, r+1] ==0)
                        {
                            OpenUp(c, r + 1);
                        }
                    }
                }
               if (c >=1)//left side
                {
                    if (CoverArray [c-1, r] ==-1)
                    {
                        CoverArray[c - 1, r] = 1;
                        if (MineArray[c-1,r] == 0)
                        {
                            OpenUp(c-1, r);
                        }
                    }
                }
            }
        }

        public void ClearArray()
        //clears the arrays
        {
            int c, r;
            //initializes the columns and rows
            for (c = 0; c < 15; c++)
            //goes through the columns
            {
                for (r = 0; r < 15; r++)
                //goes through each row in the columns
                {
                    MineArray[c, r] = 0;
                    CoverArray[c, r] = -1;
                    //sets both arrays to initialized values 
                }
            }
        }
        public void GameOver()
            //ends the game if the user clicks on a mine
        {
            tmMineSweeperTimer.Enabled = false;
            //stops the timer
            GameOverChecker = true;
            //sets the boolen to true to be checked when the user clicks
            int c, r;
            //initializes the columns and rows
            for (c = 0; c < 15; c++)
            //goes through the columns
            {
                for (r = 0; r < 15; r++)
                //goes through each row in the columns
                {
                    if (MineArray[c, r] == -1) //if the cover array is closed
                    {
                        CoverArray[c, r] = 1; //open the cover array
                    }
                 }    
            }
        }
        public void WinGame()
            //is called to check if the user opens all the squares
        {
            int c, r;
            //initializes the columns and rows and creates a wingame counter to check how many open squares there are 
            for (c = 0; c < 15; c++)
            //goes through the columns
            {
                for (r = 0; r < 15; r++)
                //goes through each row in the columns
                {
                    if (CoverArray[c, r] == -1 && MineArray[c,r] != -1) //checks if the square has not been opened and there isn't a mine present
                    {
                        WinGameChecker = false;
                        GameOverChecker = false;
                        return;
                        //will end the code because the user has yet to open all the squares
                    }
                    WinGameChecker = true;
                    GameOverChecker = true;
                    //if it is never returned, that means the user has opened all the squares and sets the boolen to true
                    //also sets the game over checker to true to prevent the user from editing the board after they win
                }
            }
        }

        public void CountMines()
            //checks the adjacent squares to count the mines and place the number surrounding accordingly
        {
            int c, r, MineCounter = 0 ;

                for (c = 0; c < 15; c++)
                //checks all columns in grid
                {
                    for (r = 0; r < 15; r++)
                    //checks all rows in grid
                    {
                    MineCounter = 0;

                    if (MineArray[c, r] != -1) //if there is no mine we need to count the neighbouring cells
                    {
                        if (r == 0 && c == 0)  //Top Left Corner (C)
                        {
                            if (MineArray[c + 1, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c, r + 1] == -1)
                            {
                                MineCounter++;
                            }

                            MineArray[c, r] = MineCounter;
                        }
                        else if (r == 0 && c == 14)  //Top Right Corner (C)
                        {
                            if (MineArray[c - 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            MineArray[c, r] = MineCounter;
                        }
                        else if (r == 14 && c == 14) //Bottom Right Corner (C)
                        {
                            if (MineArray[c, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            MineArray[c, r] = MineCounter;

                        }
                        else if (r == 14 && c == 0) //Bottom Left Corner (C)
                        {
                            if (MineArray[c + 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            MineArray[c, r] = MineCounter;
                        }
                        else if (r == 0 ) //Top Side (Edge)
                        {
                            if (MineArray[c, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            MineArray[c, r] = MineCounter;
                        }
                        else if (c == 0) //Left side (Edge)
                        {
                            if (MineArray[c, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            MineArray[c, r] = MineCounter;
                        }
                        else if (r == 14) //Bottom side (Edge)
                        {
                            if (MineArray[c - 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1 , r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            MineArray[c, r] = MineCounter;
                        }
                        else if (c == 14) //Right side (Edge)
                        {
                            if (MineArray[c - 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            MineArray[c, r] = MineCounter;
                        }
                        else  // middle grid
                        {
                            if (MineArray[c - 1, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c - 1, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r + 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c + 1, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            if (MineArray[c, r - 1] == -1)
                            {
                                MineCounter++;
                            }
                            MineArray[c, r] = MineCounter;
                        }
                        // Check 8 adjacent for mines and changes mine counter accordingly
                    }

                    }
                }
        }
        private void tmMineSweeperTimer_Tick(object sender, EventArgs e)
        {
            Timer++;
            //adds one to the timer each second
            txtTimer.Text = Timer.ToString() + "s";
            //outputs the timer into a text box for the user
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            try
            {
                Timer = 0;
                FlagCounter = 40;
                //sets the flag counter to 40 for the user to know there are 40 mines placed
                txtFlagCounter.Text = FlagCounter.ToString();
                pbMineSweeper.Invalidate();
                //resets all the graphics, and flag counter
                ClearArray();
                //calls the method to clear arrays to prevent overwrite
                PlantMines();
                //calls the method to output the mines inside the arrays
                CountMines();
                //calls the method to call the mines # adjacent to open squares
                tmMineSweeperTimer.Enabled = true;
                //activates the timer

                GameOverChecker = false;  
                WinGameChecker = false;
                //initially starts game over and win game as false to prevent overlapping from a previous game
                //game over checker gets change from true to false when the game starts to prevent the user from being able to change the game after it is finished or before it starts
            }
            catch
            {
                MessageBox.Show("Error, please try again");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Check out the user manual for an in depth description on strategies and how to play!");
        }

        private void pbMineSweeper_MouseClick(object sender, MouseEventArgs e)
        {

            int row, col, MouseX = e.X, MouseY = e.Y;

            col = MouseX / 30;
            row = MouseY / 30;

            if (GameOverChecker == true) // checks if the user clicked on a mine or if they haven't started to prevent clicking on the board after/before the game ends/starts
            {
                return; // ends execution of any mouse click events
            }

            if (e.Button == MouseButtons.Right)
            //Right click is for flag placing
            {
                if (CoverArray[col, row] == 2) //if the cover array has already has a flag
                {
                    CoverArray[col, row] = -1; //it removes the flag off the board
                    FlagCounter++; //puts a flag back into the counter
                }
                else if (CoverArray[col, row] == 1) //if the cover array is open, it won't put a flag
                {

                }
                else if (FlagCounter < 1) // checks if all flags have been placed
                {

                }
                else
                {
                    CoverArray[col, row] = 2; //places a flag onto the board 
                    FlagCounter--; //removes a flag from the counter 
                }
                txtFlagCounter.Text = FlagCounter.ToString(); // outputs flagcounter into textbox
            }
            else if (e.Button == MouseButtons.Left)
            //for opening squares on the board
            {
                if (CoverArray[col, row] != 2) //if there is a flag, it won't open the array
                {
                    if (MineArray[col, row] == -1) //if the user opens on a mine
                    {
                        GameOver(); //calls the game over method
                        MessageBox.Show("Game Over.");
                        //ends the game using the method, shows all of the mines
                    }
                    else
                    {
                        CoverArray[col, row] = 1; //opens the cover array
                        OpenUp(col, row); //checks if the user clicks on an empty square to break open the surrounding squares til it reaches a number
                        WinGame(); //checks if the user has won the game or not on click
                        if (WinGameChecker == true) //if the win game method was run positively, it will change the boolen to true and this will check if it did
                        {
                            MessageBox.Show("You've found all the mines in " + Timer.ToString() + "s");
                            //outputs a winning message
                            tmMineSweeperTimer.Enabled = false;
                            //stops the timer
                        }
                    }
                }
            }
            pbMineSweeper.Invalidate();
            //invalidates the graphics to reset it on event 
        }

        private void pbMineSweeper_Paint(object sender, PaintEventArgs e)
            //creates the graphics
        {
            int r, c; //declares rows and columns
            Graphics g;  
            g = e.Graphics;
            //declares the graphics

            SolidBrush myBrush = new SolidBrush(Color.Transparent);
            Pen myPen = new Pen(Color.Black, 3);
            //sets the default values for brush and pen

            for (c = 0; c < 15; c = c + 1)
            {
                for (r = 0; r < 15; r = r + 1)
                {
                    if(CoverArray[c,r]==-1)  //Makes a square in place for closed squares
                    { 

                        myBrush.Color = Color.DarkGray;
                        g.FillRectangle(myBrush, c * 30 , r * 30 , 30, 30);

                        //creates rhombuses to create a 3D look on closed squares
                        Point[] polygonRhombus1 = new Point[4]; //top

                        polygonRhombus1[0].X = c * 30;
                        polygonRhombus1[0].Y = r * 30;
                        polygonRhombus1[1].X = c * 30 + 5;
                        polygonRhombus1[1].Y = r * 30 + 5;
                        polygonRhombus1[2].X = c * 30 + 25;
                        polygonRhombus1[2].Y = r * 30 + 5;
                        polygonRhombus1[3].X = c * 30 + 30;
                        polygonRhombus1[3].Y = r * 30;

                        myBrush.Color = Color.LightGray;
                        g.FillPolygon(myBrush, polygonRhombus1);

                        Point[] polygonRhombus2 = new Point[4]; //left

                        polygonRhombus2[0].X = c * 30;
                        polygonRhombus2[0].Y = r * 30;
                        polygonRhombus2[1].X = c * 30 + 5;
                        polygonRhombus2[1].Y = r * 30 + 5;
                        polygonRhombus2[2].X = c * 30 + 5;
                        polygonRhombus2[2].Y = r * 30 + 25;
                        polygonRhombus2[3].X = c * 30;
                        polygonRhombus2[3].Y = r * 30 + 30;

                        g.FillPolygon(myBrush, polygonRhombus2);

                        Point[] polygonRhombus3 = new Point[4]; //right

                        polygonRhombus3[0].X = c * 30 + 30;
                        polygonRhombus3[0].Y = r * 30;
                        polygonRhombus3[1].X = c * 30 + 25;
                        polygonRhombus3[1].Y = r * 30 + 5;
                        polygonRhombus3[2].X = c * 30 + 25;
                        polygonRhombus3[2].Y = r * 30 + 25;
                        polygonRhombus3[3].X = c * 30 + 30;
                        polygonRhombus3[3].Y = r * 30 + 30;

                        myBrush.Color = Color.Gray;
                        g.FillPolygon(myBrush, polygonRhombus3);

                        Point[] polygonRhombus4 = new Point[4]; //bottom

                        polygonRhombus4[0].X = c * 30;
                        polygonRhombus4[0].Y = r * 30 + 30;
                        polygonRhombus4[1].X = c * 30 + 5;
                        polygonRhombus4[1].Y = r * 30 + 25;
                        polygonRhombus4[2].X = c * 30 + 25;
                        polygonRhombus4[2].Y = r * 30 + 25;
                        polygonRhombus4[3].X = c * 30 + 30;
                        polygonRhombus4[3].Y = r * 30 + 30;

                        g.FillPolygon(myBrush, polygonRhombus4);
                    }
                    else if (CoverArray[c, r] == 2)  //Flag
                    {
                        //Draw a flag
                        myBrush.Color = Color.DarkGray;
                        g.FillRectangle(myBrush, c * 30, r * 30, 30, 30);

                        //creates rhombuses to create a 3D look on closed squares
                        Point[] polygonRhombus1 = new Point[4]; //top

                        polygonRhombus1[0].X = c * 30;
                        polygonRhombus1[0].Y = r * 30;
                        polygonRhombus1[1].X = c * 30 + 5;
                        polygonRhombus1[1].Y = r * 30 + 5;
                        polygonRhombus1[2].X = c * 30 + 25;
                        polygonRhombus1[2].Y = r * 30 + 5;
                        polygonRhombus1[3].X = c * 30 + 30;
                        polygonRhombus1[3].Y = r * 30;

                        myBrush.Color = Color.LightGray;
                        g.FillPolygon(myBrush, polygonRhombus1);

                        Point[] polygonRhombus2 = new Point[4]; //left

                        polygonRhombus2[0].X = c * 30;
                        polygonRhombus2[0].Y = r * 30;
                        polygonRhombus2[1].X = c * 30 + 5;
                        polygonRhombus2[1].Y = r * 30 + 5;
                        polygonRhombus2[2].X = c * 30 + 5;
                        polygonRhombus2[2].Y = r * 30 + 25;
                        polygonRhombus2[3].X = c * 30;
                        polygonRhombus2[3].Y = r * 30 + 30;

                        g.FillPolygon(myBrush, polygonRhombus2);

                        Point[] polygonRhombus3 = new Point[4]; //right

                        polygonRhombus3[0].X = c * 30 + 30;
                        polygonRhombus3[0].Y = r * 30;
                        polygonRhombus3[1].X = c * 30 + 25;
                        polygonRhombus3[1].Y = r * 30 + 5;
                        polygonRhombus3[2].X = c * 30 + 25;
                        polygonRhombus3[2].Y = r * 30 + 25;
                        polygonRhombus3[3].X = c * 30 + 30;
                        polygonRhombus3[3].Y = r * 30 + 30;

                        myBrush.Color = Color.Gray;
                        g.FillPolygon(myBrush, polygonRhombus3);

                        Point[] polygonRhombus4 = new Point[4]; //bottom

                        polygonRhombus4[0].X = c * 30;
                        polygonRhombus4[0].Y = r * 30 + 30;
                        polygonRhombus4[1].X = c * 30 + 5;
                        polygonRhombus4[1].Y = r * 30 + 25;
                        polygonRhombus4[2].X = c * 30 + 25;
                        polygonRhombus4[2].Y = r * 30 + 25;
                        polygonRhombus4[3].X = c * 30 + 30;
                        polygonRhombus4[3].Y = r * 30 + 30;

                        g.FillPolygon(myBrush, polygonRhombus4);
                        //creates background to imitate the cover when it's closed

                        g.DrawRectangle(myPen, c * 30 + 13, r * 30 + 13, 1, 9);
                        //draws a post for the rectangle

                        myPen.Color = Color.Black;
                        myBrush.Color = Color.Red;

                        Point[] polygonPoint = new Point[3];
                        //creates a polyogon for the flag
                        polygonPoint[0].X = c * 30 + 13;
                        polygonPoint[0].Y = r * 30 + 7;
                        polygonPoint[1].X = c * 30 + 21;
                        polygonPoint[1].Y = r * 30 + 10;
                        polygonPoint[2].X = c * 30 + 13;
                        polygonPoint[2].Y = r * 30 + 15;
                        //creates a flag into the middle of each square
                        g.DrawPolygon(myPen, polygonPoint);
                        g.FillPolygon(myBrush, polygonPoint);

                    }
                    else if (CoverArray[c,r]==1)  //open
                    {
                        if (MineArray[c, r] == -1)  //Mine
                        {
                            myPen.Color = Color.Black;
                            myBrush.Color = Color.Gray;
                            g.FillEllipse(myBrush, c * 30 , r * 30, 30, 30);
                            g.DrawEllipse(myPen, c * 30, r * 30, 30, 30);
                            myBrush.Color = Color.Red;
                            g.FillEllipse(myBrush, c * 30 + 10, r * 30 + 10, 10, 10);
                            g.DrawEllipse(myPen, c * 30 + 10, r * 30 + 10, 10, 10);
                        }
                        else if (MineArray[c, r] == 0)  //empty
                        {
                            myBrush.Color = Color.LightGray;
                            g.FillRectangle(myBrush, c * 30, r * 30, 30, 30);
                        }
                        else  // draws the strings for 1-8
                        {
                            String drawString = MineArray[c,r].ToString();

                            // Create font and brush.
                            Font drawFont = new Font("Arial", 16);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);

                            if (MineArray[c,r] == 1) //if the number is 1
                            {
                                drawBrush.Color = Color.Blue; //it will change the brush colour to blue
                            }
                            if (MineArray[c,r] == 2) //if the number is 2
                            {
                                drawBrush.Color = Color.Green; //changes the number colour to green
                            }
                            if (MineArray[c,r] == 3) //if the number is 3
                            {
                                drawBrush.Color = Color.Red; //changes the brush colour to red
                            }
                            if (MineArray[c,r] == 4) //if the number is 4
                            {
                                drawBrush.Color = Color.Purple; //changes the brush colour to purple    
                            }
                            if (MineArray[c,r] == 5) //if the number is 5 
                            {
                                drawBrush.Color = Color.Maroon; //changes the brush colour to maroon
                            }
                            if (MineArray[c,r] == 6) //if the number is 6
                            {
                                drawBrush.Color = Color.Turquoise; //changes the brush colour to turqoise
                            }
                            if (MineArray[c,r] == 7) //if the number is 7
                            {
                                drawBrush.Color = Color.Black; //changes the brush colour to black
                            }  
                            if (MineArray[c,r] == 8) //if the number is 8
                            {
                                drawBrush.Color = Color.Gray; //changes the brush colour to gray
                            }
                            // Create rectangle for drawing.
                            RectangleF drawRect = new RectangleF(c * 30 + 5, r * 30 + 5, 25, 25);

                            // Draw rectangle to screen.
                            Pen blackPen = new Pen(Color.Black);
                            e.Graphics.DrawRectangle(blackPen, c * 30, r * 30, 30, 30);

                            // Set format of string.
                            StringFormat drawFormat = new StringFormat();
                            drawFormat.Alignment = StringAlignment.Center;

                            // Draw string to screen.
                            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);
                        }
                    }
                    g.DrawRectangle(myPen, c * 30, r * 30, 30, 30);
                }
            }
        }
    }
}
