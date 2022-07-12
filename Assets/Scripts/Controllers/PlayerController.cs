using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Settings settings;
    private AnimController animController;

    private CharacterController characterController;
    private DynamicJoystick joystick;
    private Transform playerTransform;

    [HideInInspector] public bool isHit = false;

    public GameObject scythe;
    private void Awake()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        joystick = GameObject.Find("Dynamic Joystick").GetComponent<DynamicJoystick>();
        animController = gameObject.GetComponent<AnimController>();
    }

    void FixedUpdate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        if(isHit == true)
        {
            animController.HitAnim();
            scythe.SetActive(true);
        }
        else if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            playerTransform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            characterController.Move(settings.PlayerSpeed * direction * Time.deltaTime);

            animController.WalkingAnim();
        }
        else
        {
            animController.IdleAnim();
        }
    }
}
