using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    public GameObject bullet;
    public float bulletSpeed = 100f;


    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private bool doJump = false;
    private bool doShoot = false;



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }


    // Update is called once per frame
    void Update()
    {

        vInput = Input.GetAxis("Vertical") * moveSpeed;

        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            doJump = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            doShoot = true;
        }


    }


    private void FixedUpdate()
    {
        if (doJump)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            doJump = false;
        }


        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (doShoot)
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + this.transform.right, this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            doShoot = false;
        }
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }


    private float speedMultiplier;
    private float jumpMultiplier;

    public void BoostSpeed(float multiplier, float seconds)
    {
        speedMultiplier = multiplier;
        moveSpeed *= multiplier;
        Invoke("EndSpeedBoost", seconds);
    }

    private void EndSpeedBoost()
    {
        Debug.Log("Speed boost is over!");
        moveSpeed /= speedMultiplier;
    }

    public void BoostJump(float multiplier, float seconds)
    {
        jumpMultiplier = multiplier;
        jumpVelocity *= multiplier;
        Invoke("EndJumpBoost", seconds);
    }
    
    private void EndJumpBoost()
    {
        Debug.Log("Jump boost is over!");
        jumpVelocity /= speedMultiplier;
    }  
}