using UnityEngine;

[CreateAssetMenu(fileName = "New GameSettings", menuName = "GameSettings", order = 51)]
public class Settings : ScriptableObject
{
    [Header("Player settings")]

    [SerializeField]
    [Range(0.1f, 10f)] private float playerSpeed;
    public float PlayerSpeed { get { return playerSpeed; } }

    [SerializeField]
    [Range(1,100)] private int inventorySize;
    public int InventorySize { get { return inventorySize; } }

    [Header("Economy settings")]

    [SerializeField]
    private int wheatPrice;
    public int WheatPrice { get { return wheatPrice; } }

    [SerializeField]
    private float wheatRipeningTime;
    public float WheatRipeningTime { get { return wheatRipeningTime; } }
}
