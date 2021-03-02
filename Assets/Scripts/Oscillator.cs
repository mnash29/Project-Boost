using UnityEngine;

public class Oscillator : MonoBehaviour
{
    float movementFactor;
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 6f;

    void Start()
    {
        startingPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;

        float cycles = Time.time / period; // continually grows over time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // changes from 1 to -1

        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to cycle from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
