using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    

    private PlayerControls inputs;

    public bool shootPressd;
    public bool boostPressd;
    public float rotateValue;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerControls.player.move.performed
        inputs = new player();
        inputs.player.Boost.performed += i => boostPressd = true;
        inputs.player.Boost.canceled += i => boostPressd = false;
        inputs.player.Fire1.performed += i => shootPressd = true;
        inputs.player.Fire1.canceled += i => shootPressd = false;
        inputs.player.Rotate.performed += i => rotateValue = i.ReadValue<float>() ;
        inputs.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
