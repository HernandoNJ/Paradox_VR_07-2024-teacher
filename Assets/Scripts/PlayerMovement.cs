using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour {

	public float moveSpeed = 5f;
	public bool hasRb;
	private Rigidbody rb;

	public override void OnNetworkSpawn()
	{
		if (hasRb)
			rb = GetComponent<Rigidbody>();
	}

	//private void Update()
	//{
	//	if (!IsLocalPlayer)
	//		return;

	//	float moveX = Input.GetAxis("Horizontal");
	//	float moveZ = Input.GetAxis("Vertical");

	//	if (!hasRb)
	//		MovePlayerServerRpc(moveX, moveZ, hasRb);

	//}

	void FixedUpdate()
	{
		if (!IsLocalPlayer)
			return;

		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");

		if (hasRb)
			MovePlayerServerRpc(moveX, moveZ, hasRb);
	}

	[ServerRpc]
	private void MovePlayerServerRpc(float moveX, float moveZ, bool hasRb)
	{
		if (!hasRb)
			TranslateNetworkPlayer(moveX, moveZ);
		else
			MoveNetworkPlayerRb(moveX, moveZ);

		void TranslateNetworkPlayer(float moveX, float moveZ)
		{
			Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
			transform.Translate(move, Space.World);
		}

		void MoveNetworkPlayerRb(float moveX, float moveZ)
		{
			Vector3 moveInput = new Vector3(moveX, 0, moveZ);
			rb.velocity = moveInput * moveSpeed;
		}
	}
}