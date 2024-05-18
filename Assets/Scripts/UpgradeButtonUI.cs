using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private Button upgradeButton;
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

    public void TryUpgrade()
    {
         float essence = cuber.CurrentCubeEssence;

        if (essence < upgradeButtonCost)
            return;

        cuber.CurrentCubeEssence = (essence - upgradeButtonCost);

        upgradeIndex++;

        upgradeButtonCost += upgradeButtonCost * upgradeIndex;

        Debug.Log("upgrade Cost: " + upgradeButtonCost);

    }
    #endregion
}
