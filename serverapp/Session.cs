using System;

namespace backend
{
    public class Session
    {
        public string SessionId { get; }
        public int UserId { get; }
        public string RemoteIp { get; }
        public Session(int userid, string remoteIp)
        {
            SessionId = Guid.NewGuid().ToString();
            UserId = userid;
            RemoteIp = remoteIp;
        }

        public override string ToString()
        {
            return $"{SessionId}&{UserId}&{RemoteIp}";
        }
    }
}
