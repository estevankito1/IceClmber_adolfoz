using UnityEngine;

public class AirHitBoxControler : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    private void FixedUpdate() {
        if(playerMovement.grounded) gameObject.SetActive(false);

    }






}

