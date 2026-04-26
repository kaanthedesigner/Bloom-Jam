using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI    ;

public class HealthManager : MonoBehaviour
{
    public int health = 3;
    [SerializeField] private Image[] brushes; // F�r�a resimlerini buraya s�r�kleyece�iz
    [SerializeField] private float fallThreshold = -50f; // Mapten d��me s�n�r�
    private Vector2 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position; // Ba�lang�� yerini kaydet
                                         // Eğer Inspector'dan sürüklemeyi unuttuysak, sahnede "Brush" adındaki objeleri bulalım
        if (brushes == null || brushes.Length == 0)
        {
            // Önemli: Canvas'taki fırça objelerine "Brush" tag'i verirsen çok rahat buluruz.
            // Veya isimden bulalım:
            brushes = new Image[3];
            brushes[0] = GameObject.Find("Brush_1").GetComponent<Image>();
            brushes[1] = GameObject.Find("Brush_2").GetComponent<Image>();
            brushes[2] = GameObject.Find("Brush_3").GetComponent<Image>();
        }
    }

    void Update()
    {
        // Mapten d��me kontrol�
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
            // �ld���nde arkada��n�n yazd��� sistemi �a��ral�m
            // Arkada��n muhtemelen bir "LevelManager" veya "SceneManager" yap�yordur
            
            Debug.Log("�ld�m");
        }
    }

    void UpdateUI()
    {
         for (int i = 0; i < brushes.Length; i++)
        {
            // E�er can�m i'den b�y�kse f�r�a g�z�ks�n, de�ilse kapans�n
            if (i < health) brushes[i].enabled = true;
            else brushes[i].enabled = false;
        }
    }

    void Respawn()
    {
        transform.position = spawnPoint;
        // Unity 6+ kullan�yorsan h�z� s�f�rlamay� unutma
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}
