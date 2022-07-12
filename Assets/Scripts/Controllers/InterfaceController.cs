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

    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI inventoryText;

    public RectTransform coin;

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
            if(i<money)
            {
                i++;
            }
            else
            {
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void InventoryUpdate(int countWheat)
    {
        inventoryText.text = "Inventory: " + countWheat + "/" + settings.InventorySize;
    }

    public void MoneyUpdate(int money)
    {
        int i = 0;
        StartCoroutine(MoneyUp(money, i));
    }
}
