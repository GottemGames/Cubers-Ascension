using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private InputManager inputManager;
    #endregion

    #region Functions
    private void Start()
    {
        inputManager.OnPlayerMovementInputVectorChange += InputManager_OnPlayerMovementInputVectorChange;
    }

    private void InputManager_OnPlayerMovementInputVectorChange(object sender, InputManager.OnPlayerMovementInputVectorChangeEventArgs e)
    {
        Debug.Log(e.inputVectorNormalized);
    }
    #endregion
}
