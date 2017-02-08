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
	private Animator animator;

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
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		nextMove ();
	}


	public void nextMove(){
		Vector3 target = (Vector3) targetPoints [currentTarget];
		if (this.transform.position == target && currentTarget < targetPoints.Count -1) {
			currentTarget++;
			Vector3 newtarget = (Vector3)targetPoints [currentTarget];
			triggerAnimationDirectionChange (target, newtarget);
			target = (Vector3)targetPoints [currentTarget];
		} else {
			this.transform.position = Vector3.MoveTowards (this.transform.position,target, 1 * speed);
		}
	}

	public void triggerAnimationDirectionChange(Vector3 current, Vector3 next){
		Vector3 diff = next - current;
		if (diff.x > 0) {
			animator.SetTrigger ("playerRight");
		} else if (diff.x < 0) {
			animator.SetTrigger ("playerLeft");
		} else if (diff.y > 0) {
			animator.SetTrigger ("playerUp");
		} else {
			animator.SetTrigger ("playerDown");
		}
		Debug.Log ("vector change: " + diff);
	}

}
