using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private  Text energyText = null;
    [SerializeField]
    Animator beakerAnimator = null;
    [SerializeField]
    private UpgradePanel upgradePanelTemplate = null;

    private List<UpgradePanel> upgradePanelList = new List<UpgradePanel>();
    // Start is called before the first fratme update
    void Start()
    {
        UpdateEnergyPanel();
        CreatePanels();
    }

    public void CreatePanels()
    {
        GameObject panel = null;
        UpgradePanel panelComponent = null;

        foreach(var soldier in GameManager.Instance.CurrentUser.soldierList)
        {
            panel = Instantiate(upgradePanelTemplate.gameObject, upgradePanelTemplate.transform.parent);
            panelComponent = panel.GetComponent<UpgradePanel>();
            panelComponent.SetValue(soldier);
            panel.SetActive(true);
            upgradePanelList.Add(panelComponent);
        }
    }

    // Update is called once per frame
    public void OnClickBeaker()
    {
        GameManager.Instance.CurrentUser.energy += 1;
        beakerAnimator.Play("Click");
        UpdateEnergyPanel();
    }

    public void UpdateEnergyPanel()
    {
        energyText.text = string.Format("{0} ??????", GameManager.Instance.CurrentUser.energy);
    }
}
