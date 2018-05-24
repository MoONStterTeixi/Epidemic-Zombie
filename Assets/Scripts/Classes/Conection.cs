using System;
using System.Collections;
using UnityEngine;

public class Conection : MonoBehaviour {


    public void FunctionSN(string action)
    {
        string url = "http://www.moonstterinc.com/SN/query.php?action=" + action + "&json=" + DataClass.usr.toJson();
        StartCoroutine(GetRequestSN(url));
    }

    public void FunctionEZ(User usr,  string action)
    {
        string url = "https://moonstterinc.000webhostapp.com/EZ/query.php?action=" + action + "&json=" + usr.toJson();
        StartCoroutine(GetRequestEZ(url));
    }

    public void UpdateEZ(Player ply, string action)
    {
        string url = "https://moonstterinc.000webhostapp.com/EZ/query.php?action=" + action + "&json=" + ply.toJson();
        StartCoroutine(UpdateEZ(url));
        
    }

    IEnumerator UpdateEZ(string LoginUrl)
    {
        WWW www = new WWW(LoginUrl);
        yield return www;
        string returnvalue = www.text;
    }

    IEnumerator GetRequestSN(string LoginUrl)
    {
        WWW www = new WWW(LoginUrl);
        yield return www;
        string returnvalue = www.text;
        Debug.Log(www.text);
        ChangeScene.Login(returnvalue);
    }

    IEnumerator GetRequestEZ(string LoginUrl)
    {
        WWW www = new WWW(LoginUrl);
        yield return www;
        Debug.Log(www.text);
        DataClass.player = JsonUtility.FromJson<Player>(www.text);
        Debug.Log(DataClass.player.toJson());
        WWW www2 = new WWW("https://moonstterinc.000webhostapp.com/EZ/query.php?action=getofflinemoney&json=" + DataClass.player.toJson());
        yield return www2;
        DataClass.Offline = Convert.ToInt32(www2.text);
        ChangeScene.LoadF();
    }
}
