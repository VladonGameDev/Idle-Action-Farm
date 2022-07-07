using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public Animator animator;
    public float playerSpeed;
    void Awake()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        animator.SetBool("Idle", true);
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= 0.1f)
        {
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
