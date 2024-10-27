using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    public EntityStats playerStats; 
    private PlayerInputActions inputActions;
    private Vector2 movementInput;
    private Rigidbody rb;
    private int currentHp;

    public GameObject healthBarPrefab;
    private HealthBar healthBar;

    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Move.performed += OnMovementInput;
        inputActions.Player.Move.canceled += OnMovementInput;
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMovementInput;
        inputActions.Player.Move.canceled -= OnMovementInput;
        inputActions.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHp = playerStats.MaxHp;

        GameObject hb = Instantiate(healthBarPrefab);
        healthBar = hb.GetComponent<HealthBar>();
        healthBar.SetTarget(transform);
        healthBar.SetHealth(currentHp, playerStats.MaxHp);
    }

    void Update()
    {
        MovePlayer();
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0f, movementInput.y).normalized;
        if (moveDirection.magnitude >= 0.1f)
        {
            float moveSpeed = playerStats.Speed;
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            TakeDamage(enemy.enemyStats.Damage);

            enemy.TakeDamage(playerStats.Damage);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHp -= amount;
        Debug.Log(playerStats.PlayerName + " took " + amount + " damage. Current HP: " + currentHp);

        healthBar.SetHealth(currentHp, playerStats.MaxHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(playerStats.PlayerName + " has died.");
    }
}