using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    MyInputManager myInputManager;
    Stats stats;
    CollisionScript collisionScript;

    public Camera playerCamera;
    public GameObject projectile;
    public GameObject specialAttack;
    public Transform castPoint;
    public Text specialAttackText;

    public int currency;
    public int specialCharges;

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

        collisionScript = GetComponent<CollisionScript>();
        stats = gameObject.GetComponent<Stats>();
    
        myInputManager = new MyInputManager();

        specialAttackText.text = specialCharges.ToString();

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

            InstantiateProjectile(projectile);
            attackCooldownCounter = 0;
            isAttackOnCooldown = true;
        }

        if (specialCharges > 0 && myInputManager.PlayerController.SpecialAttack.triggered)
        {

            InstantiateProjectile(specialAttack);
            specialCharges -= 1;
            specialAttackText.text = specialCharges.ToString();
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

    void InstantiateProjectile(GameObject attack)
    {

        Instantiate(attack, castPoint.transform.position, castPoint.rotation);
        
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
