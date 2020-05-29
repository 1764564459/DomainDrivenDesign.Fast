using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DomainDrivenDesign.Web.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DomainDrivenDesign.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //MongoClient client = new MongoClient("mongodb://192.168.122.1/test");
            //var _base= client.GetDatabase("");
            //var filter = Builders<BsonDocument>.Filter;
            //BsonJavaScript javaScript = BsonJavaScript.Create("");
            ////filter = filter & filter.Where();
            //var _collect= _base.GetCollection<BsonDocument>("");
            ////https://www.cnblogs.com/qiuwuyu/archive/2011/08/05/2128116.html

            //var _map = BsonJavaScript.Create(@"
            //        function(){
            //                var _data=this.Data;//当前文档引用
            //                    for(var i=0;i<_data.length;i++)
            //                    {
            //                        emit(arr[i],
            //                    }
            //                  }
            //    ");

            //var _reduce = BsonJavaScript.Create("");
            ////执行存储过程
            //var _data= _collect.MapReduce<BsonDocument>(BsonJavaScript.Create(""), BsonJavaScript.Create(""));
            //var _base= server.GetDatabase("");
            //BsonJavaScript javaScript=
            //_base.Eval("");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 保存顾客方法:add & update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="birthDate"></param>
        public void saveCustomer(string id, string name, string email, string birthDate)
        {
            Customer customer = CustomerDao.GetCustomer(id);
            //if (customer == null)
            //{
            //    customer = new Customer();
            //    customer.Id = id;
            //}

            //if (name != null)
            //{
            //    customer.Name = name;
            //}
            //if (email != null)
            //{
            //    customer.Email = email;
            //}

            //...还有其他属性

            CustomerDao.SaveCustomer(customer);
        }
    }
}
