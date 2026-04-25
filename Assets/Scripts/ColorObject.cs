using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private string myColor;

    [Header("Görsel Ayarlar")]
    [SerializeField] private Sprite passiveSprite; // Siyah-beyaz olan resim
    [SerializeField] private Sprite activeSprite;  // Renkli olan resim

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D myCollider; // Collider'ý kontrol etmek için
    private bool isAlreadyActive = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();

        // OYUN BAÞLADIÐINDA:
        // Collider'ý tamamen kapatýyoruz (içinden geçilir)
        if (myCollider != null) myCollider.enabled = false;

        // Pasif resmi gösteriyoruz
        spriteRenderer.sprite = passiveSprite;
    }

    void Update()
    {
        if (isAlreadyActive) return;

        // ColorManager'dan gelen habere göre kontrol
        if (myColor == "Red" && colormanage.Instance.isRedActive) SetActive();
        else if (myColor == "Blue" && colormanage.Instance.isBlueActive) SetActive();
        else if (myColor == "Yellow" && colormanage.Instance.isYellowActive) SetActive();
    }

    void SetActive()
    {
        // ARTIK AKTÝF:
        spriteRenderer.sprite = activeSprite; // Renkli resmi tak

        if (myCollider != null)
            myCollider.enabled = true; // Collider'ý AÇ (artýk üstüne basýlabilir)

        isAlreadyActive = true;
        Debug.Log(gameObject.name + " platformu artýk aktif ve katý!");
    }
}
