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

        //tests if table is empty at start of test; testing dispose and DeleteAll method
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
        public void TestEqualOverride_TrueIfCuisineNameIsSame()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("Jennifer");
            Stylist secondStylist = new Stylist("Jennifer");

            //Assert
            Assert.Equal(firstStylist, secondStylist);
        }

        [Fact]
        public void TestGetAll_Stylists_ReturnsListOfStylists()
        {
            //Arrange
            List<Stylist> allStylists = new List<Stylist> {};
            Stylist firstStylist = new Stylist("Jennifer");
            Stylist secondStylist = new Stylist("Jennifer");

            //Act
            allStylists.Add(firstStylist);
            allStylists.Add(secondStylist);

            //Assert
            List<Stylist> actualResult = Stylist.GetAll();
            List<Stylist> expectedResult = new List<Stylist>{firstStylist, secondStylist};

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
