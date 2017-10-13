using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{

    [SerializeField] GameObject parti;
    ParticleSystem pSystem;
    // Use this for initialization
    void Start()
    {
        ParticleSystem ps = parti.GetComponent<ParticleSystem>();
        Destroy(this.gameObject, ps.duration);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
