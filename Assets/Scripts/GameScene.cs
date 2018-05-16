using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {
    public Text Nivel;
    public Text RondaAct;
    public Text Money;
    private static int kills = 0;
    public SpriteRenderer spriteRenderer;
    private Conection con;
    private void Start()
    {
        con = gameObject.AddComponent<Conection>();
        StartCoroutine(Request());
    }

    private void Update()
    {
        Nivel.text = DataClass.player.experience+" XP";
        RondaAct.text = DataClass.player.act_round + " Round";
        Money.text = DataClass.player.money + " €";
    }
    public static void Addkills()
    {
        kills += 1;
    }

    IEnumerator Request()
    {
        while (true)
        {
            Debug.Log(DataClass.player.toJson());
            DataClass.player.money += 10;
            yield return new WaitForSeconds(2.5f);
            con.FuncrtionEZU(DataClass.player, "update");
        }
    }

}
