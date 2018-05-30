using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
   
    public static void Login(string a )
    {
        byte[] tmpBytesString = System.Text.Encoding.UTF8.GetBytes(a);
        a = System.Text.Encoding.UTF8.GetString(tmpBytesString, 3, tmpBytesString.Length - 3);
        if (a.Length < 10)
        {
            Debug.Log("Acces FAIL");
        }
        else
        {
            Debug.Log("Acces OK");
            Debug.Log("-->" + a);
            DataClass.usr = JsonUtility.FromJson<User>(a);
            Debug.Log(DataClass.usr.toJson());
            SceneManager.LoadScene("Load");
        }
    }

    public static void LoadF()
    {
        SceneManager.LoadScene("Game");
    }
}
