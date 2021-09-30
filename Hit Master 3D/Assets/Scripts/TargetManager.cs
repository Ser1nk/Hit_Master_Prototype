using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private const string Player = "Player";

    [SerializeField]private GameObject _button;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Player))
        {
            _button.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Player))
        {
            _button.SetActive(false);
        }
    }
}
