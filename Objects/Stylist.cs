using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonCRM.Objects
{
    public class Stylist
    {
        private string _name;
        private int _id;

        public Stylist(string name, int id=0)
        {
            _name = name;
            _id = id;
        }

        public string GetStylistName()
        {
            return _name;
        }

        public int GetStylistId()
        {
            return _id;
        }

        public override int GetHashCode()
        {
            return this.GetStylistId().GetHashCode();
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = (this.GetStylistId() == newStylist.GetStylistId());
                bool nameEquality = (this.GetStylistName() == newStylist.GetStylistName());

                return (idEquality && nameEquality);
            }
        }

        //return list of all stylists in the database
        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist>{};
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                Stylist newStylist = new Stylist(name, id);
                allStylists.Add(newStylist);
            }

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return allStylists;
        }

        //Save stylist into database
        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name) OUTPUT INSERTED.id VALUES(@StylistName);", conn);

            SqlParameter stylistNameParameter = new SqlParameter();
            cmd.Parameters.Add(new SqlParameter("@StylistName", this.GetStylistName()));

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

        //return stylist information as per id argument
        public static Stylist Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);
            cmd.Parameters.Add(new SqlParameter("@StylistId", id.ToString()));
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundStylistId = 0;
            string foundStylistName = null;

            while(rdr.Read())
            {
                foundStylistId = rdr.GetInt32(0);
                foundStylistName = rdr.GetString(1);
            }

            Stylist foundStylist = new Stylist(foundStylistName, foundStylistId);

            if(rdr != null)
            {
                rdr.Close();
            }

            if(conn != null)
            {
                conn.Close();
            }

            return foundStylist;
        }

        //delete all rows from stylists db table
        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
