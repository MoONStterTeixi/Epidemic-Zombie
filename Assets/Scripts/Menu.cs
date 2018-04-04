using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Text bt_play;
    public Text bt_collection;
    public Text bt_shop;
    public GameObject panel_Leng;
    public Text testFile;
    public Text id;


    // Use this for initialization
    void Start () {
        updateStrings();
    }

    private void updateStrings()
    {
        id.text = Load.username;
    }
	
    public void LenguagesPanel()
    {
        panel_Leng.active = true;
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Collection()
    {
        SceneManager.LoadScene("Collection");
    }

}
