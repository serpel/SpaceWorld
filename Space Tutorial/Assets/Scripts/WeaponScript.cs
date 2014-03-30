using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	
	public Transform shotPrefab;

	private Transform[] shotArray;
	private int i = 0;
	public int poolSize = 20;

	public float shootingRate = 0.25f;
	private float shootCoolDown;

	public bool CanAttack
	{
		get{ return shootCoolDown <= 0f; }
	}

	// Use this for initialization
	void Start () {
		shootCoolDown = 0f;
		shotArray = new Transform[poolSize];
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCoolDown > 0) {
			shootCoolDown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy){
		if (CanAttack) {

			shootCoolDown = shootingRate;

			if(shotArray[i] != null){
				Destroy(shotArray[i].gameObject);
			}

			shotArray[i] = Instantiate(shotPrefab) as Transform;
			shotArray[i].position = transform.position;
			ShotScript shot = shotArray[i].gameObject.GetComponent<ShotScript>();

			if(shot != null){
				shot.isEnemyShot = isEnemy;
			}

			MoveScript move = shotArray[i].gameObject.GetComponent<MoveScript>();

			if(move != null){
				move.direction = transform.right;
			}
			i++;
			if (i >= poolSize) i = 0;
		}
	}
}
