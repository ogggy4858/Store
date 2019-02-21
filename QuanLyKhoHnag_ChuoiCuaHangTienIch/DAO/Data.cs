using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyKhoHnag_ChuoiCuaHangTienIch.DAO
{
    public class Data
    {
        private static Data instance;
        private string connect = @"Data Source=DESKTOP-T9AO5GV\SQLEXPRESS;Initial Catalog=KhoHang_ChuoiCuaHangTienIch;Integrated Security=True";
        public static Data Instance
        {
            get
            {
                if (instance == null)
                    instance = new Data();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        public DataTable ExecuteQuery(string query, object[] ob = null)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if(ob != null)
                {
                    string[] list = query.Split(' ');
                    int i = 0;
                    foreach(var item in list)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, ob[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                connection.Close();
            }
            return table;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connect))
            {

                connection.Open();
                SqlCommand cm = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] list = query.Split(' ');
                    int i = 0;
                    foreach (string item in list)
                    {
                        if (item.Contains('@'))
                        {
                            cm.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cm.ExecuteNonQuery();
                connection.Close();
            }

            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connect))
            {

                connection.Open();
                SqlCommand cm = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] list = query.Split(' ');
                    int i = 0;
                    foreach (string item in list)
                    {
                        if (item.Contains('@'))
                        {
                            cm.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cm.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
