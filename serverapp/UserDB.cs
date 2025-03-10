using System;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace backend
{
    public class UserDB : DatabaseConnector
    {
        public UserDB(string server, string databaseName, string username, string password) : base(server, databaseName, username, password)
        {
        }

        public MySqlDataReader getUserFromEmail(string email)
        {
            return read(String.Format("SELECT * FROM client WHERE Email='{0}';", email));
        }
        public MySqlDataReader getUserFromId(int id)
        {
            return read(String.Format("SELECT * FROM client WHERE id_client={0};", id));
        }

        public void addUser(string name, string address, string email, string password)
        {
            execute(String.Format("INSERT INTO client (Name, Address, Email, password) VALUES ('{0}', '{1}', '{2}', '{3}');", name, address, email, password));
        }
    }
}
