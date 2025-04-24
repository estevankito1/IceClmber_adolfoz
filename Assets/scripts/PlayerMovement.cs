using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector2 movement;

    private Vector2 screenBounds;
    private float playerHalfWidth;
    private float xPosLastFrame;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        playerHalfWidth = spriteRenderer.bounds.extents.x;
        print(playerHalfWidth);
    }


    // Update is called once per frame
    void Update()
    {
        HandleMovment();
        ClampMovement();
        FlipCharacterX();
    }
    private void FlipCharacterX()
    {
        float input = Input.GetAxis("Horizontal");
        if (input > 0 && (transform.position.x > xPosLastFrame)) {
            spriteRenderer.flipX = false;
        }
        else if (input > 0 && (transform.position.x < xPosLastFrame)){
            spriteRenderer.flipX = true;
        }

        xPosLastFrame = transform.position.x;
    }
    private void ClampMovement()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + playerHalfWidth, screenBounds.x - playerHalfWidth);
        Vector2 pos = transform.position;
        pos.x = clampedX;
        transform.position = pos;
    }

    private void HandleMovment()
    {
        float input = Input.GetAxis("Horizontal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
