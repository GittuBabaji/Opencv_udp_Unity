using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float Strength = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameManager gameManager;

    private int index;
    private Vector3 direction;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Jump();
        }
    }

    public void Jump()
    {
        direction.y = Strength;
    }

    private void AnimateSprite()
    {
        index = (index + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[index];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
        else if (other.CompareTag("Scoring"))
        {
            gameManager.IncreaseScore();
        }
    }
}
