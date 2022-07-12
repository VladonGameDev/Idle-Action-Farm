using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private Settings settings;
    private InterfaceController interfaceController;

    [HideInInspector]public int countWheat;
    private int money;
    private void Awake()
    {
        interfaceController = GameObject.Find("UI").GetComponent<InterfaceController>();
        money = 0;
    }
    public void AddBlockToInventory()
    {
        if(countWheat < settings.InventorySize)
        {
            countWheat++;
            interfaceController.InventoryUpdate(countWheat);
        }
    }

    public void SellWheat()
    {
        for(int i = 0; i < countWheat;i++)
        {
            money += 15;
        }
        countWheat=0;
        interfaceController.MoneyUpdate(money);
        interfaceController.InventoryUpdate(countWheat);
    }
}
