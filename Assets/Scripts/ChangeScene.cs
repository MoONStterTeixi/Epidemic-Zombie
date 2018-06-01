using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
   
    public static void Login(string a )
    {
        if (a.Length < 10)
        {
            Debug.Log("Acces FAIL");
            SceneManager.LoadScene("Acces");
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
