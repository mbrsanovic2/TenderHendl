using System.Collections;
using UnityEngine;

public class SpawnHendl : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;

    void Start()
    {
        StartCoroutine(ShootAtPlayerRoutine());
    }

    IEnumerator ShootAtPlayerRoutine()
    {
        while (true)
        {
            ShootAtPlayer();
            yield return new WaitForSeconds(3f);
        }
    }

    void ShootAtPlayer()
    {
        if (player == null || projectile == null) return;

        // Spawn projectile
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);

        // Calculate direction
        Vector3 direction = (player.transform.position - transform.position).normalized;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 10f;
        }
    }
}
