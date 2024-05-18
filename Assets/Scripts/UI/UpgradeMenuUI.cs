using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuUI : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject UpgradeMenu;
    [SerializeField] private GameObject UpgradeMenuButton;

    private bool isUpgradeMenuActive;

    #endregion

    #region Methods

    private void Start()
    {
        isUpgradeMenuActive = false; UpgradeMenu.SetActive(false);
    }

    public void ToggleUpgradeMenu()
    {
        UpgradeMenu.SetActive(!isUpgradeMenuActive);
        isUpgradeMenuActive = !isUpgradeMenuActive;
    }
   



    #endregion
}
