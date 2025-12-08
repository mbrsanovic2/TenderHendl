using UnityEngine;

public class DeleteBalls : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.position = new Vector3(0, 0, -2);
        }
        else
            Destroy(other.gameObject);
    }
}
