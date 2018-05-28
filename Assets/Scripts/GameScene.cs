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

    public Text LifeLvl;
    public Text MeleLvl;
    public Text RangeLvl;
    public Text TurretLvl;

    public Button Life;
    public Button Mele;
    public Button Range;
    public Button Turret;


    private void Start()
    {
        con = gameObject.AddComponent<Conection>();
        StartCoroutine(Request());
        DataClass.player.money += DataClass.Offline;
        OfflineWin.text = "Has Ganado " + DataClass.Offline + " mientras has estado ausente.";
        UpdateLVls();
    }

    public void UpdateLVls()
    {
        LifeLvl.text = DataClass.player.VidaMax + "";
        MeleLvl.text = DataClass.player.DmgMele + "";
        RangeLvl.text = DataClass.player.DmgRange + "";
        TurretLvl.text = DataClass.player.Torreta + "";
        if (DataClass.KillZ >= 30)
        {
            DataClass.KillZ -= 30;
            DataClass.player.act_round++;
        }
    }

    private void Update()
    {
        Nivel.text = (DataClass.player.experience/100) + "";
        float p = ((DataClass.player.experience % 100));
        Nivelp.size = p/100;
        RondaAct.text = DataClass.player.act_round + " Round";
        Money.text = DataClass.player.money + " €";
    }
    
    public void OnClickUp(int i)
    {
        switch (i)
        {
            case 0://Life
                DataClass.player.VidaMax++;
                break;
            case 1://Mele
                DataClass.player.DmgMele++;
                break;
            case 2: //Range
                DataClass.player.DmgRange++;
                break;
            case 3: //Turret
                DataClass.player.Torreta++;
                break;
        }
        DataClass.player.money -= 200;
        UpdateLVls();
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
