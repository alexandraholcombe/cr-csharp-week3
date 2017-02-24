using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonCRM.Objects
{
    public class StylistTest: IDisposable
    {
        public StylistTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        //Delete everything between tests
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        //Test that if there are no stylists, GetAll returns empty list
        [Fact]
        public void TestGetAll_NoStylists_ReturnsEmptyList()
        {
            //Arrange, Act
            List<Stylist> allStylists = Stylist.GetAll();

            //Assert
            List<Stylist> actualResult = allStylists;
            List<Stylist> expectedResult = new List<Stylist>{};
            Assert.Equal(expectedResult, actualResult);
        }

        //tests if table is empty at start of test; testing dispose method
        [Fact]
        public void Test_StylistsTableEmptyAtFirst()
        {
            //Arrange, Act
            int result = Stylist.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        //test if equals override works
        [Fact]
        public void TestEqualOverride_TrueIfStylistNameIsSame()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("Jennifer");
            Stylist secondStylist = new Stylist("Jennifer");

            //Assert
            Assert.Equal(firstStylist, secondStylist);
        }

        //tests if instances are saved to db
        [Fact]
        public void Test_Save_SavesToDatabase()
        {
            //Arrange
            Stylist newStylist = new Stylist("Jennifer");

            //Act
            newStylist.Save();

            //Assert
            List<Stylist> actualResult = Stylist.GetAll();
            List<Stylist> expectedResult = new List<Stylist>{newStylist};

            Assert.Equal(expectedResult, actualResult);
        }

        //tests that each instance is assigned corresponding db id
        [Fact]
        public void TestSave_AssignIdtoObject()
        {
            //Arrange
            Stylist testStylist = new Stylist("Jennifer");

            //Act
            testStylist.Save();
            Stylist savedStylist = Stylist.GetAll()[0];

            //Assert
            int actualResult = savedStylist.GetStylistId();
            int expectedResult = testStylist.GetStylistId();

            Assert.Equal(expectedResult, actualResult);
        }

        //Tests that GetAll method pulls all items from db
        [Fact]
        public void TestGetAll_Stylists_ReturnsListOfStylists()
        {
            //Arrange
            Stylist firstStylist = new Stylist("Jennifer");
            Stylist secondStylist = new Stylist("Jennifer");

            //Act
            firstStylist.Save();
            secondStylist.Save();

            //Assert
            List<Stylist> actualResult = Stylist.GetAll();
            List<Stylist> expectedResult = new List<Stylist>{firstStylist, secondStylist};

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void TestFind_FindsStylistInDatabase()
        {
            //Arrange
            Stylist testStylist = new Stylist("Jennifer");
            testStylist.Save();

            //Act
            Stylist foundStylist = Stylist.Find(testStylist.GetStylistId());

            //Assert
            Assert.Equal(testStylist, foundStylist);
        }
    }
}
