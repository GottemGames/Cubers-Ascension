using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayCubeEssenceAbsorbtion : MonoBehaviour
{
    #region Classes

    public class OnCubeEssenceUpdateEventArgs : EventArgs
    {
        public float essence;
    }

    #endregion

    #region Events
    public event EventHandler<OnCubeEssenceUpdateEventArgs> OnCubeEssenceUpdate;

    #endregion

    #region Variables

    [Header("Object Attributes")]
    [SerializeField] private float cubeEssenceAbsorptionSpeed;
    [SerializeField] private float currentCubeEssence;
    [SerializeField] private float essenceAbsorptionRadius;

    [Header("External Game Objects")]
    [SerializeField] private Transform cuber;
    [SerializeField] private Transform spire;

    [Header("misc")]
    [SerializeField] private LayerMask spireMask;

    private bool playerIsNearSpire;

    #endregion

    #region Properties

    public float CurrentCubeEssence
    {
        get { return currentCubeEssence; }
        set { currentCubeEssence = value;  }
    }

    #endregion

    #region Methods

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

            OnCubeEssenceUpdate?.Invoke(this, new OnCubeEssenceUpdateEventArgs { essence = currentCubeEssence});
        }
    }
    #endregion
}
