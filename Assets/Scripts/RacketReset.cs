using UnityEngine;

public class RacketReset : MonoBehaviour
{
    Vector3 RESETPOS = new Vector3(0.5f, 2, -5);

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Racket")
        {
            other.gameObject.transform.position = RESETPOS;
            other.gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            other.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}
