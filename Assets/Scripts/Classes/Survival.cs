﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Survival : MonoBehaviour {

    private int vida { get; set; }
    public static int state { get; set; }
    private Collision2D actzombi;
    public Text VidaUI;
    public Rigidbody2D Bala;
    Animator animator;
    public bool shoting = true;
    public int cargador = 10;
    public Text Municon;


    public void Start()
    {
        animator = GetComponent<Animator>();
        vida = DataClass.player.getVida();
        StartCoroutine(EstateRequest());
    }

    public void Update()
    {
        Municon.text = cargador + "/10";
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
            SceneManager.LoadScene("Die");
        }
        if(cargador == 0)
        {
            StartCoroutine(Recargar());
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
                if (shoting)
                {
                    Rigidbody2D BalaClone = (Rigidbody2D)Instantiate(Bala, Bala.transform.position, Bala.transform.rotation);
                    animator.SetInteger("status", 2);
                    cargador--;
                }
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
                    vida -= 100;
                    break;
            }
            yield return new WaitForSeconds(2.5f);
        }
    }
    IEnumerator Recargar()
    {
            shoting = false;
            Debug.Log("Recargando");
            yield return new WaitForSeconds(2.5f);
            cargador = 10;
            shoting = true;
    }
}