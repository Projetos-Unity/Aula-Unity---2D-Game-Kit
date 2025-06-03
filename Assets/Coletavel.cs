using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public int valor = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin(valor); // Avisa o GameManager
            Destroy(gameObject); // Destrói o coletável
        }
    }
}
