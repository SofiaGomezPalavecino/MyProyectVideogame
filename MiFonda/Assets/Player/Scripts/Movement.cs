using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 1.5f;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference move; // Vector2 para movimiento
    [SerializeField] private InputActionReference mouse; // Vector2 para la visión de la cámara

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.15f;
    [SerializeField] private LayerMask groundMask;

    [Header("Cámara")]
    [SerializeField] private Transform cameraPlayer;
    [SerializeField] private float sensibility = 2f;

    private Rigidbody rb3D;
    private Vector3 moveDirection;
    private float rotationX;

    private void Awake()
    {
        rb3D = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputSystemSingleton.Instance.SetControlsEnable(true);
    }

    private void Update()
    {
        // Leer las entradas
        moveDirection = move.action.ReadValue<Vector3>();
        Vector2 cameraVision = mouse.action.ReadValue<Vector2>();

        // Calcular la rotación de la cámara
        rotationX -= cameraVision.y * sensibility;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        cameraPlayer.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Rotar el jugador basado en la entrada del mouse
        transform.Rotate(Vector3.up * cameraVision.x * sensibility);
    }

    private void FixedUpdate()
    {
        movement();
        Jump();
    }
    private void movement()
    {
        // Calcular dirección de movimiento en base a la cámara
        Vector3 forward = cameraPlayer.forward;
        Vector3 right = cameraPlayer.right;

        forward.y = 0; // Ignorar movimiento vertical
        right.y = 0; // Ignorar movimiento vertical

        Vector3 moveDir = (forward.normalized * moveDirection.y + right.normalized * moveDirection.x).normalized;

        // Aplicar movimiento
        rb3D.velocity = new Vector3(moveDir.x * speed, rb3D.velocity.y, moveDir.z * speed);
    }
    private void Jump()
    {
        if (moveDirection.z > 0 && IsGrounded())
        {
            float g = Mathf.Abs(Physics.gravity.y);
            float jumpSpeed = Mathf.Sqrt(2f * g * jumpHeight);

            rb3D.velocity = new Vector3(rb3D.velocity.x, jumpSpeed, rb3D.velocity.z);
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1.1f, groundMask);
    }
}