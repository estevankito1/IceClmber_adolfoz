using System;
using UnityEngine;

public class AttackControler : MonoBehaviour
{
    InputController inputs;
    PlayerMovement playerMovement;
    [SerializeField] GameObject JumpAttackBox;
    [SerializeField] GameObject groundedAttackBox;


    void Awake(){
      inputs = GetComponent<InputController>();
      playerMovement = GetComponent<PlayerMovement>(); 
    }

    void Start() { 
        JumpAttackBox.SetActive(false);
        groundedAttackBox.SetActive(false);
    }


    void OnEnable(){
        inputs.OnAttackEvent += HandleOnAttack; 
    }

    private void OnDisable(){
       inputs.OnAttackEvent -= HandleOnAttack; 
    }

    private void HandleOnAttack(object sender, EventArgs e){
        if (playerMovement.grounded){
            groundedAttackBox.SetActive(true);
        }
        else
        {
            JumpAttackBox.SetActive(true);
        }
    }
}
