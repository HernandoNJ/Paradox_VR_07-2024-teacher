using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour {
	public float speed = 10f;

	void Start()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;

		if (IsOwner)
			Invoke(nameof(DestroyBulletServerRpc), 3f);
	}

	[ServerRpc]
	private void DestroyBulletServerRpc()
	{
		GetComponent<NetworkObject>().Despawn();
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (IsServer)
		{
			if (collision.gameObject.TryGetComponent(out PlayerController player))
			{
				if (!player.IsOwner)
				{
					Debug.Log("Is player owner: " + player.IsOwner);
					//player.TakeDamage(10);
				}
			}

			DestroyBulletServerRpc();
		}
	}
}
