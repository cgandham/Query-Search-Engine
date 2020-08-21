
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Nest;

namespace elastic.Models
{
    public class DataHelper
    {
        public static IElasticClient _elastic { get; set; }
        public static string connectionstring = System.Configuration.ConfigurationManager.
    ConnectionStrings["DBConnection"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionstring);
        SqlCommand DBCommand;
        SqlDataReader DataReader;
        public List<Members> GetMembers(string name, string dimID)
        {
            string TableName = GetTableName(name);
            List<Members> segmentMembers = new List<Members>();
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();
                if (name.Equals("Scenario"))
                {
                    DBCommand = new SqlCommand(" " + TableName, connection);

                }
                else
                {
                    DBCommand = new SqlCommand("SELECT  " + TableName, connection);

                }
                DataReader = DBCommand.ExecuteReader();
                DataTable dt = new DataTable();
                while (DataReader.Read())
                {
                    var segmentMember = new Members()
                    {
                        ID = DataReader.GetValue(0).ToString(),
                        Label = DataReader.GetValue(1).ToString(),
                        ParentID = DataReader.GetValue(2).ToString(),
                        LeftVal = DataReader.GetValue(3).ToString(),
                        RightVal = DataReader.GetValue(4).ToString(),
                        LevelVal = DataReader.GetValue(5).ToString(),

                        ParentDimenison = dimID

                    };
                    segmentMembers.Add(segmentMember);
                }
                DataReader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return segmentMembers;
        }


       
        public List<Dimensions> GetDimensions()
        {


            List<Dimensions> Dims = new List<Dimensions>();
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();
                DBCommand = new SqlCommand("select ", connection);
                DataReader = DBCommand.ExecuteReader();
                DataTable dt = new DataTable();
                while (DataReader.Read())
                {
                    var Dim = new Dimensions()
                    {
                        Tablename = DataReader.GetValue(0).ToString(),
                        Displayname = DataReader.GetValue(1).ToString(),

                    };
                    Dims.Add(Dim);

                }
                DataReader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Dims;
        }

        public string GetTableName(string type)
        {
            string TableName = "";
            //removing tablenames in order to not expose private data
            if (type == "t")
            {
                TableName = "a"; 
            }
            else if (type == "g")
            {
                TableName = "a";
            }
            if (type == "c")
                TableName = "a";
            if (type == "i")
                TableName = "a";
            if (type == "d")
                TableName = "a";
            return TableName;
        }

    }
}
