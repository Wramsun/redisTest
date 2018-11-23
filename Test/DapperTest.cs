using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DapperTest
    {
        //Dapper注释 ORM框架

        public void GetName()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionBankMobilePayment"].ConnectionString))
            {
                string sql = "SELECT [MachineID],[MachineName] FROM [Machines] ";
                List<MachinesModel>  list = con.Query<MachinesModel>(sql).ToList();
                list.Where(b => b.MachineID == 75);

                var model1 = con.Query<MachinesModel>("SELECT [MachineID],[MachineName] FROM [Machines] where MachineID in @ids", new
                {
                    ids = new int[] { 75, 76, 77 }
                });


            }
        }

        public class MachinesModel
        {
            public int MachineID { get; set; }

            public string MachineName { get; set; }
        }
    }
}
