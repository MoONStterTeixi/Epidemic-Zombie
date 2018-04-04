using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.UI;

public class Load : MonoBehaviour {

    public static string id;
    public static string username;
    public Text text;

	// Use this for initialization
	void Start () {
        bool acces = GP();
        //Conexion.UpdateIdioma("English");

        if (acces)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            text.text = "Error!";
        }

    }

    public bool GP()
    {
        bool acces = false;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                acces =  true;
                username = Social.localUser.userName;
            }
            else
            {
                
            }
        });
        return acces;
    }
}
