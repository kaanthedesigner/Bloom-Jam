using UnityEngine;

public class ColorBall : MonoBehaviour
{
    // Bu deðiþkeni Inspector'dan "Red", "Blue" veya "Yellow" olarak yazacaðýz
    [SerializeField] private string ballColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarpan objenin tag'i "Player" ise
        if (other.CompareTag("Player"))
        {
            // Manager'daki ilgili bool'u true yapýyoruz
            colormanage.Instance.CollectColor(ballColor);

            // Topu sahneden siliyoruz
            Destroy(gameObject);
        }
    }
}
