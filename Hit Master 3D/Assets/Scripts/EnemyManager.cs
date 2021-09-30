using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private const string bullet = "bullet";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bullet))
        {
            Destroy(gameObject);
        }
    }
}
