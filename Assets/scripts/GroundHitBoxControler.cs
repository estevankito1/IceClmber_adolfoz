using UnityEngine;

public class GroundHitBoxControler : MonoBehaviour
{
    [SerializeField] AttackControler attackControler;
    [SerializeField] float AttackDuration;
    float attackStartTime;

    private void OnEnable()
    {
        attackControler.isAttacking = true; 
        attackStartTime = Time.time;
    }

    private void OnDisable()
    {
        attackControler.isAttacking = false;
    }

    private void FixedUpdate()
    {
        if (Time.time - AttackDuration >= attackStartTime) gameObject.SetActive(false);
    }








}
