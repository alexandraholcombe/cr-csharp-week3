using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonCRM.Objects
{
    public class Client
    {
        private string _name;
        private int _stylistId;
        private int _id;

        public Client(string name, int stylistId, int id = 0)
        {
            _name = name;
            _stylistId = stylistId;
            _id = id;
        }

        public string GetClientName()
        {
            return _name;
        }

        public int GetClientStylistId()
        {
            return _stylistId;
        }

        public int GetClientId()
        {
            return _id;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = (this.GetClientId() == newClient.GetClientId());
                bool nameEquality = (this.GetClientName() == newClient.GetClientName());
                bool stylistIdEquality = (this.GetClientStylistId() == newClient.GetClientStylistId());

                return (idEquality && nameEquality && stylistIdEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetClientId().GetHashCode();
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

        //return list of all clientss in the database
        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                int stylistId = rdr.GetInt32(2);
                Client newClient = new Client(name, stylistId, id);
                allClients.Add(newClient);
            }

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }
            return allClients;
        }

        //Save instance into database
        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES(@ClientName, @ClientStylistId);", conn);

            SqlParameter clientNameParameter = new SqlParameter();
            cmd.Parameters.Add(new SqlParameter("@ClientName", this.GetClientName()));

            SqlParameter clientStylistIdParameter = new SqlParameter();
            cmd.Parameters.Add(new SqlParameter("@ClientStylistId", this.GetClientStylistId()));

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            if(rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }
        }

        //return client information as per id argument
        public static Client Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
            cmd.Parameters.Add(new SqlParameter("@ClientId", id.ToString()));
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundClientId = 0;
            string foundClientName = null;
            int foundClientStylistId = 0;

            while(rdr.Read())
            {
                foundClientId = rdr.GetInt32(0);
                foundClientName = rdr.GetString(1);
                foundClientStylistId = rdr.GetInt32(2);
            }

            Client foundClient = new Client(foundClientName, foundClientStylistId, foundClientId);

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return foundClient;
        }

        //update properties of client objects in db
        public void Update(string newClientName = null, int newClientStylistId = 0)
        {
            //Open Connection
            SqlConnection conn = DB.Connection();
            conn.Open();

            //new command to change any changed fields
            SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @newClientName, stylist_id = @newClientStylistId OUTPUT INSERTED.name, INSERTED.stylist_id WHERE id = @ClientId;", conn);

            //Get id of client to use in command
            SqlParameter clientIdParameter = new SqlParameter();
            cmd.Parameters.Add(new SqlParameter("@ClientId", this.GetClientId()));

            //CHANGE CLIENT name
            SqlParameter newClientNameParameter = new SqlParameter();
            newClientNameParameter.ParameterName = "@newClientName";
            // newClientNameParameter.Value = newClientName;

            //if there is a new client name, change it
            if (!String.IsNullOrEmpty(newClientName))
            {
                newClientNameParameter.Value = newClientName;
            }
            else
            {
                newClientNameParameter.Value = this.GetClientName();
            }
            cmd.Parameters.Add(newClientNameParameter);

            //CHANGE CLIENT stylist id
            SqlParameter newClientStylistIdParameter = new SqlParameter();
            newClientStylistIdParameter.ParameterName = "@newClientStylistId";

            //if there is a new client name, change it
            if (newClientStylistId != 0)
            {
                newClientStylistIdParameter.Value = newClientStylistId;
            }
            else
            {
                newClientStylistIdParameter.Value = this.GetClientStylistId();
            }
            cmd.Parameters.Add(newClientStylistIdParameter);

            //execute reader
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._name = rdr.GetString(0);
                this._stylistId = rdr.GetInt32(1);
            }
            if(rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }
        }

        //delete client from db
        public void DeleteClient()
        {
            SqlConnection conn = DB.Connection;
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id = @ClientId;", conn);
            cmd.Parameters.Add(new SqlParameter("@ClientId", this.GetClientId()));
            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}
