using UnityEngine;

public class AutoDestroyText : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 5f; // Time before the text is destroyed.
    [SerializeField]
    private float moveSpeed = 50f; // Speed of movement in one step.

    private RectTransform rectTransform;
    private Vector2 direction = new Vector2(1, -1); // Initial direction: top-left to bottom-right.

    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("AutoDestroyText: No RectTransform found on the object.");
        }

        // Destroy this object after its lifetime.
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (rectTransform != null)
        {
            // Move the text diagonally by updating its position.
            rectTransform.anchoredPosition += direction * moveSpeed * Time.deltaTime;

            // Check if the text hits the right or left edge of the screen.
            if (rectTransform.anchoredPosition.x >= Screen.width || rectTransform.anchoredPosition.x <= 0)
            {
                direction.x *= -1; // Reverse horizontal direction.
            }

            // Check if the text hits the bottom of the screen.
            if (rectTransform.anchoredPosition.y <= 0)
            {
                direction.y *= -1; // Reverse vertical direction to bounce upward.
            }
        }
    }
}
