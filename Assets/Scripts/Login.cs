using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public InputField user;
    public InputField passw;

    public void OnLogin()
    {
        Conection con = gameObject.AddComponent<Conection>();
        string nombre = user.text;
        string pass = passw.text;
        DataClass.usr = new User(nombre, pass);
        con.FunctionSN("Loginname");
    }
    public void OnRegister()
    {
        Application.OpenURL("http://unity3d.com/");
    }
}
