using UnityEngine;
public class AnimController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public void WalkingAnim()
    {
        animator.SetBool("Walking", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Hit", false);
    }
    public void IdleAnim()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Walking", false);
        animator.SetBool("Hit", false);
    }

    public void HitAnim()
    {
        animator.SetBool("Hit", true);
        animator.SetBool("Walking", false);
        animator.SetBool("Idle", false);
    }
}
