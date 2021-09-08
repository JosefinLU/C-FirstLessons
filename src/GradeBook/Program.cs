using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        // static is not assosiated with the object!! instance of the class!
        //  man använder static om man inte har object för det man ska göra, men vill använda klassen
        // ex om AddGrade()-metiden skulle vara Static så kan du då köra Book.AddGrade(5); ist för book(ojketet).AddGrade(5);
        //Men varje gång du skapar ett book objekt så skulle AddGrade inte vara en del av objektet
        // både Main och Console är static, så du kan använda klassen utan objekt Console.WriteLine();
        static void Main(string[] args)
        {

            // för att förhindra indexOfOutRange - om inget parameter skickas in
            if (args.Length > 0)
            {
                Console.WriteLine("Hello " + args[0] + "!");
            }
            else
            {
                Console.WriteLine("Hello");
            }



            //cw snippet for:
            //Console.WriteLine(result);

            /*
            List<double> grades = new List<double>() { 21.1, 22.3, 2.5 };
            grades.Add(56.1);
            grades.Add(5.1);
            grades.Add(20.3);

            double resultList = 0;
            foreach (double number in grades)
            {
                resultList += number;
            }
            double average = resultList / grades.Count;
            //Console.WriteLine(average);
            // how to format the result with ex one digit
            Console.WriteLine($"The average grade is {average:N1}");
            */

            // start of classes and objects
            //Book

            IBook book = new DiskBook("Just Kids");
            book.AddGrade(89.1);
            book.AddGrade(55.1);
            book.AddGrade(44.5);



            // as loong we get input
            // när du markerar all kod som kan du encapsulate den biten genom gula glödlampan
            EnterGrades(book);



            // creating an object of Statistics, to store the statisticts High, Low and average values
            // calling the funtion that calculating that
            // printing the objekts (stats) properties
            var stats = book.GetStatistics();
            Console.WriteLine($"The max grade is {stats.High} the min value is {stats.Low} and the average is {stats.Average}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                //input from user/console, expect input from console 
                var input = Console.ReadLine();

                //if user enter a q then this will fail, so we need to handle that
                if (input == "q")
                {
                    break; // skip over the parsing and exit the loop and go down to var stats
                }


                // to handle if exception occures - try and catch it
                try
                {
                    // This is what we want to execute, and what we expect
                    // need to parse the string from the user ex is user prints 72 into float/double
                    var gradeInput = double.Parse(input);
                    // if Parse gradeInput from user fails, we skipp the code in the try and go to catch
                    book.AddGrade(gradeInput);
                }
                // If user put in something we dont expect regarding argument
                // catching the exception, store it in a type of variable, e
                catch (ArgumentException e)
                {
                    // handling the Argument, the input if it is invalid when calling AddGrade
                    // we catching the exception and going back to the loop again for valid input
                    Console.WriteLine(e.Message);
                }
                // handling the FormatIssue, Parsing
                catch (FormatException e)
                {
                    // we catching the exception and going back to the loop again for valid input
                    Console.WriteLine(e.Message);
                }
                // if you catch an exception (book.AddGrade) get skipped, maybe you need to do something with the program then
                // then you can use finally that will be executed as well, ex closing a file or code
                /*   finally
                   {
                       Console.WriteLine("*Retry and do it correctly*");
                   }*/
            }
        }
    }
}
