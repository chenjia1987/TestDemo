using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDBHelper
{
    /// <summary>
    /// 适用于 2.7 之后的版本
    /// </summary>
    /// <typeparam name="TDocument"></typeparam>
    public class MDBHelper<TDocument>
    {
        #region 字段/属性
        private string _Host;
        /// <summary>
        /// Host：127.0.0.1
        /// </summary>
        public string Host
        {
            get { return _Host; }
            set { _Host = value; }
        }

        private int _Port;
        /// <summary>
        /// Port：27017
        /// </summary>
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        private IMongoDatabase _Database;
        /// <summary>
        /// Mongo DataBase
        /// </summary>
        public IMongoDatabase Database
        {
            get { return _Database; }
            set { _Database = value; }
        }

        private IMongoClient _Client;
        /// <summary>
        /// Mongo Client
        /// </summary>
        public IMongoClient Client
        {
            get { return _Client; }
            set { _Client = value; }
        }

        private IMongoCollection<TDocument> _Collection;
        /// <summary>
        /// Mongo Collection
        /// </summary>
        public IMongoCollection<TDocument> Collection
        {
            get { return _Collection; }
            set { _Collection = value; }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="database"></param>
        /// <param name="collection"></param>
        public MDBHelper(string host = "127.0.0.1", int port = 27017, string database = "TestDB", string collection = "TestColl")
        {
            try
            {
                MongoClientSettings settings = new MongoClientSettings(); //实例化 MongoClientSettings
                settings.Server = new MongoServerAddress(host, port); //设置地址和端口

                this._Client = new MongoClient(settings); //创建连接
                this._Database = this._Client.GetDatabase(database); //连接数据库
                this._Collection = this._Database.GetCollection<TDocument>(collection); //连接集合 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查找文档个数
        /// </summary>
        /// <param name="bsonDocument"></param>
        /// <returns></returns>
        public int CountDocuments(BsonDocument bsonDocument)
        {
            int result = 0;
            if (!Object.Equals(bsonDocument, null))
            {
                result = (int)this._Collection.CountDocuments(bsonDocument);
            }
            return result;
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="filterDefintion"></param>
        /// <returns></returns>
        public IFindFluent<TDocument, TDocument> Find(FilterDefinition<TDocument> filterDefintion)
        {
            return Collection.Find(filterDefintion);
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="bsonDocument"></param>
        /// <returns></returns>
        public bool InsertOne(TDocument bsonDocument)
        {
            bool result = false;
            if(!Object.Equals(bsonDocument, null))
            {
                try
                {
                    this._Collection.InsertOne(bsonDocument);
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <param name="bList"></param>
        /// <returns></returns>
        public int InsertMany(List<TDocument> bList)
        {
            int result = 0;
            this._Collection.InsertMany(bList);
            return result;
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="filterDefintion">
        ///     var And = Builders<TDocument>.Filter.Eq("name", "MongoDB") & filter.Eq("count", "1");
        ///     var Or = Builders<TDocument>.Filter.Eq("name", "MongoDB") | filter.Eq("count", "1");
        /// </param>
        /// <param name="update">
        ///     var update1 = Builders<Users>.Update.Set("name", "SQL Server").Set("count", 999);
        ///     var update2 = Builders<Users>.Update.Set("name", "SQL Server1").Inc("count", 999);
        /// </param>
        /// <returns></returns>
        public bool UpdateOne(FilterDefinition<TDocument> filterDefintion, UpdateDefinition<TDocument> update)
        {
            bool result = false;
            try
            {
                UpdateResult updateResult = this._Collection.UpdateOne(filterDefintion, update);
                if (updateResult.ModifiedCount > 0) result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 修改多条数据
        /// </summary>
        /// <param name="filterDefintion"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public bool UpdateMany(FilterDefinition<TDocument> filterDefintion, UpdateDefinition<TDocument> update)
        {
            bool result = false;
            try
            {
                UpdateResult updateResult = this._Collection.UpdateMany(filterDefintion, update);
                if (updateResult.ModifiedCount > 0) result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }
        
        /// <summary>
        /// 删除第一条匹配的数据
        /// </summary>
        /// <param name="filterDefintion"></param>
        /// <returns></returns>
        public bool DeleteOne(FilterDefinition<TDocument> filterDefintion)
        {
            bool result = false;
            try
            {
                if ((this._Collection.DeleteOne(filterDefintion)).DeletedCount > 0) result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 删除所有匹配的数据
        /// </summary>
        /// <param name="filterDefintion"></param>
        /// <returns></returns>
        public bool DeleteMany(FilterDefinition<TDocument> filterDefintion)
        {
            bool result = false;
            try
            {
                if (this._Collection.DeleteMany(filterDefintion).DeletedCount > 0) result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }
    }
}