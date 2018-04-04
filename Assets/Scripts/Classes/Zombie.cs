using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public int vida = 100;

    private void Update()
    {
        transform.Translate(new Vector2(-1, 0) * 2 * Time.deltaTime);
        if(vida <= 0)
        {
            GameScene.Addkills();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bala")
        {
            vida -= Character.GetDaño();
        }
    }
}
