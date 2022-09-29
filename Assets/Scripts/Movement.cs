using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 5f;
    [SerializeField] float rotationThrust = 5f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem leftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;
    [SerializeField] ParticleSystem mainBoosterParticles;

    Rigidbody rb;
    AudioSource audioSource;
    void Start()
    {
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
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            StartRotatingLeft();

        }

        else if (Input.GetKey(KeyCode.D))
        {
            StartRotatingRight();

        }
        else
        {
            StopRotating();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainBoosterParticles.isPlaying)
        {
            mainBoosterParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainBoosterParticles.Stop();
    }

    void StartRotatingLeft()
    {
        ApplyRotation(rotationThrust);
        if (!rightBoosterParticles.isPlaying)
        {
            rightBoosterParticles.Play();
        }
    }

    void StartRotatingRight()
    {
        ApplyRotation(-rotationThrust);
        if (!leftBoosterParticles.isPlaying)
        {
            leftBoosterParticles.Play();
        }
    }

    void StopRotating()
    {
        rightBoosterParticles.Stop();
        leftBoosterParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
 