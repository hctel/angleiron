using System;

public class UserAuth
{
	public string SessionId { get; }
	public int UserId { get; }
	public string RemoteIp { get; }
    public UserAuth(int userid, string remoteIp)
	{
		SessionId = Guid.NewGuid().ToString();
        UserId = userid;
        RemoteIp = remoteIp;
    }
}
