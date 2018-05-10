using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

    public static string username;

    void Start () {
        try {
            string a = Conection.FunctionEZ(DataClass.usr, "get");
            DataClass.player = JsonUtility.FromJson<Player>(a);
            SceneManager.LoadScene("Game");
        }
        catch(Exception e)
        {
            SceneManager.LoadScene("Acces");
        }

    }

}
