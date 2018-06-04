using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public InputField user;
    public InputField passw;
    public GameObject LoginCanvas;
    public GameObject LoadingCanvas;
    public GameObject Err;
    public Toggle cb;

    public void Start()
    {
        user.text = PlayerPrefs.GetString("Mail");
        passw.text = PlayerPrefs.GetString("Pass");
    }

    public void OnLogin()
    {
        Conection con = gameObject.AddComponent<Conection>();
        string nombre = user.text;
        string pass = passw.text;
        if (IsValidEmail(nombre))
        {
            LoginCanvas.SetActive(false);
            LoadingCanvas.SetActive(true);
            DataClass.usr = new User(nombre, pass);
            if (cb.isOn)
            {
                PlayerPrefs.SetString("Mail", user.text);
                PlayerPrefs.SetString("Pass", passw.text);
            }
            con.FunctionSN("login");

        }
        else
        {
            Err.SetActive(true);
        }

    }

    public void onClick()
    {
        Err.SetActive(false);
    }
    public void OnRegister()
    {
        Application.OpenURL("http://MoONStterINC.com");
    }

    public static bool IsValidEmail(string strIn)
    {
        // Return true if strIn is in valid e-mail format.
        return Regex.IsMatch(strIn,
               @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
    }

    public void Savedata(bool status)
    {
    }

}
