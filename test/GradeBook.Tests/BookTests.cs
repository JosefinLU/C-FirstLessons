using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrades()
        {
            // structure of testning

            // arrange put togeter the testdata

            // is it ok with empty name? otherwise make sure you test that
            InMemoryBook book = new InMemoryBook("");
            book.AddGrade(90.5);
            book.AddGrade(22.5);
            book.AddGrade(55.4);

            // act section, performance, do something
            var result = book.GetStatistics();

            // Assert section
            // , 1 to be able to compare the floating numbers with one decimal
            Assert.Equal(56.1, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(22.5, result.Low, 1);
            Assert.Equal('F', result.Letter);
        }
    }
}
