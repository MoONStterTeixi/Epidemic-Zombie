using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public Rigidbody2D Zombie1;

	void Start () {
        Zombie1.GetComponent<Zombie>().vida = 100;
        Zombie1.GetComponent<Zombie>().damage = 100;
        StartCoroutine(SpawnEvent());
    }

    IEnumerator SpawnEvent()
    {
        Rigidbody2D BalaClone = (Rigidbody2D)Instantiate(Zombie1, Zombie1.transform.position, Zombie1.transform.rotation);
        yield return new WaitForSeconds(3f);
    }
}
