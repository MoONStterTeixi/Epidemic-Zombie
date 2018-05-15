using System.Collections;
using UnityEngine;

public class Conection : MonoBehaviour {


    public void FunctionSN(string action)
    {
        string url = "https://moonstterinc.000webhostapp.com/SN/query.php?action=" + action + "&json=" + DataClass.usr.toJson();
        StartCoroutine(GetRequest(url));
    }

    public void FunctionEZ(User usr,  string action){

        string url = "https://moonstterinc.000webhostapp.com/EZ/query.php?action=" + action + "&json=" + usr.toJson();
        StartCoroutine(GetRequest2(url));
    }

    IEnumerator GetRequest(string LoginUrl)
    {
        WWW www = new WWW(LoginUrl);
        yield return www;
        string returnvalue = www.text;
        ChangeScene.Login(returnvalue);
    }

    IEnumerator GetRequest2(string LoginUrl)
    {
        WWW www = new WWW(LoginUrl);
        yield return www;
        string returnvalue = www.text;
        ChangeScene.LoadF(returnvalue);
    }

}
