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

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist>{};
            return allStylists;
        }

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
