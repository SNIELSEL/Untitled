using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class ControllerMovement : MonoBehaviour
{
    private PlayerControlls playerControlls;
    private InputAction rightStick;
    private InputAction leftStick;
    public GameObject fPPCamera;
    private Vector3 movementInput;
    public Vector2 cameraRotation;

    private float moveSpeed, startSpeed, rotationSpeed;

    public void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    public void OnEnable()
    {
        playerControlls.Enable();

        rightStick = playerControlls.DeafultMovement.Rotation;
        rightStick.Enable();

        leftStick = playerControlls.DeafultMovement.Movement;
    }

    public void OnDisable()
    {
        playerControlls.Disable();
        rightStick.Disable();
    }

    public void Start()
    {
        startSpeed = 10;
        rotationSpeed= 5;

        moveSpeed = startSpeed;
    }

    public void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        movementInput.x = playerControlls.DeafultMovement.Movement.ReadValue<Vector2>().x;
        movementInput.z = playerControlls.DeafultMovement.Movement.ReadValue<Vector2>().y;

        transform.Translate(movementInput * Time.deltaTime * moveSpeed);
    }

    public void Rotate()
    {
        cameraRotation = rightStick.ReadValue<Vector2>() * rotationSpeed;

        fPPCamera.transform.Rotate(-cameraRotation.y, 0, 0 * Time.deltaTime);
        transform.Rotate(-0, cameraRotation.x, 0 * Time.deltaTime);
    }

}
