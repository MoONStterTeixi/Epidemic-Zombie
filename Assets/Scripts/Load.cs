using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

    public static string username;

    void Start () {
        try {
            Conection con = gameObject.AddComponent<Conection>();
            con.FunctionEZ(DataClass.usr, "get");
        }
        catch(Exception e)
        {
            SceneManager.LoadScene("Acces");
        }
    }
}
