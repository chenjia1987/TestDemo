using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static System.Console;

using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;

using MongoDBFactory;

namespace ConsoleApp1
{
    public class Program
    {
        #region 测试
        public static void Main(string[] args)
        {
            //Test1 t1 = new Test1();
            //WriteLine("Test1.Method1");
            //t1.Method1();

            //Test2 t2 = new Test2();
            //WriteLine("Test2.Method1");
            //t2.Method1();

            Customs customs = new Customs
            {
                ID = 1,
                Name = "Customs",
                users = new Users
                {
                    FirstName = "Jia",
                    LastName = "Chen",
                    Sex = "Men",
                    Age = 32
                },
                users1 = new Users1
                {
                    FirstName = "Meng",
                    LastName = "Xu",
                    Sex = "Women"
                }
            };

            MongoDBHelper<Customs> mongoDBHelper = new MongoDBHelper<Customs>(host: "192.168.206.10", port: 27017);
            mongoDBHelper.InsertOne(customs);

            //Customs customs1 = new Customs();
            //customs1 = mongoDBHelper.FindOne("5c498f4352b81ad6c275b736");
            //WriteLine(JsonConvert.SerializeObject(customs1));
        }
        #endregion
    }

    public class Users
    {
        public ObjectId _id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }

    public class Users1
    {
        public ObjectId _id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
    }

    public class Customs
    {
        public ObjectId _id;
        public int ID { get; set; }
        public String Name { get; set; }
        public Users users { get; set; }
        public Users1 users1 { get; set; }
    }
}