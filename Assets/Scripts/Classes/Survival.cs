using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Survival : MonoBehaviour {

    private int vida { get; set; }
    private int state { get; set; }
    public Scrollbar VidaUI;
    Animator animator;


    public void Start()
    {
        animator = GetComponent<Animator>();
        vida = DataClass.player.vidaMax;
        StartCoroutine(EstateRequest());
    }

    public void Update()
    {
        VidaUI.size = vida / DataClass.player.vidaMax;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Zombie"))
        {
            state = 1;
        }
    }

    IEnumerator EstateRequest()
    {
        while (true)
        {
            switch (state)
            {
                case 0:

                    break;
                case 1:

                    break;
            }
        }
    }
}
