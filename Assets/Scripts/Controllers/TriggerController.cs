using UnityEngine;
public class TriggerController : MonoBehaviour
{
    [SerializeField]
    private Settings settings;

    private SliceController sliceController;
    private PlayerController playerController;
    private InventoryController inventoryController;
    private void Awake()
    {
        sliceController = GameObject.Find("Slice").GetComponent<SliceController>();
        playerController = GameObject.Find("Character").GetComponent<PlayerController>();
        inventoryController = GameObject.Find("Inventory").GetComponent<InventoryController>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sliceController.sliceableObject = this.gameObject;
            sliceController.Slice();

            playerController.isHit = true;

            Invoke("DeactivateObject", 1.2f);
            Invoke("Hiting", 1.7f);
            Invoke("ActivateObject", settings.WheatRipeningTime + 1.2f);
        }
    }
    private void DeactivateObject()
    {
        inventoryController.AddBlockToInventory();

        sliceController.isDrop = true;

        gameObject.SetActive(false);
    }

    private void Hiting()
    {
        playerController.isHit = false;
        playerController.scythe.SetActive(false);
    }
    private void ActivateObject()
    {
        gameObject.SetActive(true);
    }
}
