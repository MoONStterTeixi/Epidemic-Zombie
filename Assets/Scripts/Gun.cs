using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject Bala;
    public static int Municion = 10;

    float accelerometerUpdateInterval = 1.0f / 60.0f;
    // The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
    float lowPassKernelWidthInSeconds = 1.0f;
    // This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! ;)
    float shakeDetectionThreshold = 1.0f;

    private float lowPassFilterFactor;
    private Vector3 lowPassValue = Vector3.zero;
    private Vector3 acceleration;
    private Vector3 deltaAcceleration;

    void Start()
    {
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    void Update()
    {

        acceleration = Input.acceleration;
        lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
        deltaAcceleration = acceleration - lowPassValue;
        if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
        {
            Recargar();
            //Debug.Log("Shake event detected at time " + Time.time);
        }

        switch (Input.GetTouch(0).phase)
        {
            case TouchPhase.Began:
                if(Municion >= 1)
                {
                Municion--;
                CrearBala();
                }
                else
                {
                    //Sin Municion
                }

                break;
        }

    }

    void CrearBala()
    {
            Instantiate(Bala);
    }

    private void Recargar()
    {
        Municion = 10;
    }
}