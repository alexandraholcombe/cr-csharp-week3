using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonCRM.Objects
{
    public class Client
    {
        private string _name;
        private int _clientId;
        private int _id;

        public Client(string name, int clientId, int id = 0)
        {
            _name = name;
            _clientId = clientId;
            _id = id;
        }

        public string GetClientName()
        {
            return _name;
        }

        public int GetClientId()
        {
            return _id;
        }

        //delete all rows from clients db table
        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>{};
            return allClients;
        }
    }
}
