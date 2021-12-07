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
            var expectedResult = "4474944";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day4Part1()
        {
            //Assign
            var runmode = RunMode.Day4Part1;
            var expectedResult = "58374";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day4Part2()
        {
            //Assign
            var runmode = RunMode.Day4Part2;
            var expectedResult = "11377";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day5Part1()
        {
            //Assign
            var runmode = RunMode.Day5Part1;
            var expectedResult = "6666";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day5Part2()
        {
            //Assign
            var runmode = RunMode.Day5Part2;
            var expectedResult = "19081";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day6Part1()
        {
            //Assign
            var runmode = RunMode.Day6Part1;
            var expectedResult = "352872";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day6Part2()
        {
            //Assign
            var runmode = RunMode.Day6Part2;
            var expectedResult = "1604361182149";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day7Part1()
        {
            //Assign
            var runmode = RunMode.Day7Part1;
            var expectedResult = "344735";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Day7Part2()
        {
            //Assign
            var runmode = RunMode.Day7Part2;
            var expectedResult = "96798233";

            //Act
            var result = RunModeHandler.Execute(runmode);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}