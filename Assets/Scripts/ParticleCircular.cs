using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCircular : MonoBehaviour
{

    new ParticleSystem particleSystem;
    public float force = 100.0f;
    public float speed = 5.0f;
    public string direction = "L";

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.Particle[] particles =
            new ParticleSystem.Particle[particleSystem.particleCount];
        particleSystem.GetParticles(particles);

        for (int i = 0; i < particles.Length; i++)
        {
            Vector3 particleWorldPosition = particles[i].position;
            Vector3 directionToTarget = Vector3.Normalize(transform.position - particleWorldPosition);
            Vector3 left = Vector3.Cross(directionToTarget, Vector3.up).normalized;
            if (direction == "R")
            {
                left = -left;
            }
            Vector3 seekForce = left * force * Time.deltaTime;
            particles[i].velocity += seekForce;

        }
        particleSystem.SetParticles(particles, particles.Length);
    }
}
