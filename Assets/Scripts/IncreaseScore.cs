using UnityEngine;
using System.Collections.Generic;

public class IncreaseScore : MonoBehaviour
{
    [SerializeField] Scoretafel scoreBoard;

    List<GameObject> scoredBalls = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" && !scoredBalls.Contains(other.gameObject))
        {
            scoredBalls.Add(other.gameObject);
            scoreBoard.IncreaseScore();
        }
    }
}
