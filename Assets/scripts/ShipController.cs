using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] Transform visualTransform;

    [SerializeField] float boostStenght;
    [SerializeField] float speedCap;
    [SerializeField] float rotateSpeed;
    Vector3 momentumDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        visualTransform.Rotate(Vector3.back, InputManager.Instance.rotateValue * rotateSpeed * Time.deltaTime);

      if(InputManager.Instance.boostPressd)
      {
            momentumDir += visualTransform.up * boostStenght * Time.deltaTime;
            Vector2.ClampMagnitude(momentumDir, speedCap);

     
      }
      transform.Translate(momentumDir *  Time.deltaTime);
    }

}
