using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI    ;

public class HealthManager : MonoBehaviour
{
    public int health = 3;
    [SerializeField] private Image[] brushes; // F�r�a resimlerini buraya s�r�kleyece�iz
    [SerializeField] private float fallThreshold = -10f; // Mapten d��me s�n�r�
    private Vector2 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position; // Ba�lang�� yerini kaydet
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
        //UpdateUI();

        if (health <= 0)
        {
            // �ld���nde arkada��n�n yazd��� sistemi �a��ral�m
            // Arkada��n muhtemelen bir "LevelManager" veya "SceneManager" yap�yordur
            // SceneChanger.Instance.RestartLevel();
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
