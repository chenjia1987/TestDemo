using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

using MongoDB.Driver;
using MongoDB.Bson;

namespace ConsoleApp1
{
    class Test1
    {
        public Test1() { }

        public void Method1()
        {
            #region 创建连接

            #region 使用 MongoUrlBuilder 创建 MongoClient
            //MongoUrlBuilder mongoUrl = new MongoUrlBuilder("mongodb://127.0.0.1:27017/TestDB"); 
            //MongoClient Client = new MongoClient(mongoUrl.ToMongoUrl());
            #endregion

            #region 使用 MongoClientSettings 创建 MongoClient
            //MongoClientSettings mongoClientSettings = new MongoClientSettings();
            //mongoClientSettings.Server = new MongoServerAddress("127.0.0.1:27017");
            //MongoClient Client = new MongoClient(mongoClientSettings);
            #endregion

            #region 使用 连接字符串 创建 MongoClient
            MongoClient Client = new MongoClient("mongodb://127.0.0.1:27017/");
            #endregion

            #region 使用默认连接 创建 MongoClient
            //MongoClient Client = new MongoClient();
            #endregion

            #endregion

            IMongoDatabase Database = Client.GetDatabase("TestDB"); //连接数据库
            IMongoCollection<BsonDocument> collection = Database.GetCollection<BsonDocument>("TestColl"); //连接集合 

            #region 声明 BsonDocument
            var bsonDocument1 = new BsonDocument{
                { "_id", ObjectId.Empty},
                { "FirstName", "Jia1"},
                { "LastName", "Chen1"},
                { "Sex", "Men"},
                { "Age", 30}
            };

            BsonDocument bsonDocument2 = new BsonDocument
            {
                { "_id", ObjectId.Empty },
                { "FirstName", "Jia" },
                { "LastName", "Chen" },
                { "Sex", "Men" },
                { "Age", 35 }
            };

            //var bsonDocument3 = new[] {
            //    new BsonDocument{
            //        { "DepartmentName", "开发部"},
            //        { "People", new BsonArray {
            //                new BsonDocument{ { "Name", "狗娃" }, {"Age", 20 } },
            //                new BsonDocument{ { "Name", "狗剩" }, {"Age", 22 } },
            //                new BsonDocument{ { "Name", "铁蛋" }, {"Age", 24 } }
            //            }
            //        },
            //        { "Sum", 18 },
            //        { "dim_cm", new BsonArray { 14, 21 } }
            //    }
            //};
            #endregion

            #region 新增
            //collection.InsertOne(bsonDocument1);
            //collection.InsertOne(bsonDocument2);
            //Console.WriteLine($"bsonDocument1._id{bsonDocument1["_id"]}");
            //Console.WriteLine($"bsonDocument2._id{bsonDocument2["_id"]}");
            //Console.WriteLine(collection.Find(bsonDocument1));
            #endregion

            #region 查询

            #region 查询文档个数
            //var count = collection.CountDocuments(x => x["Age"] == 35);
            //Console.WriteLine(count);
            #endregion

            #region 查询文档

            FilterDefinitionBuilder<BsonDocument> filterBuilder = Builders<BsonDocument>.Filter; //查询条件 Builder
            ProjectionDefinitionBuilder<BsonDocument> projectionBuilder = Builders<BsonDocument>.Projection; //查询列 Builder
            SortDefinitionBuilder<BsonDocument> sortBuilder = Builders<BsonDocument>.Sort; //排序 Builder
            FilterDefinition<BsonDocument> filter = filterBuilder.Empty;

            #region 查询条件

            #region 使用 FilterDefinition 查询
            //And
            //filter =
            //        Builders<BsonDocument>.Filter.Eq("FirstName", "Jia1")
            //        & Builders<BsonDocument>.Filter.Eq("LastName", "Chen1");

            //filter =
            //        Builders<BsonDocument>.Filter.And(
            //            Builders<BsonDocument>.Filter.Eq("FirstName", "Jia1"),
            //            Builders<BsonDocument>.Filter.Eq("LastName", "Chen1")
            //        );

            //filter =
            //    filterBuilder.And(
            //        filterBuilder.Eq("FirstName", "Jia1"),
            //        filterBuilder.Eq("LastName", "Chen1")
            //    );

            //Or
            //filter =
            //        Builders<BsonDocument>.Filter.Eq("FirstName", "Jia1")
            //        | Builders<BsonDocument>.Filter.Eq("Age", 40);

            // >
            //filter = Builders<BsonDocument>.Filter.Gt("Age", 35);

            // <
            //filter = Builders<BsonDocument>.Filter.Lt("Age", 30);

            // >=
            //filter = Builders<BsonDocument>.Filter.Gte("Age", 35);

            // <=
            //filter = Builders<BsonDocument>.Filter.Lte("Age", 30);

            //查询全部
            //filter = Builders<BsonDocument>.Filter.Empty;

            //In
            //filter = filterBuilder.In("FirstName", new[] { "Jia2", "Jia1" });

            //查找ID
            //filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("5c498f4352b81ad6c275b736"));

            #endregion

            #region 使用 BsonDocument 查询
            //查询全部
            //filter = new BsonDocument();

            //查询 FirstName = "Jia1"
            //filter = new BsonDocument { { "FirstName", "Jia1" } };
            #endregion

            #region 使用 Lambda 表达式查询
            //var bDocument = collection.Find(x => x["Age"] == 30).FirstOrDefault();
            //Console.WriteLine(bDocument.ToJson());

            //var list =
            //    from y
            //    in collection.AsQueryable()
            //    select new { FirstName = y["FirstName"], id = y["_id"] };

            #endregion

            #endregion

            #region 指定列            
            ProjectionDefinition<BsonDocument> projection = projectionBuilder.Include("FirstName").Include("Age").Exclude("_id");
            #endregion

            #region 排序
            //排序约束   Ascending 正序    Descending 倒序
            SortDefinition<BsonDocument> sort = sortBuilder.Descending("Age");
            #endregion

            var list = collection
                .Find(filter) //查询条件
                //.Project(projection) //查询列
                .Skip(0) //跳过多少
                .Limit(0) //取多少
                .Sort(sort)
                .ToList();
            //var list = Task.Run(async () => await collection.Find(filter).ToListAsync()).Result; //异步查询
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            #endregion

            #endregion

            #region 更新
            //var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("5c35a3db8f99ab244c95148c"));
            //var update = Builders<BsonDocument>.Update.Set("FirstName", "Jia").Inc("Age", 12);
            //UpdateResult updateResult = collection.UpdateMany(filter, update);
            //Console.WriteLine(updateResult.ModifiedCount);
            #endregion

            #region 删除
            //var filter1 = Builders<BsonDocument>.Filter.Eq("Age", 30);
            //collection.DeleteMany(x => x["Age"] == 30); //删除全部匹配数据
            //collection.DeleteMany(filter1); //删除全部匹配数据
            #endregion
        }
    }
}
