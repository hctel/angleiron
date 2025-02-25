using MySql.Data.MySqlClient;
using System;

namespace backend
{
	public class UserAuth
	{
		private UserDB database;
        public UserAuth(UserDB database)
		{
			this.database = database;
        }

		public Session authUser(string email, string password, string remoteIP)
		{
			Console.WriteLine(String.Format("User auth challenge: {0}, password {1}", email, password));
            using(MySqlDataReader result = database.getUserFromEmail(email)){
            	if (result.Read())
				{
					Console.WriteLine($"password for {email}: {result.GetString("password")}");
					if (password.Equals(result.GetString("password")))
					{
						Console.WriteLine($"{remoteIP} logged in as {result.GetString("Name")}:{email}");
                    	return new Session(result.GetString("Name"), result.GetInt32("idClient"), remoteIP);
					} else throw new Exception("Invalid password");

            	} else throw new KeyNotFoundException("User not found");
			}

        }

		public void createUser(string name, string address, string email, string password)
        {
            if(database.getUserFromEmail(email).HasRows) throw new Exception("User already exists");
			else
			{
				database.addUser(name, address, email, password);
            }
        }
    }
}
