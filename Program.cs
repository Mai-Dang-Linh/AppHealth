using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public struct InforPerson
{
    string sName;
    string sAddress;
    string sSignsResult;
    int sAge;
    public void EnterInfor()
    {
        
        Console.Write("Enter Name: ");
        this.sName = Console.ReadLine();
        Console.Write("Enter Address: ");
        this.sAddress = Console.ReadLine();
        Console.Write("Enter Age: ");
        sAge = Convert.ToInt32(Console.ReadLine());
       Console.Write("Enter Signs Result: ");
       this.sSignsResult = Console.ReadLine();

    }
    public string Insert()
    {
        string sql = "";
        sql = "INSERT INTO DECLAREINFORPERSON(NAME,ADDRESS,AGE,SIGNSRESULT) VALUES('" + this.sName + "','" + this.sAddress + "',"+ sAge.ToString()+",'"+ this.sSignsResult +"'); ";
        return sql;
    }
    public void Display()
    {
        Console.WriteLine($"Name : {sName}");
        Console.WriteLine($"Address : {sAddress}");
        Console.WriteLine($"Age : {sAge}");
    }
    InforPerson(string Name, string Address,string SignsResult, int Age)
    {
        sName = Name;
        sAddress = Address;
        sSignsResult = SignsResult;
        sAge = Age;
    }
}

namespace SQLiteDBDemo
{
    class Program
    {
        
        static void Main(string[] args) 
        {
            InforPerson infor = new InforPerson();
            infor.EnterInfor();
            Console.WriteLine( infor.Insert());

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            CreateTable();
            InsertData(infor.Insert());
            ReadData();
        }

        //static SQLiteConnection CreateConnection()
        //{
        //    SQLiteConnection sqlite_conn;
        //    sqlite_conn = new SQLiteConnection("Data Source = MyDatabase.db;Version =3;");

        //    sqlite_conn.Open();
        //    return sqlite_conn;
      
        //}
        static  void CreateTable()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            if (!File.Exists("MyDatabase.db"))
            {    
                SQLiteConnection.CreateFile("MyDatabase.db");
                string sql = @"CREATE TABLE  [DECLAREINFORPERSON](
                [NAME]          VARCHAR(30)  NOT NULL,
                [ADDRESS]       VARCHAR(225) NOT NULL, 
                [AGE]           INT          NOT NULL,
                [SIGNSRESULT]   VARCHAR(35)  NULL
                )";
                sqlite_conn = new SQLiteConnection("Data Source= MyDatabase.db;Version=3;");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sql, sqlite_conn);
                sqlite_cmd.ExecuteNonQuery();
                sqlite_conn.Close();
            }
            else
            {
                sqlite_conn = new SQLiteConnection("Data Source = MyDatabase.db;Version =3;");
            } 
                
        }
        
        static void InsertData(string sql)
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source= MyDatabase.db;Version=3;"); 
            SQLiteCommand sqlite_cmd;

            sqlite_cmd = new SQLiteCommand();
            sqlite_conn.Open();
            sqlite_cmd.Connection = sqlite_conn;
            sqlite_cmd.CommandText = sql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
        static  void ReadData()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source= MyDatabase.db;Version=3;");
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            string sql = "SELECT * FROM DECLAREINFORPERSON";
            sqlite_cmd = new SQLiteCommand(sql, sqlite_conn);
            sqlite_conn.Open();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
            
                Console.WriteLine("NAME: "+ sqlite_datareader["NAME"] + "\t ADDRESS: " 
                    + sqlite_datareader["ADDRESS"]  +"\tAGE: "+ sqlite_datareader["AGE"] + "\tSIGNSRESULT: " + sqlite_datareader["SIGNSRESULT"]);
            }
            sqlite_conn.Close();
        }

    }
}
