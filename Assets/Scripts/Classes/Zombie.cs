using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    private int vida { get; set; }
    private int damage { get; set; }
    private int state { get; set; }
    Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        vida = 100;
    }

    public void Update()
    {
        if (vida <= 0)
        {
            this.animator.SetInteger("Status", 2);
        }
        else if(state == 1)
        {
            this.animator.SetInteger("Status", 1);
        }
        else
        {
            transform.Translate(new Vector2(-1, 0) * 2 * Time.deltaTime);

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            state = 1;
        }
        if (coll.gameObject.tag.Equals("Bala1"))
        {
            //gun
        }
        if (coll.gameObject.tag.Equals("Bala2"))
        {
            //torreta
        }
    }
}
