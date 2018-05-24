using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

    void Start () {
        try {
            Conection con = gameObject.AddComponent<Conection>();
            con.FunctionEZ(DataClass.usr, "get");

        }
        catch(Exception e)
        {
            Debug.Log(e);
            SceneManager.LoadScene("Acces");
        }
    }
}
