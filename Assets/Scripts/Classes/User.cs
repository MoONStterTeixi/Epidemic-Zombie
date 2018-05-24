using System.Security.Cryptography;
using System.Text;
using UnityEngine;

[System.Serializable]
public class User{

    public string email;
    public string password;
    public string username;
    public int genre;
    public bool sub;

    public User(string email, string password, string username, int genre, bool sub)
    {
        this.email = email;
        this.password = password;
        this.username = username;
        this.genre = genre;
        this.sub = sub;
    }

    public User (string email , string password)
    {
        this.email = email;
        this.password = GetEncoding(GetEncoding(password) + "." + GetEncoding(email));
    }

    public string toJson()
    {
        return JsonUtility.ToJson(this);
    }

    public static string GetEncoding(string value)
    {
        StringBuilder Sb = new StringBuilder();

        using (SHA256 hash = SHA256Managed.Create())
        {
            Encoding enc = Encoding.UTF8;
            byte[] result = hash.ComputeHash(enc.GetBytes(value));

            foreach (byte b in result)
                Sb.Append(b.ToString("x2"));
        }

        return Sb.ToString();
    }
}
