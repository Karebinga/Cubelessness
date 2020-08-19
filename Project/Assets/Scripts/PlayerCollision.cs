using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovementTouch movement;

    void OnTriggerEnter(Collider collider)
    {
        movement.enabled = false;
        FindObjectOfType<GameManager>().EndGame();
    }
}
