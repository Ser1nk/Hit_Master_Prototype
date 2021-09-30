using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float startTime;
    private float endTime = 1.5f;

    private void Update()
    {
        startTime += Time.deltaTime;

        if (startTime >= endTime)
        {
            Destroy(gameObject);
        }
    }
}
