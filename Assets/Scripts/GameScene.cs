using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {
    public Text Nivel;
    public Text RondaAct;
    public Text Money;
    public Text OfflineWin;
    private static int kills = 0;
    private Conection con;
    public GameObject Alert;
    public Scrollbar Nivelp;


    private void Start()
    {
        con = gameObject.AddComponent<Conection>();
        StartCoroutine(Request());
        DataClass.player.money += DataClass.Offline;
        OfflineWin.text = "Has Ganado " + DataClass.Offline + " mientras has estado ausente.";
    }

    private void Update()
    {
        Nivel.text = (DataClass.player.experience/100) + "";
        float p = ((DataClass.player.experience % 100));
        Nivelp.size = p/100;
        RondaAct.text = DataClass.player.act_round + " Round";
        Money.text = DataClass.player.money + " €";
    }

    public void OnClickExit() => Alert.SetActive(false);

    IEnumerator Request()
    {
        while (true)
        {
            Debug.Log(DataClass.player.toJson());
            
            yield return new WaitForSeconds(2.5f);
            con.UpdateEZ(DataClass.player, "update");
        }
    }

}
