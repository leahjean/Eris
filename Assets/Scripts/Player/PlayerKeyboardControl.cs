using UnityEngine;
using System.Collections;
using Assets.Scripts.Player;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;

public class PlayerKeyboardControl : PlayerBaseControl {

    private static string ENABLE_RUNNING_KEY = "enableRunning";
    private static string JUMP_KEY = "jump";
    private static string DOWN_KEY = "down";
    private static string UP_KEY = "up";
    private static string LEFT_KEY = "left";
    private static string RIGHT_KEY = "right";
    private static string DASH_KEY = "dash";
    private static string MELEE_ATTACK_KEY = "meleeAttack";
    private static string PROJECTILE_ATTACK_KEY = "projectileAttack";
    private static string ESCAPE_KEY = "escape";
    private static string INTERACT_KEY = "interact";

    private static Dictionary<string, KeyCode> KEYMAP = new Dictionary<string, KeyCode>() {
        { ENABLE_RUNNING_KEY, KeyCode.LeftShift },
        { JUMP_KEY, KeyCode.LeftControl },
        { UP_KEY, KeyCode.W },
        { LEFT_KEY, KeyCode.A },
        { DOWN_KEY, KeyCode.S },
        { RIGHT_KEY, KeyCode.D },
        { DASH_KEY, KeyCode.Space },
        { MELEE_ATTACK_KEY, KeyCode.K },
        { PROJECTILE_ATTACK_KEY, KeyCode.L},
        { ESCAPE_KEY, KeyCode.Escape},
        { INTERACT_KEY, KeyCode.F},
    };

    void Start() {
        // Set initial direction
        SetDirection(new Vector3(0, -1));
    }

    void Update() {
        UpdateDirection();
        UpdateInteraction();
        UpdateJump();
        UpdateAttack();
    }

    void UpdateIsRunning()
    {
        if (Input.GetKeyDown(KEYMAP[ENABLE_RUNNING_KEY]))
        {
            SetRunningEnabled(true);
        }
        if (Input.GetKeyUp(KEYMAP[ENABLE_RUNNING_KEY]))
        { 
            SetRunningEnabled(false);
        }
    }

    void UpdateJump()
    {
        if (Input.GetKeyDown(KEYMAP[JUMP_KEY]))
        {
            OnJumpPressed();
        }
    }

    void UpdateAttack() {
        if (Input.GetKeyDown(KEYMAP[MELEE_ATTACK_KEY])) {
            OnAttackPressed();
        }
        if (Input.GetKeyDown(KEYMAP[PROJECTILE_ATTACK_KEY])) {
            OnProjectileThrown();
        }
    }

    void UpdateInteraction() {
        if (Input.GetKeyDown(KEYMAP[INTERACT_KEY])) {
            Interact();
        }

        if (Input.GetKeyDown(KEYMAP[ESCAPE_KEY])) {
            Escape();
        }
        if (Input.GetKeyDown(KEYMAP[DASH_KEY]))
        {
            Dash();
        }
    }

    void UpdateDirection() {
        UpdateIsRunning();

        Vector2 newDirection = Vector2.zero;

        if (Input.GetKey(KEYMAP[UP_KEY])) {
            newDirection = Vector2.up;
        }

        if (Input.GetKey(KEYMAP[DOWN_KEY])) {
            newDirection = Vector2.down;
        }

        if (Input.GetKey(KEYMAP[LEFT_KEY])) {
            newDirection = Vector2.left;
        }

        if (Input.GetKey(KEYMAP[RIGHT_KEY])) {
            newDirection = Vector2.right;
        }

        SetDirection(newDirection);
    }
}
