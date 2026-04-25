using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private string myColor; // Inspector'dan "Blue" yaz
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D myCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();

        // Oyun baþlarken platformu gizli ve içinden geçilebilir yap
        SetState(false);
    }

    void Update()
    {
        // Manager'da benim rengim aktif oldu mu?
        if (myColor == "Red" && colormanage.Instance.isRedActive) SetState(true);
        if (myColor == "Blue" && colormanage.Instance.isBlueActive) SetState(true);
        if (myColor == "Yellow" && colormanage.Instance.isYellowActive) SetState(true);
    }

    void SetState(bool isActive)
    {
        if (isActive)
        {
            // Renkli hali: Tam görünür ve katý
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            myCollider.enabled = true;
        }
        else
        {
            // Hayalet hali: Yarý þeffaf ve içinden geçilebilir
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.2f);
            myCollider.enabled = false;
        }
    }
}
