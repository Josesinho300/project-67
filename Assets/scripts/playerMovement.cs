using UnityEngine;
using UnityEngine.Audio;
public class playerMovement : MonoBehaviour
{
    public Transform camTransform;
    public float mouseSensitivity;
    public float verticalRotation;
    public float currentSpeed;
    public float normalSpeed;
    public float runSpeed;

    private Rigidbody rb;
    public float jumpForce;
    public bool canJump;

    public AudioSource jumpSFX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = normalSpeed;
        runSpeed = normalSpeed * 2;
    }

    private void Start()
    {
        canJump = true;
    }

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensitivity;

        float horizontalInput = Input.GetAxisRaw("Horizontal") * Time.deltaTime * currentSpeed;
        float verticalInput = Input.GetAxisRaw("Vertical") * Time.deltaTime * currentSpeed;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, mouseX, 0);
        camTransform.localEulerAngles = new Vector3(verticalRotation, 0, 0);

        transform.Translate(horizontalInput, 0, verticalInput);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpSFX.Play();
        }
    }

    public void restoreJump()
    {
        canJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.CompareTag("ground"))
        {
            canJump = false;
        }
    }
}
