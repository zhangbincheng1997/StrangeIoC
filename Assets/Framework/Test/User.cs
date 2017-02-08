using UnityEngine;
using ProtoBuf;

public enum UserType
{
    Master,
    Warrior,
}

[ProtoContract]
public class User
{
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string Usrname { get; set; }

    [ProtoMember(3)]
    public string Password { get; set; }

    [ProtoMember(4)]
    public UserType Type { get; set; }
}
