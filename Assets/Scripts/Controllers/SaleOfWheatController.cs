using UnityEngine;
using DG.Tweening;
public class SaleOfWheatController : MonoBehaviour
{
    [SerializeField]
    private Settings settings;
    private InventoryController inventoryController;
    private Transform playerTransform;

    public GameObject dropBlock;
    public Transform SellTarget;

    private void Awake()
    {
        inventoryController = GameObject.Find("Inventory").GetComponent<InventoryController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inventoryController.SellWheat();
            var Block = Instantiate(dropBlock, new Vector3(playerTransform.position.x, playerTransform.position.y + 1f, playerTransform.position.z), Quaternion.identity, SellTarget);
            Block.transform.DOJump(SellTarget.position, 1.5f, 1, 0.5f, false);
        }
    }
}
