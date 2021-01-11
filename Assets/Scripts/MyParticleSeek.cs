using UnityEngine;

public class MyParticleSeek : MonoBehaviour
{
    public Transform target;
    public float force = 10.0f;

    new ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void LateUpdate()
    {
        ParticleSystem.Particle[] particles =
            new ParticleSystem.Particle[particleSystem.particleCount];
        particleSystem.GetParticles(particles);
        float forceDeltaTime = force * Time.deltaTime;

        for (int i = 0; i < particles.Length; i++)
        {
            Vector3 particleWorldPosition = particles[i].position;
            Vector3 directionToTarget = Vector3.Normalize(target.position - particleWorldPosition);
            Vector3 seekForce = directionToTarget * forceDeltaTime;
            particles[i].velocity += seekForce;
        }
        particleSystem.SetParticles(particles, particles.Length);
    }
}
