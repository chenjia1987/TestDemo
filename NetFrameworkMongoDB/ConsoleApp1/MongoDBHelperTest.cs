using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

using MongoDB.Driver;
using MongoDB.Bson;

using MongoDBHelper;

namespace ConsoleApp1
{
    class MongoDBHelperTest
    {
        public MongoDBHelperTest() { }
        public void Method1()
        {
            MDBHelper<Users> mdbHelper = new MDBHelper<Users>();

            Users users = new Users();
            users.FirstName = "FirstName";
            users.LastName = "LastName";
            users.Sex = "Sex";
            users.Age = 18;

            FilterDefinition<Users> filter =
                Builders<Users>.Filter.Eq("FirstName", "Jia2")
                | Builders<Users>.Filter.Eq("Age", "18"); //查询条件

            #region 查找
            Users user1 = mdbHelper.Find(filter).First();
            WriteLine(user1.ToJson());
            #endregion

            #region 新增
            //if (mdbHelper.InsertOne(users))
            //{
            //    WriteLine("插入成功");
            //}
            //else
            //{
            //    WriteLine("插入失败");
            //}
            //WriteLine(users._id);
            #endregion

            #region 修改
            //var update2 = Builders<Users>.Update.Set("FirstName", "Jia").Set("LastName", "Chen").Inc("Age", 12);
            //if (mdbHelper.UpdateOne(filter, update2))
            //{
            //    WriteLine("修改成功！");
            //}
            //else
            //{
            //    WriteLine("修改失败！");
            //}
            #endregion

            #region 删除
            //if (mdbHelper.DeleteOne(filter))
            //{
            //    WriteLine("删除成功！");
            //}
            //else
            //{
            //    WriteLine("删除失败！");
            //}
            #endregion
        }
    }
}
