using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private string myColor;

    [Header("Görsel Ayarlar")]
    [SerializeField] private Sprite passiveSprite; // Siyah-beyaz olan resim
    [SerializeField] private Sprite activeSprite;  // Renkli olan resim

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D myCollider;
    private bool isAlreadyActive = false; // Gereksiz Update yükünü önlemek için

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();

        // Oyun baþlarken pasif durumda baþla
        SetState(false);
    }

    void Update()
    {
        // Eðer zaten aktifleþmiþse her karede kontrol etmesine gerek yok
        if (isAlreadyActive) return;

        // Manager'da benim rengim aktif oldu mu? (ColorManager ismini senin projene göre kontrol et)
        if (myColor == "Red" && colormanage.Instance.isRedActive) SetState(true);
        if (myColor == "Blue" && colormanage.Instance.isBlueActive) SetState(true);
        if (myColor == "Yellow" && colormanage.Instance.isYellowActive) SetState(true);
    }

    void SetState(bool isActive)
    {
        if (isActive)
        {
            spriteRenderer.sprite = activeSprite; // Renkli resmi tak
            myCollider.enabled = true;            // Fiziksel hale getir
            isAlreadyActive = true;               // Durumu kilitle
        }
        else
        {
            spriteRenderer.sprite = passiveSprite; // Siyah-beyaz resmi tak
            myCollider.enabled = false;             // Ýçinden geçilebilir yap
        }
    }
}
