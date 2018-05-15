using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
   
    public static void Login(string a )
    {
        Debug.Log(a);
        if (a == "" || a == null)
        {
            Debug.Log("Acces FAIL");
        }
        else
        {
            Debug.Log("Acces OK");
            Load.username = a;
            SceneManager.LoadScene("Load");
        }
    }

    public static void LoadF(string a)
    {
        DataClass.player = JsonUtility.FromJson<Player>(a);
        SceneManager.LoadScene("Game");
    }

}
