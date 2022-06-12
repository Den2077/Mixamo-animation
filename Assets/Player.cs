using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public float Speed;
    public Rigidbody rb;
    public int speedRotation;
    public Animator anim;
    public Animator animator;
    private Vector3 direction;
    public bool isGrounded;
    public float JumpForce;

    protected bool Left = false;
    protected bool Right = false;
    protected bool Forward = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("Idle", true);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += player.transform.forward * Speed * Time.deltaTime;

            anim.SetTrigger("IsRunning");
        }
        else
        {
            anim.SetBool("Idle", false);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position -= player.transform.forward * Speed * Time.deltaTime;

            anim.SetTrigger("Back");
        }
        else
        {
            anim.SetTrigger("IsRunning");
        }

        
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(Vector3.down * speedRotation);
        }
       

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(Vector3.up * speedRotation);     
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            anim.SetTrigger("IsJumping");
        }

    }

    private void FixedUpdate()
    {
        

        if (Left)
        {
            rb.AddForce(-Speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Right)
        {
            rb.AddForce(Speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
