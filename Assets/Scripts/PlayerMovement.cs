using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;

    [SerializeField] private InputManager inputManager;

    private Vector3 moveVector = new Vector3();

    #endregion

    #region Functions

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        inputManager.OnPlayerMovementInputVectorChange += InputManager_OnPlayerMovementInputVectorChange;
    }

    private void FixedUpdate()
    {
        characterController.Move(moveVector * speed * Time.deltaTime);
    }

    private void InputManager_OnPlayerMovementInputVectorChange(object sender, InputManager.OnPlayerMovementInputVectorChangeEventArgs e)
    {
        moveVector.x = e.inputVectorNormalized.x;
        moveVector.z = e.inputVectorNormalized.y;
    }
    #endregion
}
