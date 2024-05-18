using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private TextMeshProUGUI upgradeButton;
    [SerializeField] private PlayCubeEssenceAbsorbtion cuber;

    private float upgradeButtonCost;
    private float upgradeButtonStartingCost = 10;
    private int upgradeIndex;

    #endregion

    #region Functions

    private void Awake()
    {
        upgradeButtonCost = upgradeButtonStartingCost;
        upgradeIndex = 1;
    }

    private void Start()
    {
        upgradeButton.text = "Upgrade <br>" + upgradeButtonStartingCost;
    }

    public void TryUpgrade()
    {
         float essence = cuber.CurrentCubeEssence;

        if (essence < upgradeButtonCost)
            return;

        cuber.CurrentCubeEssence = (essence - upgradeButtonCost);

        upgradeIndex++;

        upgradeButtonCost += upgradeButtonCost * upgradeIndex;

        upgradeButton.text = "Upgrade <br>" + upgradeButtonCost;
    }
    #endregion
}
