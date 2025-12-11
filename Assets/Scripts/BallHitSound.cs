using UnityEngine;

public class BallHitSound : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    [SerializeField] ParticleSystem currentParticleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Racket")
        {
            hitSound.Play();
            if (currentParticleSystem != null)
            {
                currentParticleSystem.Play();
            }
        }
    }
}
