using UnityEngine;

public class BallHitSound : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Racket")
        {
            hitSound.Play();
        }
    }
}
