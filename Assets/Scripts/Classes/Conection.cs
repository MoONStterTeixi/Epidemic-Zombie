using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Conection : MonoBehaviour {

    public static string FunctionSN(User usuario, string action)
    {
        string url = "http://172.17.129.63/Epidemic-Zombie-WebService/API-Rest/sn/query.php?action=" + action + "&json=" + usuario.toJson();
        WebRequest request = HttpWebRequest.Create(url);
        WebResponse response = request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        return reader.ReadToEnd();
    }

    public static string FunctionEZ(User usr,  string action){

        string url = "http://172.17.129.63/Epidemic-Zombie-WebService/API-Rest/ez/query.php?action=" + action + "&json=" + usr.toJson();
        WebRequest request = HttpWebRequest.Create(url);
        WebResponse response = request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        return reader.ReadToEnd();
    }
}
