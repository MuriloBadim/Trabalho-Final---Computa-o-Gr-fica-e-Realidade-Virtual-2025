using UnityEngine;

public class Asteroid2D : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colidiu com asteroide!");
        }
    }
}
