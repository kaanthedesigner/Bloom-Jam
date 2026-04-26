    using UnityEngine;
using UnityEngine.UI;
public class playercontroller : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 12f;

    [Header("Yer Kontrol Ayarları")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim; // Animasyon için beyin
    private float horizontal;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        // Sahne değişse de karakter silinmesin
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Animator bileşenini al
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        // Ölü bölge kontrolü
        if (Mathf.Abs(horizontal) < 0.1f) horizontal = 0;

        // Yer kontrolü
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Zıplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // --- ANİMASYON VE YÖN KONTROLÜ ---
        UpdateAnimation();
        FlipCharacter();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
    }

    void UpdateAnimation()
    {
        // Eğer horizontal 0 değilse yürüyor demektir
        bool isWalking = horizontal != 0;
        anim.SetBool("isRunning", isWalking);

        // Havada mı yerde mi kontrolünü de animatöre gönderebilirsin (opsiyonel)
        anim.SetBool("isGrounded", isGrounded);
    }

    void FlipCharacter()
    {
        // Karakterinin sahnede şu anki boyutunu baz alalım
        // Eğer Inspector'da karakterin scale'i 5 ise, bu değer 5 olur.
        float currentScaleX = Mathf.Abs(transform.localScale.x);

        if (horizontal > 0)
        {
            // Sağa bakarken pozitif scale
            transform.localScale = new Vector3(currentScaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            // Sola bakarken negatif (aynalanmış) scale
            transform.localScale = new Vector3(-currentScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}
