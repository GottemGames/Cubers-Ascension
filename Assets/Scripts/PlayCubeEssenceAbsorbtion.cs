using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayCubeEssenceAbsorbtion : MonoBehaviour
{

    #region Events
    public event EventHandler OnCubeEssenceUpdate;

    #endregion

    #region Variables

    [Header("Player Attributes")]
    [SerializeField] private float cubeEssenceAbsorptionSpeed;
    [SerializeField] private float currentCubeEssence;
    [SerializeField] private float essenceAbsorptionRadius;

    [Header("Game Objects")]
    [SerializeField] private Transform cuber;
    [SerializeField] private Transform spire;

    [Header("misc")]
    [SerializeField] private LayerMask spireMask;

    private bool playerIsNearSpire;

    #endregion

    #region Functions

    private void Awake()
    {
        cuber = this.GetComponentInParent<Transform>();
    }
    private void Update()
    {
        if (spire == null)
            return;

        playerIsNearSpire = Physics.CheckSphere(cuber.position, essenceAbsorptionRadius, spireMask);
        
        if(playerIsNearSpire )
        {
            currentCubeEssence += cubeEssenceAbsorptionSpeed * Time.deltaTime;

            OnCubeEssenceUpdate?.Invoke(this, EventArgs.Empty);
        }
    }
    #endregion
}
