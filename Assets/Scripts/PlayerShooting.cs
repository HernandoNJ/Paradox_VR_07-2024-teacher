using Unity.Netcode;
using UnityEngine;

public class PlayerShooting : NetworkBehaviour {
	public float moveSpeed = 5f;
	public Transform firePoint;
	public GameObject bulletPrefab;

	private void Update()
	{
		if (IsLocalPlayer)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Shoot();
			}
		}
	}

	void Shoot()
	{
		ShootServerRpc(firePoint.position, firePoint.rotation);
	}

	[ServerRpc]
	void ShootServerRpc(Vector3 position, Quaternion rotation)
	{
		// Create and spawn the bullet on the server
		GameObject bulletInstance = Instantiate(bulletPrefab, position, rotation);
		bulletInstance.GetComponent<NetworkObject>().Spawn();

		Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();
		rb.velocity = firePoint.forward * 10f;
	}
}
