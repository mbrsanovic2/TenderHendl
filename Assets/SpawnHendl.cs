using System.Collections;
using UnityEngine;

public class SpawnHendl : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;

    void Start()
    {

        int difficulty = ChooseDifficultyScript.difficulty;
        StartCoroutine(ShootAtPlayerRoutine(difficulty));
    }

    IEnumerator ShootAtPlayerRoutine(int difficulty)
    {
        while (true)
        {
            ShootAtPlayer(difficulty);
            yield return new WaitForSeconds(3/(float)difficulty);
        }
    }

    void ShootAtPlayer(float velocity)
    {
        if (player == null || projectile == null) return;

        // Spawn projectile
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);

        // Calculate direction
        Vector3 direction = (player.transform.position - transform.position).normalized;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 10f*velocity;
        }
    }
}
