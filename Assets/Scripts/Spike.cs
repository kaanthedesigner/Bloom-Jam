using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarptýðýmýz objenin üzerinde HealthManager var mý?
        HealthManager health = collision.gameObject.GetComponent<HealthManager>();

        if (health != null)
        {
            health.TakeDamage(1);
        }
    }
}
