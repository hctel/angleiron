using System;

namespace ClientAppRemake

{
    public class Session
    {
        public string SessionId { get; }
        public int UserId { get; }
        public string RemoteIp { get; }
        public Session(string sessionid, int userid, string remoteIp)
        {
            SessionId = sessionid;
            UserId = userid;
            RemoteIp = remoteIp;
        }

        public Session(string sessionString)
        {
            SessionId = sessionString.Split('&')[0];
            UserId = int.Parse(sessionString.Split('&')[1]);
            RemoteIp = sessionString.Split('&')[2];
        }

        public override string ToString()
        {
            return $"{SessionId}&{UserId}&{RemoteIp}";
        }
    }
}
