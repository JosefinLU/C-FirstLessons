using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

namespace GradeBook
{
    // interface type convenstion start with I
    // an interface class you have to add all the members to be able to use them
    public interface IBook
    {
        void AddGrade(double gradeInput);
        Statistics GetStatistics();
        string Name { get; }

    }

    // New abstract class that inherit from Book (that in itself inherit NameOBjected and Ibook). Added a constructor, and override the memmbers of that class. It needs to have the same members as Book.
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }
        // everytime this method is invokde it should open a file that has the same name as the book
        // Write a new line to the file that contains the grade value
        public override void AddGrade(double gradeInput)
        {
            // to declare the filepath if the file exists
            string path = @"/Users/josefinlundquist/Desktop/CSharpLog.txt";

            // Open and creates a file with the name of the objectand the extention txt.
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                // using make sure to execute the code inside the curly brackets.
                // Now we are able to add as many grade we want

                // writing to the file with the value of gradeInput
                writer.WriteLine(gradeInput);
            }
        }


        // will read all the grades that we put in the file
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                // loop through the lines as long the are not null
                while (line != null)
                {
                    // parsing the string "line" to a double "number"
                    var number = double.Parse(line);
                    result.Add(number);
                    // after adding a number continue reading the next line and start to loop over, until the line = null then we exit the loop and return the result
                    line = reader.ReadLine();
                }
            }
            return result;
        }

    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {

        }
        public abstract void AddGrade(double gradeInput);

        public abstract Statistics GetStatistics();

    }


    // to inherit a class : NameOfTheClass, Name
    // to use interface, you can add by , (IBook ex)
    public class InMemoryBook : Book
    {

        // Constructor - skapa sin egen el så är det inbyggd auto i programmet Book() ex. vi tvinga uppge ett namn för boken genom constructorn.

        //ref the base class, acccessing the constructor in the NamedObject
        public InMemoryBook(string name) : base(name)

        {
            grades = new List<double>();
            this.Name = name;
        }
        // You can have sevral constructors as long they have different args
        /*   public Book()
           {
               // using read only prop, assign a new/diff value, can only be used in constructor. there is no other fields ot method that can access this prop/fields!
               category = "Litterture";
               grades = new List<double>();
           } */





        //Method add grade. Override = polyolism
        public override void AddGrade(double gradeInput)
        {
            //check if grade from user is correct
            if (gradeInput <= 100 && gradeInput >= 0)
            {
                grades.Add(gradeInput);
            }
            // if user input is not in correct format or and unexpected input
            else
            {
                // chose argumentException because user input is an argument
                // om vi ha throw kommer programmet att sluta, vill vi fånga exception måste vi har en catch om vi vill fortsätta programmet
                // programmet letar där denna AddGrade functionen kallas (i program) addera try and catch i program på book.AddGrade(gradeInput) för att handera parse, denna hantera > 100
                throw new ArgumentException($"Invalid {nameof(gradeInput)}");
            }
        }

        // returning the type Statistics class
L        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            // returning the object result with its values/props
            return result;
        }

        // Error: Object reference not set to an instance of an object.
        // vi måste instansiera grades, alltså med new List...
        //ser man detta felet med obj ref not... så handlar  det om att grades of List inte är instanserat
        private List<double> grades;
        //public memember in C# has as convention upercase letter

        // you need the property field Name as well get and set, thats where it is stored to alt 2

        //private string Name;

        // To be able to access book name from outside this class but we want to controll that access - that when we use getters and setters
        // Get name get a string and set name set a string(name)
        // get - someone wants to read the property name by in program book.Name we can access that property. Set --> book.Name = "Josefin" we setting the value of that prop

        //
        /* public string Name
         {
             get;
             set; // private set = then the outside can not chnage the name/write that name
         }*/

        // alt 2 to define a get and set
        /*  public string Name
          {
              get
              {
                  return name;
              }
              set
              {
                  // om strängen inte är null o empty setter vi värdet
                  if (!String.IsNullOrEmpty(value))
                  {
                      name = value;
                  }
                  else
                  // create an exception if the setter is null or empty
                  {
                      throw new ArgumentException("The name is null or empty");
                  }
              }
          }*/

        // there is ReadOnly Fields in C# to use that you can creat in a class and it cant be changed, appart from when you use it in the constructor so you will knonw what vaue that string has in the start of the object and in the end. remember you can have several constructors, as long they have different arguments
        readonly string category = "Science";

        // you can have and declare const that will not be able to change th value, const x = 10. you can not access a static member through a object, const is hanterade som statice members! you need to ref to the class in this case Book
        public const string CATEGORY2 = "Culture";
    }

}
