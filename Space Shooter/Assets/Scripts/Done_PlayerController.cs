using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary
{
	public float xMin, xMax, zMin, zMax;
}
	
namespace CompleteProject
{
	public class Done_PlayerController : MonoBehaviour
	{
		public float speed;
		public Done_Boundary boundary;
		private Done_GameController gameController;

		public float RotateSpeed = 100f; //speed of the rotation

		public GameObject shot;
		public Transform shotSpawn;
		public float fireRate;

		private float nextFire;

		//these are used to calculate the foward/back and rotation of the player
		private float xAxis;
		private float yAxis; //used for ramps, still testing, delete if not functioning correctly
		private float zAxis;

		private Vector3 movement;

		private Rigidbody rBody;
		int floorMask;
		float camRayLength = 100f;

		void Awake()
		{
			floorMask = LayerMask.GetMask ("Floor");
			//playerHealth = gameObject.GetComponent <PlayerHealth> ();

			rBody = GetComponent <Rigidbody>();
		}

		void Start ()
		{
			GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
			gameController = gameControllerObject.GetComponent <Done_GameController>();



		}

		void Update()
		{
			//this allows the player to shoot lasers
			if (Input.GetButton("Fire1") && Time.time > nextFire) //Input.GetKey is used to figure out what key needs to be pushed, and it'll know it's the Space Bar because of "KeyCode.Space"
			{
				nextFire = Time.time + fireRate;

				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource>().Play();
			}
		}

		void FixedUpdate()
		{
			xAxis = Input.GetAxis("Horizontal");
			zAxis = Input.GetAxis("Vertical");

			Move(); //checks for position
			Turn(); //checks for rotation
		}

		private void Move()
		{
			
			movement.Set(xAxis, yAxis, zAxis);

			movement = movement.normalized * speed * Time.deltaTime;

			rBody.MovePosition (transform.position + movement);

		}

		private void Turn()
		{
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

			RaycastHit floorHit;

			if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
			{
				Vector3 mouse = floorHit.point - transform.position;

				mouse.y = 0f;

				Quaternion rotation = Quaternion.LookRotation (mouse);

				rBody.MoveRotation(rotation);
			}

		}

		private void OnTriggerEnter (Collider other)
		{
			if(other.gameObject.layer ==LayerMask.NameToLayer("PickUp"))
			{
				if(other.tag == "Coin")
				{
					gameController.AddCoin(1);
					other.gameObject.SetActive(false);
				}
				/*else if(other.tag == "Heal")
				{
					playerHealth.HealDamage(4);
					other.gameObject.SetActive(false);
				}*/
			}
		}
	}
}