using System.Collections;
using UnityEngine;

public class SpawnHendl : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject hendl;
    [SerializeField] private Scoretafel scoreboard;
    [SerializeField] private Transform spawnpoint;

    void Start()
    {
        int difficulty = ChooseDifficultyScript.difficulty;
        StartCoroutine(ShootAtPlayerRoutine(difficulty));
    }

    IEnumerator ShootAtPlayerRoutine(int difficulty)
    {
        if (difficulty == 0)
            difficulty = 1;
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
        GameObject bullet;
        if (Random.Range(0, 100) < 5)
        {
            bullet = Instantiate(hendl, spawnpoint.position, Quaternion.identity);
        }
        else
        {
            bullet = Instantiate(projectile, spawnpoint.position, Quaternion.identity);
        }
        scoreboard.IncreaseBalls();

        // Calculate direction
        Vector3 direction = (player.transform.position - transform.position).normalized;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 10f * velocity;
        }
    }
}
