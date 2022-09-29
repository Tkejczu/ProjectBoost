using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPos = transform.position;
        Debug.Log(startingPos);
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // continually growing over time

        const float tau = Mathf.PI * 2; // constant value of 6.283~~
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f;  // recalculated to go from 0 to 1 so it's cleaner

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
