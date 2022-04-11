using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    MyInputManager myInputManager;
    Stats stats;
    public Camera playerCamera;

    //USED FOR MOVING
    float smoothInputSpeed;
    Vector3 playerPosition;
    Vector2 input;
    Vector2 currentInput;
    Vector2 velocity;

    //USED FOR ROTATION
    Ray ray;
    Plane plane;
    Vector3 cursorPosition;
    Vector3 direction;
    float rayDistance;
    float rotationAngle;

    private void Awake()
    {

        stats = gameObject.GetComponent<Stats>();
        myInputManager = new MyInputManager();



    }

    private void Update()
    {

        MoveCharacterWithKeyboard();
        CaracterRotation();


    }

    void MoveCharacterWithKeyboard()
    {

        input = myInputManager.PlayerController.Move.ReadValue<Vector2>();
        currentInput = Vector2.SmoothDamp(currentInput, input, ref velocity, smoothInputSpeed);
        playerPosition = new Vector3(currentInput.x, 0, currentInput.y);
        transform.position += playerPosition * stats.movementSpeed * Time.fixedDeltaTime;

    }

    void CaracterRotation()
    {

        //ray = playerCamera.ScreenPointToRay(myInputManager.PlayerController.MousePosition.ReadValue<Vector2>());
        ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out rayDistance))
        {
            cursorPosition = ray.GetPoint(rayDistance);
            direction = cursorPosition - transform.position;
            rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotationAngle, 0);

        }
    }

    private void OnEnable()
    {

        myInputManager.PlayerController.Enable();
        
    }

    private void OnDisable()
    {

        myInputManager.PlayerController.Disable();
        
    }


}
