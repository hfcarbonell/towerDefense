using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {

	public int health = 100;
	public LevelEngine levelEngine;
	public float speed = .01f;
	public ArrayList targetPoints;
	public int currentTarget = 0;
	public int damage = 1;
	public int goldLevel= 10;

	public void decrementHealth(int damage){
		health = health - damage;
		if (health <= 0) {
			Destroy (this.gameObject);
			levelEngine.receiveGold (goldLevel);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		BoltScript bolt = other.gameObject.GetComponent<BoltScript> ();
		if (bolt != null) {
			decrementHealth (bolt.damage);
			Destroy (other.gameObject);
		}
		else if (other.gameObject.name.Equals("Castle(Clone)")){
			levelEngine.reduceHealth (damage);
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 target = (Vector3) targetPoints [currentTarget];
		if (this.transform.position == target && currentTarget < targetPoints.Count -1) {
			currentTarget++;
			target = (Vector3)targetPoints [currentTarget];
		} else {
			this.transform.position = Vector3.MoveTowards (this.transform.position,target, 1 * speed);
		}
	}

}
