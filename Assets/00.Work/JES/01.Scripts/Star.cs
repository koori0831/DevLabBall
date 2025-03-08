using System;
using UnityEngine;
    
public class Star : MonoBehaviour
{
    [SerializeField] private GameManager gameManager; // 이걸 이제 싱글톤을 사용하면 이렇게 안해도 된다.
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.OnClearUI();
            Destroy(gameObject);
        }
    }
}
