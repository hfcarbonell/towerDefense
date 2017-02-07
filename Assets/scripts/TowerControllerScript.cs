using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerControllerScript : MonoBehaviour {
	
	public bool ringActive = false;
	private Button towerButton;
	private Sprite baseTowerImage;
	private GameObject bolt;
	private bool towerSet = false;
	private int fireSpeed;

	private LevelEngine levelEngine;

	private int currentSellCost = 0;
	private GameObject monsterTarget;

	void OnTriggerStay2D(Collider2D other){
		if (monsterTarget == null) {
			MonsterScript monsterScript = other.gameObject.GetComponent<MonsterScript> ();
			if(monsterScript  != null) {
				setTarget (other.gameObject);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (monsterTarget == other.gameObject) {
			monsterTarget = null;
		}
	}

	private void setTarget(GameObject target){
		monsterTarget = target;
	}

	public void fireBullet(Transform targetTransform){
		GameObject newBolt = Instantiate(bolt, transform.position, transform.rotation);
		newBolt.GetComponent<BoltScript> ().target = targetTransform.position;
	}

	public void toggleRing(){
		ringActive = !ringActive;
		setRingState(ringActive);
	}

	private void setRingState(bool isActive){
		GameObject ring = this.gameObject.transform.FindChild ("Ring").gameObject;
		ring.SetActive (isActive);
	}

	public void setBolt(GameObject bolt){
		this.bolt = bolt;
	}

	public void buyTower(string childName){
		GameObject tower = this.gameObject.transform.FindChild ("Ring").FindChild ("NewTowers").FindChild (childName).gameObject;
		int cost = tower.GetComponent<TowerButtonScript> ().cost;

		if (levelEngine.useGold(cost)) {
			towerButton.image.sprite = tower.GetComponent<Button> ().image.sprite;
			disableNewTowerBuilds ();
			enableTowerState ();
			toggleRing ();
			towerSet = true;
			currentSellCost = Mathf.CeilToInt(cost*.9f);
		} else {
			toggleRing ();
		}
	}

	public void setFireSpeed(int newSpeed){
		fireSpeed = newSpeed;
	}

	public void sellTower(){
		disableTowerState ();
		enableNewTowerBuilds ();
		towerButton.image.sprite = baseTowerImage;
		toggleRing ();
		towerSet = false;
		levelEngine.receiveGold (currentSellCost);
	}

	public void disableNewTowerBuilds(){
		this.gameObject.transform.FindChild ("Ring").FindChild ("NewTowers").gameObject.SetActive(false);
	}

	public void enableNewTowerBuilds(){
		this.gameObject.transform.FindChild ("Ring").FindChild ("NewTowers").gameObject.SetActive(true);
	}

	public void enableTowerState(){
		this.gameObject.transform.FindChild ("Ring").FindChild ("TowerStates").gameObject.SetActive(true);
	}

	public void disableTowerState(){
		this.gameObject.transform.FindChild ("Ring").FindChild ("TowerStates").gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		towerButton = this.gameObject.transform.FindChild ("CurrentTower").gameObject.GetComponent<Button> ();
		baseTowerImage = towerButton.image.sprite;
		setRingState (ringActive);
		towerSet = false;

		levelEngine = this.gameObject.GetComponentInParent<LevelEngine> ();
	}

	int currWait = 0;


	void Update () {

		if (currWait <= fireSpeed) {

			currWait++;

		} else {

			if (ringActive == false && towerSet && monsterTarget != null) {
				fireBullet (monsterTarget.transform);	
			}
			currWait = 0;
		}
		
	}
}
