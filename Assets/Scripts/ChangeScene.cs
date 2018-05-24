using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
   
    public static void Login(string a )
    {
        Debug.Log("-->" + a);
        if (a == "0" || a == null || a == "1")
        {
            Debug.Log("Acces FAIL");
        }
        else
        {
            Debug.Log("Acces OK");
            DataClass.usr = JsonUtility.FromJson<User>(a); ;
            SceneManager.LoadScene("Load");
        }
    }

    public static void LoadF()
    {
        SceneManager.LoadScene("Game");
    }
}
