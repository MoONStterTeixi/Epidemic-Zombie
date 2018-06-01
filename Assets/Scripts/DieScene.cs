using UnityEngine;
using UnityEngine.SceneManagement;

public class DieScene : MonoBehaviour {

    public void OnClick()
    {
        SceneManager.LoadScene("Load");
    }
}
