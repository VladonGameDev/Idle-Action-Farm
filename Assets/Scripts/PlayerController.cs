using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    private DynamicJoystick joystick;
    private Transform playerTransform;
    public float playerSpeed;
    void Awake()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        joystick = GameObject.Find("Dynamic Joystick").GetComponent<DynamicJoystick>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            playerTransform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            characterController.Move(playerSpeed * direction * Time.deltaTime);

            WalkingAnim();
        }
        else
        {
            IdleAnim();
        }
    }

    private void WalkingAnim()
    {
        animator.SetBool("Walking", true);
        animator.SetBool("Idle", false);
    }
    private void IdleAnim()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Idle", true);
    }
}