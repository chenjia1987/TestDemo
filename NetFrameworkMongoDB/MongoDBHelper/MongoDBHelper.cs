using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBFactory
{
    public class MongoDBHelper<T> where T : class, new()
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

        private IMongoCollection<T> _Collection;
        /// <summary>
        /// Mongo Collection
        /// </summary>
        public IMongoCollection<T> Collection
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
        /// <param name="databaseName"></param>
        /// <param name="collectionName"></param>
        public MongoDBHelper(string host = "127.0.0.1", int port = 27017, string databaseName = "TestDB", string collectionName = "TestColl")
        {
            try
            {
                MongoClientSettings settings = new MongoClientSettings(); //实例化 MongoClientSettings
                settings.Server = new MongoServerAddress(host, port); //设置地址和端口

                this._Client = new MongoClient(settings); //创建连接
                this._Database = this._Client.GetDatabase(databaseName); //连接数据库
                this._Collection = this._Database.GetCollection<T>(collectionName); //连接集合 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="database"></param>
        /// <param name="collection"></param>
        public MongoDBHelper(string connectionString, string database = "TestDB", string collection = "TestColl")
        {
            try
            {
                this._Client = new MongoClient(connectionString); //创建连接
                this._Database = this._Client.GetDatabase(database); //连接数据库
                this._Collection = this._Database.GetCollection<T>(collection); //连接集合 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region +Add 添加一条数据
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public int InsertOne(T t)
        {
            try
            {
                this._Collection.InsertOne(t);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region +InsertOneAsync 异步添加一条数据
        /// <summary>
        /// 异步添加一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public async Task<int> InsertOneAsync(T t)
        {
            try
            {
                await this._Collection.InsertOneAsync(t);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region +InsertMany 批量插入
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="t">实体集合</param>
        /// <returns></returns>
        public int InsertMany(List<T> t)
        {
            try
            {
                this._Collection.InsertMany(t);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region +InsertManyAsync 异步批量插入
        /// <summary>
        /// 异步批量插入
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="t">实体集合</param>
        /// <returns></returns>
        public async Task<int> InsertManyAsync(List<T> t)
        {
            try
            {
                await this._Collection.InsertManyAsync(t);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region +Update 修改一条数据
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public UpdateResult Update(T t, string id, bool isObjectId = true)
        {
            try
            {
                //修改条件
                FilterDefinition<T> filter;
                if (isObjectId)
                {
                    filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                }
                else
                {
                    filter = Builders<T>.Filter.Eq("_id", id);
                }

                //要修改的字段
                var list = new List<UpdateDefinition<T>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (item.Name.ToLower() == "id") continue;
                    list.Add(Builders<T>.Update.Set(item.Name, item.GetValue(t)));
                }
                var updatefilter = Builders<T>.Update.Combine(list);

                return this._Collection.UpdateOne(filter, updatefilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region +UpdateAsync 异步修改一条数据
        /// <summary>
        /// 异步修改一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateAsync(T t, string id, bool isObjectId)
        {
            try
            {
                //修改条件
                FilterDefinition<T> filter;
                if (isObjectId)
                {
                    filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                }
                else
                {
                    filter = Builders<T>.Filter.Eq("_id", id);
                }
                //要修改的字段
                var list = new List<UpdateDefinition<T>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (item.Name.ToLower() == "id") continue;
                    list.Add(Builders<T>.Update.Set(item.Name, item.GetValue(t)));
                }
                var updatefilter = Builders<T>.Update.Combine(list);
                return await this._Collection.UpdateOneAsync(filter, updatefilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region +UpdateManay 批量修改数据
        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="dic">要修改的字段</param>
        /// <param name="filter">修改条件</param>
        /// <returns></returns>
        public UpdateResult UpdateManay(Dictionary<string, string> dic, FilterDefinition<T> filter)
        {
            try
            {
                T t = new T();
                //要修改的字段
                var list = new List<UpdateDefinition<T>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (!dic.ContainsKey(item.Name)) continue;
                    var value = dic[item.Name];
                    list.Add(Builders<T>.Update.Set(item.Name, value));
                }
                var updatefilter = Builders<T>.Update.Combine(list);
                return this._Collection.UpdateMany(filter, updatefilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region +UpdateManayAsync 异步批量修改数据
        /// <summary>
        /// 异步批量修改数据
        /// </summary>
        /// <param name="dic">要修改的字段</param>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">修改条件</param>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateManayAsync(Dictionary<string, string> dic, FilterDefinition<T> filter)
        {
            try
            {
                T t = new T();
                //要修改的字段
                var list = new List<UpdateDefinition<T>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (!dic.ContainsKey(item.Name)) continue;
                    var value = dic[item.Name];
                    list.Add(Builders<T>.Update.Set(item.Name, value));
                }
                var updatefilter = Builders<T>.Update.Combine(list);
                return await this._Collection.UpdateManyAsync(filter, updatefilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectId</param>
        /// <returns></returns>
        public DeleteResult Delete(string id, bool isObjectId = true)
        {
            try
            {
                FilterDefinition<T> filter;
                if (isObjectId)
                {
                    filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                }
                else
                {
                    filter = Builders<T>.Filter.Eq("_id", id);
                }
                return this._Collection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region DeleteAsync 异步删除一条数据
        /// <summary>
        /// 异步删除一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectId</param>
        /// <returns></returns>
        public async Task<DeleteResult> DeleteAsync(string id, bool isObjectId = true)
        {
            try
            {
                //修改条件
                FilterDefinition<T> filter;
                if (isObjectId)
                {
                    filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                }
                else
                {
                    filter = Builders<T>.Filter.Eq("_id", id);
                }
                return await this._Collection.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region DeleteMany 删除多条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">删除的条件</param>
        /// <returns></returns>
        public DeleteResult DeleteMany(FilterDefinition<T> filter)
        {
            try
            {
                return this._Collection.DeleteMany(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region DeleteManyAsync 异步删除多条数据
        /// <summary>
        /// 异步删除多条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">删除的条件</param>
        /// <returns></returns>
        public async Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter)
        {
            try
            {
                return await this._Collection.DeleteManyAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Count 根据条件获取总数
        /// <summary>
        /// 根据条件获取总数
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public long Count(FilterDefinition<T> filter)
        {
            try
            {
                return this._Collection.CountDocuments(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CountAsync 异步根据条件获取总数
        /// <summary>
        /// 异步根据条件获取总数
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public async Task<long> CountAsync(FilterDefinition<T> filter)
        {
            try
            {
                return await this._Collection.CountDocumentsAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindOne 根据id查询一条数据
        /// <summary>
        /// 根据id查询一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectid</param>
        /// <param name="field">要查询的字段，不写时查询全部</param>
        /// <returns></returns>
        public T FindOne(string id, bool isObjectId = true, string[] field = null)
        {
            try
            {
                FilterDefinition<T> filter;
                if (isObjectId)
                {
                    filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                }
                else
                {
                    filter = Builders<T>.Filter.Eq("_id", id);
                }
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    return this._Collection.Find(filter).FirstOrDefault<T>();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();
                return this._Collection.Find(filter).Project<T>(projection).FirstOrDefault<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindOneAsync 异步根据id查询一条数据
        /// <summary>
        /// 异步根据id查询一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectid</param>
        /// <returns></returns>
        public async Task<T> FindOneAsync(string id, bool isObjectId = true, string[] field = null)
        {
            try
            {
                FilterDefinition<T> filter;
                if (isObjectId)
                {
                    filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                }
                else
                {
                    filter = Builders<T>.Filter.Eq("_id", id);
                }

                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    return await this._Collection.Find(filter).FirstOrDefaultAsync();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();
                return await this._Collection.Find(filter).Project<T>(projection).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindList 查询集合
        /// <summary>
        /// 查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public List<T> FindList(FilterDefinition<T> filter, string[] field = null, SortDefinition<T> sort = null)
        {
            try
            {
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return this._Collection.Find(filter).ToList();
                    //进行排序
                    return this._Collection.Find(filter).Sort(sort).ToList();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();
                if (sort == null) return this._Collection.Find(filter).Project<T>(projection).ToList();
                //排序查询
                return this._Collection.Find(filter).Sort(sort).Project<T>(projection).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindListAsync 异步查询集合
        /// <summary>
        /// 异步查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public async Task<List<T>> FindListAsync(FilterDefinition<T> filter, string[] field = null, SortDefinition<T> sort = null)
        {
            try
            {
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return await this._Collection.Find(filter).ToListAsync();
                    return await this._Collection.Find(filter).Sort(sort).ToListAsync();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();
                if (sort == null) return await this._Collection.Find(filter).Project<T>(projection).ToListAsync();
                //排序查询
                return await this._Collection.Find(filter).Sort(sort).Project<T>(projection).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindListByPage 分页查询集合
        /// <summary>
        /// 分页查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="count">总条数</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public List<T> FindListByPage(FilterDefinition<T> filter, int pageIndex, int pageSize, out long count, string[] field = null, SortDefinition<T> sort = null)
        {
            try
            {
                count = this._Collection.CountDocuments(filter);
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return this._Collection.Find(filter).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
                    //进行排序
                    return this._Collection.Find(filter).Sort(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();

                //不排序
                if (sort == null) return this._Collection.Find(filter).Project<T>(projection).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();

                //排序查询
                return this._Collection.Find(filter).Sort(sort).Project<T>(projection).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindListByPageAsync 异步分页查询集合
        /// <summary>
        /// 异步分页查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public async Task<List<T>> FindListByPageAsync(FilterDefinition<T> filter, int pageIndex, int pageSize, string[] field = null, SortDefinition<T> sort = null)
        {
            try
            {
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return await this._Collection.Find(filter).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
                    //进行排序
                    return await this._Collection.Find(filter).Sort(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();

                //不排序
                if (sort == null) return await this._Collection.Find(filter).Project<T>(projection).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();

                //排序查询
                return await this._Collection.Find(filter).Sort(sort).Project<T>(projection).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public async Task<bool> AnyAsync(FilterDefinition<T> filter)
        {
            try
            {
                long count = await this._Collection.CountDocumentsAsync(filter);
                return count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Any(string collName, FilterDefinition<T> filter)
        {
            try
            {
                long count = this._Collection.CountDocuments(filter);
                return count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
