using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Wall" || other.gameObject.tag == "Wall2")
        {
            Destroy(other.gameObject);
        }
    }
}
