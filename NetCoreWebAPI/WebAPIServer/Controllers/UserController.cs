using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace WebAPIServer.Controllers
{
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly List<Users> users = new List<Users>() {
            new Users{ Id=1, UName="张三", UAge=12, UAddress="海淀区" },
            new Users{ Id=2, UName="李四", UAge=23, UAddress="昌平区" },
            new Users{ Id=3, UName="王五", UAge=34, UAddress="朝阳区" }
        };

        [HttpGet]
        public IQueryable<Users> Get()
        {
            return users.AsQueryable();
        }

        [HttpGet]
        [Route("GetName")]
        public string Get(string name)
        {
            return $"【GET 请求】姓名：{name}";
        }

        [HttpGet]
        [Route("GetNameAndAge")]
        public string Get(string name, string age)
        {
            return $"【GET 请求】姓名：{name}，年龄：{age}";
        }


        [HttpPost]
        public IQueryable<Users> Post()
        {
            return users.AsQueryable();
        }

        [HttpPost]
        [Route("PostName")]
        public string PostName([FromBody]string name)
        {
            return $"【POST 请求】姓名：{name}";
        }

        [HttpPost]
        [Route("PostPars")]
        public string PostPars([FromBody]Users user)
        {
            return $"【POST 请求】姓名：{user.UName}，年龄：{user.UAge}";
        }

        /// <summary>
        /// 传递多个不同对象的Post请求 
        /// </summary>
        /// <returns></returns>
        [Route("PostJObject")]
        public string PostJObject([FromBody]JObject jdata)
        {
            dynamic json = jdata;
            JObject jStu = json.student;
            JObject jAlbum = json.album;
            var stu = jStu.ToObject<Student>();
            var album = jAlbum.ToObject<Album>();
            return $"【POST 请求】学生的姓名：{stu.sName}，相册的尺寸：{album.ASize}";
        }

        /// <summary>
        /// 多参 Post Form 请求
        /// </summary>
        /// <returns></returns>
        [Route("PostForm")]
        public string PostForm([FromForm]string name, [FromForm]string age)
        {
            return $"【GET 请求】姓名：{name}，年龄：{age}";
        }

        // <summary>
        /// 传递多个不同对象的Post请求 
        /// </summary>
        /// <returns></returns>
        [Route("PostFormObject")]
        public string PostFormObject([FromForm]Users user)
        {
            return $"【POST 请求】姓名：{user.UName}，年龄：{user.UAge}";
        }

        [Route("PostFormJObject")]
        public string PostFormJObject()
        {
            Dictionary<String, String> keyValuePairs = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            Users u = FormToModelHelper<Users>.ConvertToModel(keyValuePairs);

            //dynamic json = jdata;
            //JObject jStu = json;
            //JObject jAlbum = json.album;
            //var student = jStu.ToObject<Student>();
            //var album = jAlbum.ToObject<Album>();
            //Student s = json;

            return $"【POST 请求】学生的姓名：{u.UName}";
        }
    }
    public class Album
    {
        public string AName { get; set; }
        public DateTime ADate { get; set; }
        public int ASize { get; set; }
        public bool ALock { get; set; }
    }
    public class Student
    {
        public string sName { get; set; }
        public int sAge { get; set; }
    }
    public class Users
    {
        public int Id { get; set; }
        public string UName { get; set; }
        public int UAge { get; set; }
        public string UAddress { get; set; }
    }

    public static class FormToModelHelper<T> where T : new()
    {
        public static T ConvertToModel(Dictionary<String, String> dic)
        {
            T t = new T();
            PropertyInfo[] propertys = t.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                if (!pi.CanWrite) continue;
                if (dic.ContainsKey(pi.Name))
                {
                    string value = dic[pi.Name];
                    if (!String.IsNullOrEmpty(value))
                    {
                        try
                        {
                            pi.SetValue(t, Convert.ChangeType(value, pi.PropertyType), null);//这一步很重要，用于类型转换
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            return t;
        }
    }
}
