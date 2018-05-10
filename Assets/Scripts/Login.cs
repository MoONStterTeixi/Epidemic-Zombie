using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public InputField user;
    public InputField passw;

    public void OnLogin()
    {
        string nombre = user.text;
        string pass = passw.text;
        DataClass.usr = new User(nombre, pass);
        string a = Conection.FunctionSN(DataClass.usr, "Loginname");
        if (a == "" || a == null)
        {
            //Alert fallo credenciales.
        }
        else
        {
            Load.username = a;
            SceneManager.LoadScene("Load");
        }
    }
}
