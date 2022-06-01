using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    class MySQLConnector
    {
        public MySqlConnection Connection { private set; get; }
        public MySQLConnector()
        {
            string connstruct = "Server=Localhost;Database=mysql;Uid=root;Pwd='root'";//переход на локальный сервер
            Connection = new MySqlConnection(connstruct);
        }
        
    }
}
