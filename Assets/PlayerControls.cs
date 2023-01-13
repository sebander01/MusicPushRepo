using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    Vector2 facing = Vector2.zero;
    Vector2 looking = Vector2.zero;
    public float speed;
    public float jumpSpeed;
    public MusicNotePush controls;
    public Camera camera;
    public Rigidbody rb;
    public GameObject player;
    public float CameraZ;
    public float CameraX;

    private InputAction WASD;
    private InputAction Jump;
    private InputAction Look;
    private bool canJump = true;

    private void Awake()
    {
        controls = new MusicNotePush();
    }
    // Start is called before the first frame update
    void Start()
    {
        controls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        facing = WASD.ReadValue<Vector2>();
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector3(facing.x * speed, rb.velocity.y, facing.y * speed);
        camera.transform.position = new Vector3(CameraX, player.transform.position.y, CameraZ);

        if(Jump.IsPressed() && canJump)
        {
            rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    public void OnEnable()
    {
        WASD = controls.Player.Move;
        Jump = controls.Player.Jump;
        Look = controls.Player.Look;

        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Floor")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Floor")
        {
            canJump = false;
        }
    }
}
