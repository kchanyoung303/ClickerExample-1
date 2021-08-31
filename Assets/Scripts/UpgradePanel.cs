using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private Image soldierImage = null;
    [SerializeField] private Text soldierName = null;
    [SerializeField] private Text priceText = null;
    [SerializeField] private Text amountText = null;
    [SerializeField] private Button purchaseButton = null;
    private Soldier soldier = null;

    public void SetValue(Soldier soldier)
    {
        soldierName.text = soldier.name;
        priceText.text = string.Format("{0} ¿¡³ÊÁö", soldier.price);
        amountText.text = string.Format("{0}", soldier.amount);
        this.soldier = soldier;
    }
    public void OnClickpurchase()
    {
        GameManager.Instance.CurrentUser.energy -= soldier.price;
        Soldier soldierInList=GameManager.Instance.CurrentUser.soldierList.Find((x)=>x==soldier);
        soldierInList.amount++;
        GameManager.Instance.uiManager.UpdateEnergyPanel();
    }

}
