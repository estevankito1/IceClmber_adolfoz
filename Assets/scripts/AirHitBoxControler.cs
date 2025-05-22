using UnityEngine;

public class AirHitBoxControler : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    Rigidbody2D rb;

    bool hasBroken = false;

    private void OnEnable() {
        hasBroken = false;
        if(rb == null) rb = GetComponentInParent<Rigidbody2D>();
    }





    private void FixedUpdate() {
        if(playerMovement.grounded) gameObject.SetActive(false);
        if(rb.linearVelocity.y < 0) gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("breakable") && !hasBroken)
        {
            hasBroken = true;
            collision.gameObject.SetActive(false);
            rb.linearVelocityY = 0;
        }
    }






}

