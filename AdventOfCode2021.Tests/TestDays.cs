using AdventOfCode2021.Enumerations;
using NUnit.Framework;

namespace AdventOfCode2021.Tests
{
    public class TestDays
    {
        [Test]
        public void Day1Part1()
        {
            //Assign
            var runmode = RunMode.Day1Part1;
            var expectedResult = "1583";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day1Part2()
        {
            //Assign
            var runmode = RunMode.Day1Part2;
            var expectedResult = "1627";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day2Part1()
        {
            //Assign
            var runmode = RunMode.Day2Part1;
            var expectedResult = "1383564";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day2Part2()
        {
            //Assign
            var runmode = RunMode.Day2Part2;
            var expectedResult = "1488311643";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day3Part1()
        {
            //Assign
            var runmode = RunMode.Day3Part1;
            var expectedResult = "4174964";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day3Part2()
        {
            //Assign
            var runmode = RunMode.Day3Part2;
            var expectedResult = "1488311643";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}