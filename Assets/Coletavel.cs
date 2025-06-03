using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public int valor = 1;
    public GameObject pickupEffect; // Efeito visual opcional

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(pickupEffect, transform.position, transform.rotation); // Efeito visual opcional
            GameManager.Instance.AddCoin(valor); // Avisa o GameManager
            Destroy(gameObject); // Destrói o coletável
        }
    }
}
