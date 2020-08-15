using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public New_PlayerMovementTouch movement;

    void OnTriggerEnter(Collider collider)
    {
        movement.enabled = false;
        FindObjectOfType<GameManager>().EndGame();
    }
}
