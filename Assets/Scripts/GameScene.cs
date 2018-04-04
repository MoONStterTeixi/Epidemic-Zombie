using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {
    public Text Cant;
    public Text Cargador;
    private static int kills = 0;
    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        Cant.text = "Zombies Matados: " + kills;
        Cargador.text = Gun.Municion + "";
    }
    public static void Addkills()
    {
        kills += 1;
    }

}
