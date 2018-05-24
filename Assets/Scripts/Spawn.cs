using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public Rigidbody2D Zombie1;
    public static int CantZombie = 0;

	void Start () {
        Zombie1.GetComponent<Zombie>().vida = 100;
        Zombie1.GetComponent<Zombie>().damage = 100;
        StartCoroutine(SpawnEvent());
    }

    IEnumerator SpawnEvent()
    {
        while (CantZombie <= 2)
        {
                Rigidbody2D BalaClone = (Rigidbody2D)Instantiate(Zombie1, Zombie1.transform.position, Zombie1.transform.rotation);
                CantZombie++;
                yield return new WaitForSeconds(5f);
        }
    }
}
