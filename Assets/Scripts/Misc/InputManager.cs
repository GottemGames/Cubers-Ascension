using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Classes

    public class OnPlayerMovementInputVectorChangeEventArgs : EventArgs
    {
        public Vector2 inputVectorNormalized;
    }

    #endregion

    #region Events

    public event EventHandler<OnPlayerMovementInputVectorChangeEventArgs> OnPlayerMovementInputVectorChange;

    #endregion

    #region Variables
    PlayerInputMap playerInputMap; //InputMap for player input

    private Vector2 currentInputVector, newInputVector = new Vector2(0, 0);

    #endregion

    #region Functions

    private void Awake()
    {
        //Enables playerInputMap so it can be used in game
        playerInputMap = new PlayerInputMap();
        playerInputMap.Player.Enable();
    }

    private void Update()
    {
        //Gets new input vector and normalizes it (makes diagonal moving not go faster than non-diagonal moving)
        newInputVector = playerInputMap.Player.Move.ReadValue<Vector2>();
        newInputVector.Normalize();

        //Calls event if the input vector has changed then updates the currentInputVector
        if(newInputVector != currentInputVector)
        {
            OnPlayerMovementInputVectorChange?.Invoke(this, new OnPlayerMovementInputVectorChangeEventArgs {  inputVectorNormalized = newInputVector });

            currentInputVector = newInputVector;
        }
    }
    #endregion
}
