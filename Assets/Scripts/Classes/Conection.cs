using System.Collections;
using UnityEngine;

public class Conection : MonoBehaviour {


    public void FunctionSN(string action)
    {
        string url = "https://moonstterinc.000webhostapp.com/SN/query.php?action=" + action + "&json=" + DataClass.usr.toJson();
        StartCoroutine(GetRequestSN(url));
    }

    public void FunctionEZ(User usr,  string action)
    {
        string url = "https://moonstterinc.000webhostapp.com/EZ/query.php?action=" + action + "&json=" + usr.toJson();
        StartCoroutine(GetRequestEZ(url));
    }

    public void FuncrtionEZU(Player ply, string action)
    {
        string url = "https://moonstterinc.000webhostapp.com/EZ/query.php?action=" + action + "&json=" + ply.toJson();
        Debug.Log(url);
        StartCoroutine(SetRequestEZ(url));
        
    }

    IEnumerator SetRequestEZ(string LoginUrl)
    {
        WWW www = new WWW(LoginUrl);
        yield return www;
        string returnvalue = www.text;
        Debug.Log(returnvalue);
    }

    IEnumerator GetRequestSN(string LoginUrl)
    {
        WWW www = new WWW(LoginUrl);
        yield return www;
        string returnvalue = www.text;
        ChangeScene.Login(returnvalue);
    }

    IEnumerator GetRequestEZ(string LoginUrl)
    {
        WWW www = new WWW(LoginUrl);
        yield return www;
        string returnvalue = www.text;
        ChangeScene.LoadF(returnvalue);
    }
}
