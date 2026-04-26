using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class SpawnPoint : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("SpawnPoint awake");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        Debug.Log("Player found: " + (player != null ? player.name : "NULL"));

        GameObject colorManager = GameObject.FindWithTag("ColorManager");
        Debug.Log("Color Manager found: " + (colorManager != null ? colorManager.name : "NULL"));

        if (player != null)
        {
            player.transform.position = transform.position;
        }
        if (colorManager != null)
        {
            colorManager.transform.position = Vector2.zero;
        }

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}