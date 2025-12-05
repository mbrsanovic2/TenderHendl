using UnityEngine;

public class capybaraWalk : MonoBehaviour
{
    public float speed = 2f;          // Bewegungsgeschwindigkeit
    public float moveDuration = 2f;   // Wie lange sich der NPC in eine Richtung bewegt

    private void Start()
    {
        StartCoroutine(MoveRoutine());
    }

    private System.Collections.IEnumerator MoveRoutine()
    {
        Vector3 direction = transform.forward;

        while (true)
        {
            // 1. Bewegen
            float timer = 0f;
            while (timer < moveDuration)
            {
                transform.position += direction * speed * Time.deltaTime;
                timer += Time.deltaTime;
                yield return null;
            }

            // 2. Umdrehen
            transform.Rotate(0, 180f, 0);

            // Richtung neu definieren
            direction = transform.forward;

            // kleine Pause optional
            // yield return new WaitForSeconds(0.2f);
        }
    }
}
