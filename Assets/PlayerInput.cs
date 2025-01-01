using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;
    [SerializeField]
    private AutoDestroyText prefab; // Prefab to spawn
    [SerializeField]
    private RectTransform spawnObjectParent; // Parent RectTransform for spawned objects

    void Update()
    {
        if (Application.isFocused && Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Vector2 currentPosition = Mouse.current.position.ReadValue();
            if (currentPosition.y > Screen.height * 0.9f)
            {
                // Instantiate the text prefab at the mouse position inside the UI canvas
                AutoDestroyText instance = Instantiate(
                    prefab,
                    spawnObjectParent // Assign to the UI parent
                );
                instance.transform.position = currentPosition;
                instance.MoveSpeed = moveSpeed;
            }
        }
    }
}
