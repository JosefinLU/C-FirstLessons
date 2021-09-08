using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void ReturnTheValue()
        {
            // the x dont change value (from 3 to 42)!
            // Because in the setInt functionwe are only passing in a value that we in that
            //Method change, but we dont change the acctualy value for var x!
            // för att ändra värdet på x måste du använda ref före int i parametern o i setInt(ref x)
            var x = GetInt();
            SetInt(x);

            // the exprected value first, and then the value of
            Assert.Equal(3, x);
        }

        private int GetInt()
        {
            return 3;
        }

        private void SetInt(int x)
        {
            // vi skickar in x = 3, men ändringen av värdet x=42 existerar enbart i denna metod/scope
            x = 42;
        }


        [Fact]
        public void DontChangeTheName()
        {

            var book1 = GetBook("Book 1");
            // we made a copy of the value from the var book1 and placed it in the parameter in the function
            //GetBookSetName.
            GetBookSetName(book1, "New book 1");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            //we are constructing a new book object
            //we are storing a ref. 
            // anew bok ref is created of the book1 values
            book = new InMemoryBook(name);

        }




        [Fact]
        public void CanSetNameFromReference()
        {
            //can change name because you are passing value in the parameters in the method
            // referense different objects:
            InMemoryBook book1 = GetBook("Book 1");
            book1.Name = "How to set a name of an object more correctly";
            SetName(book1, "New book 1");

            Assert.Equal("New book 1", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnDifferentObjects()
        {
            // referense different objects:
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        // two variables can referense the same object
        // var hold values and not objects. they can hold values and point to the same book!
        // den gör alltså ingen kopia av boken i book2! den kopiera värdet av book1 till book2!
        //alltså har den samma pointervalue! den leder till samma referens


        [Fact]
        public void TwoVarsCanRefSameObject()
        {
            var book1 = GetBook("Book 1");
            // points to the same memory as book1
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));

        }


        [Fact]
        public void TwoDifferentBooksSameName()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 1");

            Assert.False(object.ReferenceEquals(book1, book2));

        }

        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            // i can not change a string once a have declared a string, it is a ref type
            string name = "Scott";
            MakeUpperCase(name);
            // med denna så passe the test o ändrat namnet
            var upper = MakeUpperCaseStringReturn(name);

            Assert.Equal("Scott", name);
            // denna failar då den returnerar en copy of this string converted to uppercase
            // string name ändras inte! utan det är testet passed = Scott
            // den returnerar en kopia, en ny sträng som du isf måste spara i en ny variabel för att kunna använda

            // denna kommer pass
            Assert.Equal("SCOTT", upper);

        }

        private void MakeUpperCase(string parameter)
        {
            parameter.ToUpper();

        }

        //OBS! om du retunera en sträng ist så kan du ändra strängen

        private string MakeUpperCaseStringReturn(string parameter)
        {
            return parameter.ToUpper();

        }


        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}


