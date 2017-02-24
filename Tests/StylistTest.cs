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

        [Fact]
        public void Test_StylistsTableEmptyAtFirst()
        {
            //Arrange, Act
            int result = Stylist.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }
    }
}
