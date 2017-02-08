using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class LevelEngine : MonoBehaviour {

	protected int gold = 300;
	protected int health = 20;

	public GameObject goldText;
	public GameObject healthText;
	protected ArrayList pathList;
	protected ArrayList towerList;
	protected ArrayList monsterWaves;
	protected int waitTime;

	protected ArrayList targetPathPoints;

	int currWave = 0;
	// Use this for initialization
	void Start () {
	}

	public void triggerWaves(){
		for (int i = 0; i < monsterWaves.Count; i++) {
			Invoke("sendWave", timeBetweenWaves*i);
		}
	}

	protected void setupBackground(){
		GridBoard gridBoard = this.GetComponentInParent<BackgroundGenerator> ().setupPath (pathList, towerList);
		this.targetPathPoints = gridBoard.pathTargets;
	}

	public int timeBetweenWaves = 5000;
	public int timeBetweenMonsters = 5;
	private bool waveStarted =false;

	private int waitBetweenMonsters = 100;
	private int currWait = 0;

	// Update is called once per frame
	void Update () {
		if (waveStarted) {
			if (sendList.Count > 0 && currWait == waitBetweenMonsters) {
				GameObject monster = (GameObject)sendList[0];
				sendList.RemoveAt (0);
				sendMonster (monster);
				currWait = 0;
			}
			currWait++;
		}
	}

	private void sendWave(){
		Debug.Log ("Sending wave: " + currWave);
		int currentWave = currWave;
		currWave++;
		if (currentWave < monsterWaves.Count) {
			MonsterWave wave =(MonsterWave) monsterWaves [currentWave];
			for (int i = 0; i < wave.totalMonsters; i++) {
				sendList.Add (wave.monster);
			}

		}
		waveStarted = true;
	}


	ArrayList sendList = new ArrayList();

	private void sendMonster(GameObject monster){
		GameObject newMonster = Instantiate (monster, (Vector3)targetPathPoints[0], transform.rotation);
		newMonster.GetComponent<MonsterScript> ().targetPoints = targetPathPoints;
		newMonster.GetComponent<MonsterScript> ().levelEngine = this.gameObject.GetComponent<LevelEngine>();
	}


	public void receiveGold(int value){
		gold = gold + value;
		updateGold ();
	}

	public bool useGold(int value){
		if (gold >= value) {
			gold = gold - value;
			updateGold ();
			return true;
		} else {
			return false;
		}
	}

	public void updateGold(){
		goldText.GetComponent<Text>().text = ""+gold;
	}


	public void updateHealth(){
		healthText.GetComponent<Text>().text = ""+health;
	}

	public void reduceHealth(int damage){
		health = health - damage;
		updateHealth ();
	}

}
