using UnityEngine;

public class User : MonoBehaviour {
    public string username;
    public string password;

    public User (string nombre , string pass)
    {
        username = nombre;
        password = pass;
    }

    public string toJson()
    {
        return JsonUtility.ToJson(this);
    }
}
