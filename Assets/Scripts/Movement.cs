using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PlayAudioSource();
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else
        {
            StopAudioSource();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float direction)
    {
        rb.freezeRotation = true; // Freezing rotation to fix physics bug
        transform.Rotate(Vector3.forward * direction * Time.deltaTime);
        rb.freezeRotation = false;
    }

    void PlayAudioSource()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void StopAudioSource()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
