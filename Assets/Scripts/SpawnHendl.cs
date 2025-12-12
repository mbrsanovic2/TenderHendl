using System.Collections;
using UnityEngine;

public class SpawnHendl : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject hendl;
    [SerializeField] private Scoretafel scoreboard;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] AudioSource shootSound;
    private int noChicken = 0;

    void Start()
    {
        int difficulty = ChooseDifficultyScript.difficulty;
        StartCoroutine(ShootAtPlayerRoutine(difficulty));
    }

    IEnumerator ShootAtPlayerRoutine(int difficulty)
    {
        yield return new WaitForSeconds(5);
        if (difficulty == 0)
            difficulty = 1;
        while (true)
        {
            ShootAtPlayer(difficulty);
            yield return new WaitForSeconds(3 / (float)difficulty);
        }
    }

    void ShootAtPlayer(float velocity)
    {
        if (player == null || projectile == null) return;

        shootSound.Play();
        // Spawn projectile
        GameObject bullet;
        if (Random.Range(0, 100) < 25 || noChicken > 3)
        {
            bullet = Instantiate(hendl, spawnpoint.position, Quaternion.identity);
            noChicken = 0;
        }
        else
        {
            noChicken++;
            bullet = Instantiate(projectile, spawnpoint.position, Quaternion.identity);
        }
        scoreboard.IncreaseBalls();

        // Calculate direction
        Vector3 direction = (player.transform.position - transform.position).normalized;

        float spread = 0.03f * (velocity -1);
        float xOffset = Random.Range(-spread, spread);

        direction = new Vector3(direction.x + xOffset, direction.y, direction.z).normalized;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 9f * velocity + new Vector3(0, 6);
        }
    }
}
