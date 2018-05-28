using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Survival : MonoBehaviour {

    private int vida { get; set; }
    private int state { get; set; }
    public Scrollbar VidaUI;
    public Rigidbody2D Bala;
    Animator animator;


    public void Start()
    {
        animator = GetComponent<Animator>();
        vida = DataClass.player.getVida();
        StartCoroutine(EstateRequest());
    }

    public void Update()
    {
        float a = (float) vida / DataClass.player.VidaMax;
        VidaUI.size = a;
    }
        
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Collision");
        if (coll.gameObject.tag.Equals("Zombie"))
        {
            state = 1;
        }
    }

    public void OnAtack()
    {
        switch (state)
        {
            case 0: //Pistola
                Rigidbody2D BalaClone = (Rigidbody2D)Instantiate(Bala, Bala.transform.position, Bala.transform.rotation);
                break;
            case 1: //Mele

                break;
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
                    vida -= 10;
                    break;
            }
            yield return new WaitForSeconds(2.5f);
        }
    }
}
