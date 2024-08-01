using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour {
	public float speed = 10f;

	void Start()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (IsServer)
		{
			if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
			{
				if (!player.IsOwner)
				{
					//player.TakeDamage(10);
				}
			}
			Destroy(gameObject);
		}
	}
}
