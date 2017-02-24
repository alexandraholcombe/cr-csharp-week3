using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonCRM.Objects
{
    public class ClientTest: IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        //Delete everything between tests
        public void Dispose()
        {
            Client.DeleteAll();
        }

        //Test that if there are no clients, GetAll returns empty list
        [Fact]
        public void TestGetAll_NoClients_ReturnsEmptyList()
        {
            //Arrange, Act
            List<Client> allClients = Client.GetAll();

            //Assert
            List<Client> actualResult = allClients;
            List<Client> expectedResult = new List<Client>{};
            Assert.Equal(expectedResult, actualResult);
        }

        //tests if table is empty at start of test; testing dispose method
        [Fact]
        public void Test_ClientsTableEmptyAtFirst()
        {
            //Arrange, Act
            int result = Client.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }
    }
}
