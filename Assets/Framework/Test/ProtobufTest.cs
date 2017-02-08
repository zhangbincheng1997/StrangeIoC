using UnityEngine;
using ProtoBuf;
using System.IO;

public class ProtobufTest : MonoBehaviour
{
    private static string savePath = "Assets/Framework/Resources/UserInfo.txt";

    void Start()
    {
        // 序列化
        User user1 = new User();
        user1.Id = 10086;
        user1.Usrname = "RedHat";
        user1.Password = "123456";
        user1.Type = UserType.Master;

        using (FileStream fs = File.Create(savePath))
        {
            Serializer.Serialize<User>(fs, user1);
        }

        // 反序列化
        User user2 = new User();
        using (FileStream fs = File.OpenRead(savePath))
        {
            user2 = Serializer.Deserialize<User>(fs);
        }

        Debug.Log("Id : " + user2.Id + " Username : " + user2.Usrname + " Password : " + user2.Password + "　Type : " + user2.Type);
    }
}
