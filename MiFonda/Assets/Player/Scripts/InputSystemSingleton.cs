using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemSingleton : MonoBehaviour
{
    private static InputSystemSingleton _instance;

    public static InputSystemSingleton Instance
    {
        get
        {
            _instance = FindAnyObjectByType<InputSystemSingleton>();

            if (_instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(InputSystemSingleton).Name);
                _instance = singletonObject.AddComponent<InputSystemSingleton>();
            }

            return _instance;
        }
    }

    public MyInputAction playerInputActions;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        playerInputActions = new MyInputAction();
    }

    private bool _controlsEnable = true;

    public void SetControlsEnable(bool enable)
    {
        _controlsEnable = enable;

        if (_controlsEnable)
        {
            OnEnable();
        }
        else
        {
            OnDisable();
        }
    }

    public void OnEnable()
    {
        if (_controlsEnable)
        {
            playerInputActions.Player.Move.Enable();
            playerInputActions.Player.Select.Enable();
            playerInputActions.Player.Mouse.Enable();
        }
    }
    public void OnDisable()
    {
        playerInputActions.Player.Move.Disable();
        playerInputActions.Player.Select.Disable();
        playerInputActions.Player.Mouse.Disable();
    }
}
