using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(1, 0) * 5 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            Debug.Log("Bala destruida");
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);

        }
    }
}
