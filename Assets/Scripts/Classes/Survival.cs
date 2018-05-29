using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Survival : MonoBehaviour {

    private int vida { get; set; }
    public static int state { get; set; }
    private Collision2D actzombi;
    public Text VidaUI;
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
        VidaUI.text = vida + "/" + DataClass.player.getVida();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("shot"))
        {
            animator.SetInteger("status", 1);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("mele"))
        {
            animator.SetInteger("status", 1);
        }
        if(vida <= 0)
        {
            state = 3;
        }
    }
        
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Collision");
        actzombi = coll;
        if (coll.gameObject.tag.Equals("Zombie"))
        {
            state = 1;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        state = 0;
    }

    public void OnAtack()
    {
        switch (state)
        {
            case 0: //Pistola
                Rigidbody2D BalaClone = (Rigidbody2D)Instantiate(Bala, Bala.transform.position, Bala.transform.rotation);
                animator.SetInteger("status", 2);
                break;
            case 1: //Mele
                actzombi.gameObject.GetComponent<Zombie>().MakeMeleDMG();
                animator.SetInteger("status", 3);
                break;
        }
    }

    IEnumerator EstateRequest()
    {
        while (true)
        {
            switch (state)
            {
                case 3:
                    Debug.Log("Has muerto.");
                    break;
                case 1:
                    vida -= 10;
                    break;
            }
            yield return new WaitForSeconds(2.5f);
        }
    }
}