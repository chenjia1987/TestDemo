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
    class Test2
    {
        //连接地址
        private static string conn = "mongodb://127.0.0.1:27017";
        //数据库名称
        private static string dbName = "TestDB";
        //集合名称
        private static string colName = "TestColl1";
        //连接服务端
        static MongoClient client = new MongoClient(conn);
        //获取指定数据库
        static IMongoDatabase db = client.GetDatabase(dbName);
        //获取指定集合   BsonDocument数据库文档对象
        static IMongoCollection<BsonDocument> coll = db.GetCollection<BsonDocument>(colName);

        public Test2() { }

        public void Method1()
        {
            var doc = new[] {
                new BsonDocument{
                    { "DepartmentName", "开发部"},
                    { "People", new BsonArray {
                            new BsonDocument{ { "Name", "狗娃" }, {"Age", 20 } },
                            new BsonDocument{ { "Name", "狗剩" }, {"Age", 22 } },
                            new BsonDocument{ { "Name", "铁蛋" }, {"Age", 24 } }
                        }
                    },
                    { "Sum", 18 },
                    { "dim_cm", new BsonArray { 14, 21 } }
                },
                new BsonDocument{
                    { "DepartmentName", "测试部"},
                    { "People",new  BsonArray {
                            new BsonDocument{ { "Name", "张三" }, {"Age", 11 } },
                            new BsonDocument{ { "Name", "李四" }, {"Age", 34 } },
                            new BsonDocument{ { "Name", "王五" }, {"Age", 33 } }
                        }
                    },
                    { "Sum",4 },
                    { "dim_cm", new BsonArray { 14, 21 } }
                },
                new BsonDocument{
                    { "DepartmentName", "运维部"},
                    { "People", new BsonArray {
                            new BsonDocument{ { "Name", "闫" }, {"Age", 20 } },
                            new BsonDocument{ { "Name", "王" }, {"Age", 22 } },
                            new BsonDocument{ { "Name", "赵" }, {"Age", 24 } }
                        }
                    },
                    { "Sum", 2 },
                    { "dim_cm", new BsonArray { 22.85, 30 } }
                }
            };

            #region 新增
            //coll.InsertMany(doc);
            #endregion

            #region 查询
            ////查询部门是开发部的信息
            ////创建约束生成器
            //FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            ////约束条件
            //FilterDefinition<BsonDocument> filter = builderFilter.Eq("DepartmentName", "开发部");
            ////获取数据
            //var result = coll.Find<BsonDocument>(filter).ToList();
            //foreach (var item in result)
            //{
            //    //取出整条值
            //    Console.WriteLine(item);
            //}

            //创建约束生成器
            FilterDefinitionBuilder<BsonDocument> builderFIlter = Builders<BsonDocument>.Filter;
            //约束条件
            FilterDefinition<BsonDocument> filter = builderFIlter.Gt("Sum", 4);
            var result = coll.Find<BsonDocument>(filter).ToList();
            foreach (var item in result)
            {
                //取出整条值
                Console.WriteLine(item);
            }

            ////And约束
            ////创建约束生成器
            //FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            ////约束条件
            //FilterDefinition<BsonDocument> filter = builderFilter.And(builderFilter.Gte("Sum", 2), builderFilter.Eq("DepartmentName", "运维部"));
            //var result = coll.Find<BsonDocument>(filter).ToList();
            //foreach (var item in result)
            //{
            //    //取出整条值
            //    Console.WriteLine(item.AsBsonValue);
            //}

            ////查询指定值
            ////创建约束生成器
            //FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            //ProjectionDefinitionBuilder<BsonDocument> builderProjection = Builders<BsonDocument>.Projection;
            ////Include 包含某元素    Exclude  不包含某元素
            //ProjectionDefinition<BsonDocument> projection = builderProjection.Include("DepartmentName").Exclude("_id");
            //var result = coll.Find<BsonDocument>(builderFilter.Empty).Project(projection).ToList();
            //foreach (var item in result)
            //{
            //    //取出整条值
            //    Console.WriteLine(item);
            //}

            ////排序
            ////创建生成器
            //FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            ////排序生成器
            //SortDefinitionBuilder<BsonDocument> builderSort = Builders<BsonDocument>.Sort;
            ////排序约束   Ascending 正序    Descending 倒序
            //SortDefinition<BsonDocument> sort = builderSort.Descending("Sum");
            //var result = coll.Find<BsonDocument>(builderFilter.Empty).Sort(sort).ToList();
            //foreach (var item in result)
            //{
            //    //取出整条值
            //    Console.WriteLine(item.AsBsonValue);
            //}

            ////In查询
            ////创建生成器
            //FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            //FilterDefinition<BsonDocument> filter = builderFilter.In("DepartmentName", new[] { "测试部", "开发部" });
            //var result = coll.Find<BsonDocument>(filter).ToList();
            //foreach (var item in result)
            //{
            //    //取出整条值
            //    Console.WriteLine(item.AsBsonValue);
            //}

            ////分页查询
            ////创建生成器
            //FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            ////分页 Skip 跳过 Limit查询多少
            //var result = coll.Find<BsonDocument>(builderFilter.Empty).Skip(1).Limit(1).ToList();
            //foreach (var item in result)
            //{
            //    //取出整条值
            //    Console.WriteLine(item.AsBsonValue);
            //}

            ////查询总条目数
            ////创建生成器
            //FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            ////总条目数
            //var result = coll.Find<BsonDocument>(builderFilter.Empty).Count();
            //WriteLine(result);

            ////创建生成器
            //linq
            //var result = 
            //    from y 
            //    in coll.AsQueryable()
            //    select new { DepartmentName = y["DepartmentName"], id = y["_id"] };
            //foreach (var item in result)
            //{
            //    Console.WriteLine("DepartmentName:" + item.DepartmentName + "====Id:" + item.id);
            //}

            ////linq
            ////连表查询   在这里是自己连自己
            ////创建生成器
            //FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter;
            ////分组
            //var result = 
            //    from y 
            //    in coll.AsQueryable()
            //    group y by y["DepartmentName"] into s
            //    select new { DepartmentName = s.Key, Count = s.Count() };
            //foreach (var item in result)
            //{
            //    Console.WriteLine("DepartmentName:" + item.DepartmentName + "====Count:" + item.Count);
            //}

            //linq
            //连表查询   在这里是自己连自己
            var result = 
                from u in coll.AsQueryable()
                join o in coll.AsQueryable() on u["_id"] equals o["_id"]
                select new { DepartmentName1 = u["DepartmentName"], DepartmentName2 = u["DepartmentName"] };
            foreach (var item in result)
            {
                Console.WriteLine("DepartmentName1:" + item.DepartmentName1 + "====DepartmentName2:" + item.DepartmentName2);
            }
            #endregion
        }
    }
}
