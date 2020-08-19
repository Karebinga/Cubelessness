using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 
                                                    gameObject.transform.position.y, 
                                                    player.position.z + offset.z);
    }
}
