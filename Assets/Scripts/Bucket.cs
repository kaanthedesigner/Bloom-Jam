using UnityEngine;

public class Bucket : MonoBehaviour
{
    [Header("Efektler (Opsiyonel)")]
    [SerializeField] private GameObject destroyEffect; // Varsa bir patlama/su efekti

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarpan objenin Tag'i "Player" ise
        if (other.CompareTag("Player"))
        {
            CollectBucket();
        }
    }

    void CollectBucket()
    {
        // Buraya istersen puan artýrma veya ses çalma kodu ekleyebilirsin
        Debug.Log("Kova toplandý!");

        // Eðer bir efekt prefab'ýn varsa onu oluþtur
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }

        // Kovayý sahneden yok et
        Destroy(gameObject);
    }
}
