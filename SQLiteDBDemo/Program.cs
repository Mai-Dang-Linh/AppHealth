using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

namespace SQLiteDBDemo
{
    class Program
    {
       
        static void Main(string[] args) 
        {
            InforPerson infor = new InforPerson();
            infor.EnterInfor();
            Console.WriteLine(infor.Insert());
            //infor.Display();

            SQLiteConnection.CreateFile("MyDatabase.db");

            SQLiteConnection dataPerson;
            dataPerson = CreateConnection();
            CreateTable(dataPerson);
            InsertData(dataPerson);
            InsertData(dataPerson, infor.Insert());
            ReadData(dataPerson);
        }

        static SQLiteConnection CreateConnection()
        {
         //   SQLiteConnection.CreateFile("MyDatabase.sqlite");
            SQLiteConnection sqlite_conn;
           sqlite_conn = new SQLiteConnection("Data Source = MyDatabase.db;Version =3;");

            sqlite_conn.Open();
            return sqlite_conn;
      
        }
        static void CreateTable(SQLiteConnection conn)
        {
         
            SQLiteCommand sqlite_cmd;
            string sql = @"CREATE TABLE  [DECLAREINFORPERSON](
                [NAME]          VARCHAR(30)  NOT NULL,
                [ADDRESS]       VARCHAR(225) NOT NULL, 
                [AGE]           INT          NOT NULL,
                [SIGNSRESULT]   VARCHAR(35)  NULL
                )";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sql;
            sqlite_cmd.ExecuteNonQuery();
      
        }
        static void InsertData(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO DECLAREINFORPERSON(NAME,ADDRESS,AGE,SIGNSRESULT) VALUES('Mai Dang Linh','Da Nang',24,'COUGH'); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO DECLAREINFORPERSON(NAME,ADDRESS,AGE,SIGNSRESULT) VALUES('Le Viet Hieu','Da Nang',24,'COUGH');";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO DECLAREINFORPERSON(NAME,ADDRESS,AGE,SIGNSRESULT) VALUES('Le Truong Lam','Hue',22,'COUGH');";

            sqlite_cmd.ExecuteNonQuery();
        }
        static void InsertData(SQLiteConnection conn,string sql)
        {
            
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sql;
            sqlite_cmd.ExecuteNonQuery();
        }
        static void ReadData(SQLiteConnection conn)
        {
            
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM DECLAREINFORPERSON";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
            //    string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine("NAME: "+ sqlite_datareader["NAME"] + "ADDRESS: " 
                    + sqlite_datareader["ADDRESS"]  +"AGE: "+ sqlite_datareader["AGE"] + "SIGNSRESULT" + sqlite_datareader["SIGNSRESULT"]);
            }
            conn.Close();
        }

    }
}
