using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    MyInputManager myInputManager;
    Stats stats;

    public Camera playerCamera;
    public GameObject projectile;
    public Transform castPoint;
    Projectile projectileScript;

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

    //USED FOR COOLDOWN MANAGEMENT
    float attackCooldown;
    float attackCooldownCounter;
    float attackScaledValue;
    bool isAttackOnCooldown;

    private void Awake()
    {

        attackCooldown = 2;

        stats = gameObject.GetComponent<Stats>();
        projectileScript = projectile.GetComponent<Projectile>();
        myInputManager = new MyInputManager();

        

    }

    private void Update()
    {

        #region Cooldown management

        if (isAttackOnCooldown)
        {
            attackCooldownCounter += Time.fixedDeltaTime * stats.attackSpeed;

            if (attackCooldownCounter >= attackCooldown)
            {
                isAttackOnCooldown = false;
            }
        }
        #endregion

        if (!isAttackOnCooldown && myInputManager.PlayerController.Shoot.triggered)
        {

            InstantiateProjectile();

        }


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

    void InstantiateProjectile()
    {

        Instantiate(projectile, castPoint.transform.position, castPoint.rotation);
        attackCooldownCounter = 0;
        isAttackOnCooldown = true;
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
