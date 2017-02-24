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
    }
}
