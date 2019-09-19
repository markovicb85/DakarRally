using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakarRallyDataAccess
{
    public class SQLiteDataAccess
    {
        private static SQLiteDataAccess instance;

        protected SQLiteDataAccess()
        {
            CreateTables();
        }

        public static SQLiteDataAccess InstanceDB()
        {
            if(instance == null)
            {
                instance = new SQLiteDataAccess();
            }
            return instance;
        }

        public static string GetConnectionString(string conectionName = "Default")
        {
            return ConfigurationManager.ConnectionStrings[conectionName].ConnectionString;
        }
        
        private void CreateTables()
        {
            using (SQLiteConnection con = new SQLiteConnection(GetConnectionString()))
            {
                con.Open();
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT name FROM sqlite_master WHERE name='vehicletable'";

                var name = cmd.ExecuteScalar();

                // Check vehicle table exist or not, if not exist create table                 
                if (!IsTableExist("vehicletable"))
                {
                    // vehicle table not exist, create table 
                    cmd.CommandText = @"CREATE TABLE vehicletable 
                                        (
                                            VehicleId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                                            TeamName TEXT,
                                            Model TEXT,
                                            ManufacturingDate TEXT,
                                            Speed INTEGER,
                                            LightMalFun INTEGER,
                                            HeavyMalFun INTEGER,
                                            RaceId INTEGER,
                                            RaceStatus INTEGER,
                                            Distance INTEGER,
                                            MalFunctionStatus INTEGER,
                                            Time INTEGER
                                        )";
                    cmd.ExecuteNonQuery();

                }

                // Check race table exist or not, if not exist create table
                if (!IsTableExist("racetable"))
                {
                    cmd.CommandText = @"CREATE TABLE racetable  
                                        ( 
                                            RaceId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, 
                                            RaceStatus INTEGER,
                                            Distance INTEGER,
                                            Year INTEGER
                                        )";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Boolean IsTableExist(string tblName)
        {
            using (SQLiteConnection con = new SQLiteConnection(GetConnectionString()))
            {
                con.Open();
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT name FROM sqlite_master WHERE name= @tblName";
                cmd.Parameters.Add(new SQLiteParameter("@tblName", tblName));
                var name = cmd.ExecuteScalar();

                // Check account table exist or not, if exist do nothing                 
                if (name != null && name.ToString() == tblName)
                    return true;
            }
            return false;
        }
    }
}
