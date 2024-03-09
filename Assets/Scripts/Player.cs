using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraPivot;
    private CharacterController controller;
    private Transform playerCamera;
    private Vector3 playerVelocity;
    private Vector3 moveDirection;
    private Vector3 moveInput;
    private Vector3 lookInput;
    private bool groundedPlayer;
    private float headBobTimer;
    private Vector3 defaultHeadPosition;

    [Header("Headbob settings")]
    [SerializeField] private float headBobSpeed;
    [SerializeField] private float headBobDistance;

    [Header("Player settings")]
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        defaultHeadPosition = cameraPivot.localPosition;
    }

    void Update()
    {
        if (GameManager._manager.state != PlayerState.move) return;

        RaycastHit hit;
        Vector3 movement;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f, layerMask);
        //Physics.SphereCast(transform.position, 0.4f, -transform.up, out hit, controller.height / 2, layerMask);
        #region Movement
        transform.forward = new Vector3(playerCamera.forward.x, transform.forward.y, playerCamera.forward.z);
        moveDirection = (moveInput.x * transform.right + moveInput.y * transform.forward);

        float angle = OnSlope();
        movement = angle == 0 ? moveDirection : Vector3.ProjectOnPlane(angle <= 45 ? moveDirection : Vector3.down, hit.normal);
        HandleHeadBob();
        controller.Move(movement * Time.deltaTime * playerSpeed);
        #endregion

        #region Gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        #endregion
    }

    private void Jump()
    {
        if (groundedPlayer && OnSlope() < 45)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }

    private float OnSlope()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f, layerMask);
        float angle = Vector3.Angle(transform.up, hit.normal);
        return angle;
    }

    public void HandleHeadBob()
    {
        if (!groundedPlayer) return;
        if (moveInput == Vector3.zero)
        {
            cameraPivot.localPosition = defaultHeadPosition;
            return;
        }
        headBobTimer += Time.deltaTime * headBobSpeed;
        cameraPivot.localPosition += new Vector3(0, Mathf.Sin(headBobTimer) * headBobDistance, 0);
    }

    public void OnMove(InputValue value) => moveInput = value.Get<Vector2>();
    //public void OnJump(InputValue value) => Jump();
    public void OnLook(InputValue value) => lookInput = value.Get<Vector2>();
}
