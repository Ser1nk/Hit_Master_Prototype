using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private const string Player = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Player))
        {
            _panel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
