using UnityEngine;

public class Bala : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {


        transform.Translate(new Vector2(3, 0) * 2 * Time.deltaTime);
    }
}
