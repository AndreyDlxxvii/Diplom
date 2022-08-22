using UnityEngine.Networking;

public class MessLogin : MessageBase
{
    private string _login;

    public string Login
    {
        get => _login;
        set => _login = value;
    }

    public override void Deserialize(NetworkReader reader)
    {
        _login = reader.ReadString();
    }

    public override void Serialize(NetworkWriter writer)
    {
        writer.Write(_login);
    }
}
