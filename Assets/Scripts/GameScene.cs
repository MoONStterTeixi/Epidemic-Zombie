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

    private void Update()
    {
        Nivel.text = DataClass.player.experience+"";
        RondaAct.text = DataClass.player.act_round + "";
        Money.text = DataClass.player.money + "";
    }
    public static void Addkills()
    {
        kills += 1;
    }

}
