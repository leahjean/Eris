using UnityEngine;
using System.Collections;

public class CharacterKeyboardControl : CharacterBaseControl {
    void Start() {
        // Set initial direction
        SetDirection(new Vector3(0, -1));
    }

    void Update() {
        UpdateDirection();
        UpdateInteraction();
        UpdateAttack();
    }

    void UpdateAttack() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            OnAttackPressed();
        }
    }

    void UpdateInteraction() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Escape();
        }
    }

    void UpdateDirection() {
        Vector2 newDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) {
            newDirection = Vector2.up;
        }

        if (Input.GetKey(KeyCode.S)) {
            newDirection = Vector2.down;
        }

        if (Input.GetKey(KeyCode.A)) {
            newDirection = Vector2.left;
        }

        if (Input.GetKey(KeyCode.D)) {
            newDirection = Vector2.right;
        }

        SetDirection(newDirection);
    }
}
