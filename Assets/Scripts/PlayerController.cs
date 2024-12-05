using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 20f; // Fuerza del salto.
    public float speed = 5f;     // Velocidad de movimiento.

    public Sprite[] walkSprites; // Sprites para la animación de caminar.
    public Sprite jumpSprite;    // Sprite para el salto.
    private int spriteIndex = 0;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isMoving = false; // Controla si el jugador está avanzando.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkAnimation()); // Inicia la animación de caminar.
    }

    void Update()
    {
        // Movimiento horizontal solo si se presiona la flecha derecha.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            isMoving = true;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Detiene al jugador.
            isMoving = false;
        }

        // Saltar al presionar la barra espaciadora.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Cambiar a sprite de salto.
            StopCoroutine(WalkAnimation());
            spriteRenderer.sprite = jumpSprite;

            // Regresar a la animación de caminar después de un corto tiempo.
            StartCoroutine(ResetToWalkSprite());
        }
    }

    IEnumerator WalkAnimation()
    {
        while (true)
        {
            if (isMoving) // Solo animar si el jugador está avanzando.
            {
                spriteRenderer.sprite = walkSprites[spriteIndex];
                spriteIndex = (spriteIndex + 1) % walkSprites.Length; // Ciclar sprites.
            }
            yield return new WaitForSeconds(0.1f); // Cambiar sprite cada 0.1s.
        }
    }

    IEnumerator ResetToWalkSprite()
    {
        yield return new WaitForSeconds(0.2f); // Esperar un corto tiempo.
        if (isMoving)
        {
            StartCoroutine(WalkAnimation()); // Reanudar animación de caminar.
        }
    }
}
