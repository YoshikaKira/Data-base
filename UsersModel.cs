using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp4
{
    class UsersModel
    {
        MySQLConnector _connector;
        public UsersModel()
        {
            _connector = new MySQLConnector();
        }

        public User GetUser(string login, string pass)
        {
            User user = null;
            string query = $"SELECT * FROM users WHERE login ='{login}' and pass='{pass}'";//местный запрос на сервер
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, _connector.Connection);//коннектимся к серверу через адаптер
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);//из адаптера создаем таблицу
            if (table.Rows.Count == 0)
                return null;
            else
            {
                user = new User()
                {
                    id = Convert.ToInt32(table.Rows[0].ItemArray[0].ToString()),//из таблицы берем первую строку и первый айтем, все переводим в стринг, а затем в инт
                    Login = table.Rows[0].ItemArray[1].ToString(),
                    Pass = table.Rows[0].ItemArray[2].ToString(),   
                    Name = table.Rows[0].ItemArray[3].ToString(),
                    Date = table.Rows[0].ItemArray[4].ToString()
                };
                return user;
            }        
        }
        public void InsertUser(User user)
        {
            string query = " INSERT INTO users (login,pass,name,date) " + $"VALUES ('{user.Login}','{user.Pass}','{user.Name}','{user.Date}'";
            _connector.Connection.Open();
            MySqlCommand command = new MySqlCommand(query, _connector.Connection);
            _connector.Connection.Close();
            command.ExecuteNonQuery();
        }
    }
}
