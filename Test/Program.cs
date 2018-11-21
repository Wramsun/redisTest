using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //获取Redis操作接口
                IRedisClient Redis = RedisManager.GetClient();
                ////放入内存
                //Redis.Set<string>("LoginName", "962464");
                //Redis.Set<string>("PassWord", "123456");
                ////保存到硬盘
                //Redis.Save();
                ////释放内存
                //Redis.Dispose();

                List<string> testList = new List<string>();
                testList.Add("test1");
                testList.Add("test2");
                testList.Add("test3");
                testList.Add("test4");

                Redis.Set("testKey",testList);
                Redis.Remove("myKey");
                Console.WriteLine(Redis.Get<string>("test"));
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadKey();
            }
        }
    }
}
