using System;

namespace backend
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

        public override string ToString()
        {
            return $"{SessionId}&{UserId}&{RemoteIp}";
        }
    }
}
