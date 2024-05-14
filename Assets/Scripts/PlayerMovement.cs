using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Object Attributes")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;

    [Header("External Game Objects")]
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
        //Listening to input manager event for player movement
        inputManager.OnPlayerMovementInputVectorChange += InputManager_OnPlayerMovementInputVectorChange;
    }

    private void FixedUpdate()
    {
        //moves the character
        characterController.Move(moveVector * speed * Time.deltaTime);
    }

    private void InputManager_OnPlayerMovementInputVectorChange(object sender, InputManager.OnPlayerMovementInputVectorChangeEventArgs e)
    {
        //sets the x & z values for player movement
        moveVector.x = e.inputVectorNormalized.x;
        moveVector.z = e.inputVectorNormalized.y;
    }
    #endregion
}
