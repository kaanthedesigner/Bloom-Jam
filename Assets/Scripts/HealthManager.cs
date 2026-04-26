using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI    ;

public class HealthManager : MonoBehaviour
{
    public int health = 3;
    [SerializeField] private Image[] brushes; // Fýrça resimlerini buraya sürükleyeceðiz
    [SerializeField] private float fallThreshold = -10f; // Mapten düþme sýnýrý
    private Vector2 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position; // Baþlangýç yerini kaydet
    }

    void Update()
    {
        // Mapten düþme kontrolü
        if (transform.position.y < fallThreshold)
        {
            TakeDamage(1);
            Respawn();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateUI();

        if (health <= 0)
        {
            // Öldüðünde arkadaþýnýn yazdýðý sistemi çaðýralým
            // Arkadaþýn muhtemelen bir "LevelManager" veya "SceneManager" yapýyordur
            // SceneChanger.Instance.RestartLevel();
            Debug.Log("Öldüm");
        }
    }

    void UpdateUI()
    {
       /* for (int i = 0; i < brushes.Length; i++)
        {
            // Eðer caným i'den büyükse fýrça gözüksün, deðilse kapansýn
            if (i < health) brushes[i].enabled = true;
            else brushes[i].enabled = false;
        }*/
    }

    void Respawn()
    {
        transform.position = spawnPoint;
        // Unity 6+ kullanýyorsan hýzý sýfýrlamayý unutma
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}
