using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.OnDefeatUI();
            Destroy(other.gameObject);
        }
    }
}
