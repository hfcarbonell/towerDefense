using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour {

	public float speed = 10;
	public int damage = 100;
	public Vector3 target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.MoveTowards (this.transform.position, target, 1*speed);
		if (this.transform.position == target) {
			Destroy (this.gameObject);
		}
	
	}

}
