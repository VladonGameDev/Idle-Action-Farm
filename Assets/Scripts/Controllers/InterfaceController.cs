using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
public class InterfaceController : MonoBehaviour
{
    [SerializeField]
    private Settings settings;
    private int totalMoney;

    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI inventoryText;

    private void Awake()
    {
        moneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
        inventoryText = GameObject.Find("InventoryText").GetComponent<TextMeshProUGUI>();
        InventoryUpdate(0);
        MoneyUpdate(0);
    }

    IEnumerator MoneyUp(int money, int i)
    {
        while(true)
        {

            moneyText.text = "Money: " + i;
            if(i < money)
            {
                i++;
            }
            else
            {
                StopAllCoroutines();
                totalMoney += i;
            }
            yield return new WaitForSeconds(0.02f);
        }
    }
    public void InventoryUpdate(int countWheat)
    {
        inventoryText.text = "Inventory: " + countWheat + "/" + settings.InventorySize;
    }

    public void MoneyUpdate(int money)
    {
        StartCoroutine(MoneyUp(money, totalMoney));
    }
}
