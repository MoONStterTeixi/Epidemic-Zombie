using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public int vida { get; set; }
    public int damage { get; set; }
    public int state { get; set; }
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
            animator.SetInteger("Status", 2);
            Destroy(this.gameObject, animator.GetCurrentAnimatorStateInfo(0).length + 0.5f);
            DataClass.player.experience += 30;
            DataClass.player.experience += 10;
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
        switch (coll.gameObject.tag)
        {
            case "Player":
                state = 1;
                break;
            case "Bala":
                Destroy(coll.gameObject);
                vida -= DataClass.player.DmgRange;
                break;
            case "Bala2":

                break;
        }
    }
}
