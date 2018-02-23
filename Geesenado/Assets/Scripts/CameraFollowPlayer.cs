using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public Transform player;
	public float smoothTime = 0.3f;

	private Vector3 velocity = Vector3.zero;

	void Update ()
	{
		if(player != null)
		{
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
		}
	}
}