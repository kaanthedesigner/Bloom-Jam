using UnityEngine;

public class PotFlower : MonoBehaviour
{
    // Bu deðiþkeni Inspector'dan "Red", "Blue" veya "Yellow" olarak yazacaðýz
    [SerializeField] private string flowerColor;

    // Çiçeksiz saksý Prefab'ýný veya sahnedeki objesini buraya sürükle
    [SerializeField] private GameObject emptyPotPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarpan objenin tag'i "Player" ise
        if (other.CompareTag("Player"))
        {
            // 1. ColorManager'daki rengi aktif et
            if (colormanage.Instance != null)
            {
                colormanage.Instance.CollectColor(flowerColor);
            }

            // 2. Çiçeksiz saksýyý ayný noktada oluþtur (Spawn)
            if (emptyPotPrefab != null)
            {
                Instantiate(emptyPotPrefab, transform.position, transform.rotation);
            }

            // 3. Çiçekli saksýyý (kendini) sahneden sil
            Destroy(gameObject);
        }
    }
}
