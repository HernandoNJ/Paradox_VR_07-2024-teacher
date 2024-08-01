using Unity.Netcode;
using TMPro;

public class PlayerController : NetworkBehaviour {

	public string playerId;
	public TextMeshProUGUI healthText;
	public NetworkVariable<int> netPlayerHealth;

	private void Start()
	{
		playerId = NetworkObjectId.ToString();
		netPlayerHealth.Value = 100;
		UpdateHealth();
	}
	private void UpdateHealth()
	{
		healthText.text = "Id: " + playerId + ", H: " + netPlayerHealth.Value;
	}


	//public float moveSpeed = 5f;
	//public NetworkObject bulletPrefab;
	//public Transform firePoint;
	//public TextMeshProUGUI healthText;
	//public NetworkVariable<int> playerHealth;

	//void Start()
	//{
	//	UpdateHealthText();
	//}

	//void Update()
	//{
	//	if (!IsOwner)
	//		return;

	//	float moveX = Input.GetAxis("Horizontal");
	//	float moveZ = Input.GetAxis("Vertical");
	//	Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
	//	transform.Translate(move, Space.World);

	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		Shoot();
	//	}
	//}

	//void Shoot()
	//{
	//	ShootServerRpc(firePoint.position, firePoint.rotation);
	//}

	//[ServerRpc]
	//void ShootServerRpc(Vector3 position, Quaternion rotation)
	//{
	//	bulletPrefab.GetComponent<NetworkObject>().Spawn();
	//	Rigidbody rb = bulletPrefab.GetComponent<Rigidbody>();
	//	rb.velocity = firePoint.forward * 10f;
	//}

	//void OnTriggerEnter(Collider other)
	//{

	//	if (other.CompareTag("Bullet") && !IsOwner)
	//	{
	//		TakeDamage(10);
	//	}
	//}

	//public void TakeDamage(int damage)
	//{
	//	if (IsServer)
	//	{
	//		playerHealth.Value -= damage;
	//		UpdateHealthText();
	//	}
	//}

	//void UpdateHealthText()
	//{
	//	healthText.text = "Health: " + playerHealth.Value.ToString();
	//}
}
