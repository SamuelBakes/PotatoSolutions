using System;
using System.Collections.Generic;

namespace PotatoProblems
{
    public class InputOutput
    {
        public int getInput()
        {
            bool needInput = true;
            String gentileInput = ""; // This input is unclean
            int convertInput = 0; // This will be the place of the cleaned input.
            while (needInput)
            {
                Console.WriteLine("Number of Bags: ");
                gentileInput = Console.ReadLine();
                needInput = false;  // If the conversion succeeds we leave the loop

                try
                {
                    convertInput = int.Parse(gentileInput, System.Globalization.NumberStyles.AllowLeadingWhite | System.Globalization.NumberStyles.AllowTrailingWhite | System.Globalization.NumberStyles.AllowThousands);
                    if (convertInput <= 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + '\n' + "The number must be an integer greater than zero.");
                    needInput = true;  // Let's try again...
                }
            }
            return convertInput;
        }
        public void setOutput(int num)
        {
            try
            {
                Console.WriteLine("The difference in potatoes is: " + num);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public class PotatoeLogic
    {
        /******************************************************************************
         * Property Name: potatoes
         * Type: Dictionary<int, int>
         * Author: Samuel Bakes
         * Description: This dictionary is required for differenceLookUpTable().
         *              Because the differenceLookUpTable() function only becomes
         *              the computationally prefered function when there will be 
         *              an exceedingly large amount of function calls, the dictionary
         *              is commented out.  If this code is to be adapted to large scale use,
         *              uncomment the dictionary and switch the return statement found in
         *              differenceLookUpTable() with the commented out return statement.
         *****************************************************************************/
        /* private Dictionary<int,int> potatoes = new Dictionary<int, int>()
         {
                 {1,1 },
                 {2,3 },
                 {3,6 },
                 {4,10 },
                 {5,15 },
                 {6,21 },
                 {7,28 },
                 {8,36 },
                 {9,45 },
                 {10,55 },
                 {11,66 },
                 {12,78 },
                 {13,91 },
                 {14,105 },
                 {15,120 },
                 {16,136 },
                 {17,153 },
                 {18,171 },
                 {19,190 },
                 {20,210 },
                 {21,231 },
                 {22,253 },
                 {23,276 },
                 {24,300 },
                 {25,325 },
                 {26,351 },
                 {27,378 },
                 {28,406 },
                 {29,435 },
                 {30,465 },
                 {31,496 },
                 {32,528 },
                 {33,561 },
                 {34,595 },
                 {35,630 },
                 {36,666 },
                 {37,703 },
                 {38,741 },
                 {39,780 },
                 {40,820 }
         };*/
        /******************************************************************************
         * Function Name: differenceLookUpTable
         * Author: Samuel Bakes
         * Parameters: 
         *      First Parameter: int numPotatoes represents the number of potatoe bags
         * Description: This function will return the absolute value 
         *              of the difference between the number of russet potatoes
         *              and red potatoes.  Because of the constraints, the number of 
         *              valid inputs are known.  Therefore the lookup table method
         *              may be the least computationally expensive method if the function
         *              is called an exceedingly large amount of times.  If this program 
         *              was expected to be constantly running, this would be the optimal 
         *              solution.  Given that the amount of times this function will run
         *              is unknown, the dictionary is commented out and this function
         *              will call the next most efficient function.
         *****************************************************************************/
        public int differenceLookUpTable(int numPotatoes)
        {
            if (numPotatoes <= 0 || numPotatoes > 40)
                throw new ArgumentOutOfRangeException("Error: There must be a number of potato bags between 1 and 40 inclusive."); //redundant check
            //return this.potatoes[numPotatoes];
            return differenceAboveForty(numPotatoes);
        }
        /**************************************************************************** 
         * Function Name: differenceEenieMeenie
         * Author: Samuel Bakes
         * Parameters:
         *      First Parameter: int numPotatoes represents the number of potatoe bags
         * Description: This function will return the absolute value 
         *              of the difference between the number of russet potatoes
         *              and red potatoes. This function will do this by taking the square of 
         *              numPotatoes and adding it to one variable if numPtatoes is even, and another
         *              variable if numPotatoes is odd. When numPotatoes is zero, the two variables will
         *              be subtracted and the absolute value of that answer returned. 
         *              This is computationally expensive and is only included to help demonstrate
         *              that I can solve a problem in more than one way and know which solution is best.
         ****************************************************************************/
        public int differenceEenieMeenie(int numPotatoes)
        {
            if (numPotatoes <= 0)
                throw new ArgumentOutOfRangeException("Error: There must be a non zero number of potato bags of potatoes."); // redundant check
            int tater = 0;  // evens
            int tot = 0; // odds
            while (numPotatoes != 0)
            {
                if (numPotatoes % 2 == 0)
                {
                    tater += numPotatoes * numPotatoes;
                }
                else
                {
                    tot += numPotatoes * numPotatoes;
                }
                numPotatoes--;
            }
            return Math.Abs(tater - tot);
        }
        /**************************************************************************** 
         * Function Name: differenceAboveForty
         * Author: Samuel Bakes
         * Parameters:
         *      First Parameter: int numPotatoes represents the number of potatoe bags
         * Description: This function will return the absolute value 
         *              of the difference between the number of russet potatoes
         *              and red potatoes. This function is designed to exploit the
         *              summation pattern present.  This is the least computationally 
         *              expensive function if the program is only running a short time.
         ****************************************************************************/
        public int differenceAboveForty(int numPotatoes)
        {
            if (numPotatoes <= 0)
                throw new ArgumentOutOfRangeException("Error: There must be a non zero number of potato bags of potatoes."); // redundant check
            return numPotatoes * (numPotatoes + 1) / 2;
        }
    }
    class Program
    {
        /**************************************************************************** 
         * Function Name: Main
         * Author: Samuel Bakes
         * Parameters: OS arguments not used in Program.
         * Description: This function prompts the user for the number of bags, and outputs the 
         *              difference in potatoes. All error handling occurs in this function.
         ****************************************************************************/
        static void Main(string[] args)
        {
            InputOutput ui = new InputOutput();
            PotatoeLogic spudnik = new PotatoeLogic();  // In memory of the first Earth satelite.
            int numBags = ui.getInput();
            int potatoeDifference = spudnik.differenceAboveForty(numBags);
            ui.setOutput(potatoeDifference);
        }
    }
}
