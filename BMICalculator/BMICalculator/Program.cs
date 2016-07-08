//Author: Joseph L. Tapang
//Date: 6/23/2016

/*
Console program that takes user input of height and weight.
Progam validates data and if valid calculates the users BMI.
Progam determines if BMI is normal, underweight, overweight and lets the user know.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Algorith: Prompt user for height, user enters height, validate height where an invalid input reprompts the user, valid input is saved
into a global variable 'height', repeat preceeding steps to retrieve users weight, calculate BMI, write to console users BMI and determine
if user is normal, underweight, overweight where the program lets user know to contact doctor if the latter two is true.

BMI formula: (weight/(height*height))*703
*/

/*
TODO 
-Fine error checking 
    --Unusual weights or heights
    --values that are > 0 but < 1
-Alert user to error
    --Error messages for non numerical inputs
    --Error for negative inputs
-Asserts
-Windowed Windows Interface
-Mobile App interface
*/

namespace BMICalculator
{
    class Program
    {

        //validate function
        public double isValid(String x) //takes a string
        {
            double result; 
            double.TryParse(x, out result); 
            if(result != 0) 
            {
                //check negative
                if(result < 0)
                {
                    result = 0;
                }
            }
            return result;
        }
        
        //BMI calculation function, arguments are double height, double weight and returns double BMI.
        public void BMICalc (double height, double weight)
        {
            double BMI;
            String category;
            Boolean seeDoc = false;
            BMI = ((weight / (height * height)) * 703);
            
            //check BMI category < 18.5 or > 25
            ////try switch statement
            if(BMI < 18.5)
            {
                category = "underweight";
                seeDoc = true;
            }
            else if(BMI > 25)
            {
                category = "overweight";
                seeDoc = true;
            }
            else
            {
                category = "normal";
            }

            Console.WriteLine("Your BMI is " + BMI.ToString("#.00"));
            if (seeDoc)
            {
                Console.WriteLine("You are considered " + category + " in your weight class.");
                Console.WriteLine("Please contact your nutritionist to schedule an appointment.");
            }

        }

        //run program, read eval print loop
        public void BMIrepl()
        {
            double height = -1;
            double weight = -1;

            //get height from user
            while (height == -1)
            {
                double userInput;
                Console.Write("Enter your height: ");
                userInput = isValid(Console.ReadLine());

                //only assign to global if result from isValid is not 0
                if (userInput != 0)
                {
                    height = userInput;
                }
            }

            //get weight from user
            while (weight == -1)
            {
                double userInput;
                Console.Write("Enter your weight: ");

                //only assign to global if result from isValid is not 0
                userInput = isValid(Console.ReadLine());
                if (userInput != 0)
                {
                    weight = userInput;
                }
            }

            //BMI calculation function
            BMICalc(height, weight);
            
            //Keeps console window open to display above program
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {

            Program newProg = new Program();
            //call loop function here
            newProg.BMIrepl();

        }

    }
}
