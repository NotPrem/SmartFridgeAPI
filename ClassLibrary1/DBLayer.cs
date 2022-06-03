using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DBLayer
    {

        public void InsertValuesToDB(int pricekWh, int valid_from, int valid_to, DateTime DateTimeNow, int Year, int Month, int Day, int Hour)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SmartFridge"].ConnectionString;
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Vær values(@pricekWh,@, @LabelDateTimeNow, @LabelYear , @LabelMonth , @LabelDay , @LabelHour)", conn);
                cmd.CommandType = CommandType.Text;



                param = new SqlParameter("@pricekWh", SqlDbType.Int);
                param.Value = pricekWh;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LabelDateTimeNow", SqlDbType.DateTime);
                param.Value = DateTimeNow;
                cmd.Parameters.Add(param);
                param = new SqlParameter("@LabelYear", SqlDbType.Int);
                param.Value = Year;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LabelMonth", SqlDbType.Int);
                param.Value = Month;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LabelDay", SqlDbType.Int);
                param.Value = Day;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@LabelHour", SqlDbType.Int);
                param.Value = Hour;
                cmd.Parameters.Add(param);



                int rows = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
