using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonScript : MonoBehaviour {

	public int cost;
	private GameObject gameObject;

	// Use this for initialization
	void Start () {
	//	gameObject = this.transform.FindChild ("Sphere").gameObject;
	}

	public void trigger(){
		Debug.Log ("TRIGGER.");
		gameObject.SetActive (!gameObject.activeSelf);
	}

	public void deselectTrigger(){

		gameObject.SetActive (false);
	}
}
