using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotatoProblems;
using System.Collections.Generic;
namespace PotatoeProblemTests
{
    [TestClass]
    public class BagOPotatoesTest
    {
        /********************************************************************** 
         * Test: ""SpeedTest
         * Author: Samuel Bakes
         * Description: The following three functions are useful in determining
         *              what function is fastest.  It also serves to check if the 
         *              function returns the expected value for all cases in
         *              the problem set.  The nested loops are used to increase
         *              the amount of function calls to help determine at what point 
         *              one function becomes more advantageous over another.
         **********************************************************************/
        [TestMethod]
        public void validLookUpSpeedTest()
        {
            int[] expectedResult = { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210, 231, 253, 276, 300, 325, 351, 378, 406, 435, 465, 496, 528, 561, 595, 630, 666, 703, 741, 780, 820 };
           PotatoProblems.PotatoeLogic x = new PotatoProblems.PotatoeLogic();
            for (int k = 0; k < 5; k++)  // The following loops are used to call the test function enough times to find a distinction between functions.
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 1; i <= 40; i++)
                    {
                        int actualResult = x.differenceLookUpTable(i);
                        Assert.AreEqual(expectedResult[i - 1], actualResult, 0, "Valid Input Failed.");
                    }
                }
            }
        }
        [TestMethod]
        public void validEenieSpeedTest()
        {
            PotatoProblems.PotatoeLogic x = new PotatoProblems.PotatoeLogic();
            int[] expectedResult = { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210, 231, 253, 276, 300, 325, 351, 378, 406, 435, 465, 496, 528, 561, 595, 630, 666, 703, 741, 780, 820 };
            for (int k = 0; k < 5; k++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 1; i <= 40; i++)
                    {
                        int actualResult = x.differenceEenieMeenie(i);
                        Assert.AreEqual(expectedResult[i - 1], actualResult, 0, "Valid Input Failed.");
                    }
                }
            }
        }
        [TestMethod]
        public void validAboveFortySpeedTest()
        {
            PotatoProblems.PotatoeLogic x = new PotatoProblems.PotatoeLogic();
            int[] expectedResult = { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210, 231, 253, 276, 300, 325, 351, 378, 406, 435, 465, 496, 528, 561, 595, 630, 666, 703, 741, 780, 820 };
            for (int k = 0; k < 5; k++)  // The following loops are used to call the test function enough times to find a distinction between functions.
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 1; i <= 40; i++)
                    {
                        int actualResult = x.differenceAboveForty(i);
                        Assert.AreEqual(expectedResult[i - 1], actualResult, 0, "Valid Input Failed.");
                    }
                }
            }
        }
        /********************************************************************** 
         * Test: outOfScope
         * Author: Samuel Bakes
         * Description: The following function tests to see if an error is thrown
         *              if the number is out of scope.
         **********************************************************************/
        [TestMethod]
        public void outOfScope()
        {
            int noBags = 0;
            int negBags = -5;
            PotatoProblems.PotatoeLogic spudnik = new PotatoProblems.PotatoeLogic();
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => spudnik.differenceAboveForty(noBags));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => spudnik.differenceAboveForty(negBags));
        }
    }
}
