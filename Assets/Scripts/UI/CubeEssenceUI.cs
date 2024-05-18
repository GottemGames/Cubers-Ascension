using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class CubeEssenceUI : MonoBehaviour
{
    #region Variables

    [SerializeField] private PlayCubeEssenceAbsorbtion Cuber;
    [SerializeField] private TextMeshProUGUI cubeEssenceUI;

    #endregion

    #region Methods

    private void Start()
    {
        cubeEssenceUI.text = ("Cube Essence: 0");

        Cuber.OnCubeEssenceUpdate += Cuber_OnCubeEssenceUpdate;
    }

    private void Cuber_OnCubeEssenceUpdate(object sender, PlayCubeEssenceAbsorbtion.OnCubeEssenceUpdateEventArgs e)
    {
        string essence = e.essence.ToString("F0");
        cubeEssenceUI.text = ("Cube Essence: " + essence);
    }


    #endregion

}
