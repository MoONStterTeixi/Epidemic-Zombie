using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private float InstantiationTimer = 1f;
    public GameObject Zombie;

    void Update () {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            Instantiate(Zombie);
            InstantiationTimer = 3f;
        }
    }
}
