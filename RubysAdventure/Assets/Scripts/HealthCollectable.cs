using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    public ParticleSystem pickupParticle;
    public AudioClip collectedClip;
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                pickupParticle = Instantiate(pickupParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                controller.PlaySound(collectedClip);
            }
        }
    }
}
