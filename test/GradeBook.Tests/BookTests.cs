using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();
            var average = ( 89.1 + 90.5 + 77.3 ) / 3;
            // assert
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal(average, result.Average, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void BookRejectsInvalidGradeValue()
        {
            var book = new InMemoryBook("");
            var result = Assert.Throws<ArgumentException>(() => book.AddGrade(100.5));
            Assert.Equal("Invalid grade", result.Message);
        }
    }
}
