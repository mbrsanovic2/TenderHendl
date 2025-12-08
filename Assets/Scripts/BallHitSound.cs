using UnityEngine;

public class BallHitSound : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    [SerializeField] ParticleSystem particleSystem;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Racket")
        {
            hitSound.Play();
            if (particleSystem != null)
            {
                particleSystem.Play();
            }
        }
    }
}
