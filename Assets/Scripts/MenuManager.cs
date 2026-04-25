using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Slider volumeSlider;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Oyundan Çýkýldý");
        Application.Quit();
    }
    public GameObject mainMenuUI;
    public GameObject optionsUI;

    // Ayarlar butonuna basýnca çalýþacak
    public void OpenOptions()
    {
        mainMenuUI.SetActive(false); // Ana menüyü kapat
        optionsUI.SetActive(true);   // Ayarlarý aç
    }

    // Geri butonuna basýnca çalýþacak
    public void CloseOptions()
    {
        mainMenuUI.SetActive(true);  // Ana menüyü aç
        optionsUI.SetActive(false);  // Ayarlarý kapat
    }
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
        Debug.Log("Ses Seviyesi: " + value);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioListener.volume = volumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
