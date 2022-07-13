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
        joystick = GameObject.Find("Dynamic Joystick").GetComponent<DynamicJoystick>();
        characterController = gameObject.GetComponent<CharacterController>();
        playerTransform = gameObject.GetComponent<Transform>();
        animController = gameObject.GetComponent<AnimController>();
    }

    private void Start()
    {
        joystick.MoveThreshold = 0;
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
            joystick.MoveThreshold = 999;
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
