using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Particles_DestroyAfterLifetime : MonoBehaviour
{
    /// <summary>
    /// https://forum.unity.com/threads/solved-particle-instance-finished-playing-so-can-i-destroy-it.412234/
    /// </summary>
    ParticleSystem parts => GetComponent<ParticleSystem>();
    void Start()
    {
        float totalDuration = parts.main.duration + parts.main.startLifetimeMultiplier;
        Destroy(gameObject, totalDuration);
    }
}
