using UnityEngine;

public class colormanage : MonoBehaviour
{
    // Singleton yapýsý: Her yerden eriþmek için
    public static colormanage Instance;


    [Header("Dünya Durumu (Tablo boyandý mý?)")]
    public bool isRedActive, isBlueActive, isYellowActive;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // Topu topladýðýmýzda çaðýracaðýmýz fonksiyon
    public void CollectColor(string colorName)
    {
        if (colorName == "Red") isRedActive = true;
        if (colorName == "Blue") isBlueActive = true;
        if (colorName == "Yellow") isYellowActive = true;

        Debug.Log(colorName + " artýk dünyada aktif!");
    }
    
}
