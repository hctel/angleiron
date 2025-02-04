using MySql.Data.MySqlClient;
using System;

namespace backend
{
	public class UserAuth
	{
		private DatabaseConnector database;
        public UserAuth(DatabaseConnector database)
		{
			this.database = database;
        }

		public Session authUser(string email, string password)
		{
			Console.WriteLine(String.Format("User auth challenge: {0}, password {1}", email, password));
            MySqlDataReader result = database.read(String.Format("SELECT * FROM Cliens WHERE Email='{0}';", email));
			if(result.Read())
			{
				if (password.Equals(result.GetString("password")))
				{
					return new Session(result.GetInt32("idClient"), "0.0.0.0"); //TODO: Get real IP
				} else throw new Exception("Invalid password");

            } else throw new KeyNotFoundException("User not found");

        }

		public void createUser(string name, string address, string email, string password)
        {
            if(database.read(String.Format("SELECT * FROM Cliens WHERE Email='{0}';", email)).HasRows) throw new Exception("User already exists");
			else
			{
				database.execute(String.Format("INSERT INTO Clients (Nom, Adresse, Email, password) VALUES ('{0}', '{1}', '{2}', '{3}');", name, address, email, password));
            }
        }
    }
}
