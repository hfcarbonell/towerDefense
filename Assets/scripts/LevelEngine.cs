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
	public GameObject waveNumberText;
	protected ArrayList pathList;
	protected ArrayList towerList;
	protected ArrayList monsterWaves;
	protected int waitTime;

	protected ArrayList targetPathPoints;

	// Use this for initialization
	protected void setup () {
		Debug.Log ("Start");
		updateGold ();
		updateHealth ();
		setupBackground ();
		waveRoutine = sendWaves ();
		setTotalWaves (0);
	}

	public void setTotalWaves(int waveNumber){
		waveNumberText.GetComponent<Text> ().text = waveNumber + "/" + monsterWaves.Count;
	}

	protected void setupBackground(){
		GridBoard gridBoard = this.GetComponentInParent<BackgroundGenerator> ().setupPath (pathList, towerList);
		this.targetPathPoints = gridBoard.pathTargets;
	}

	public int timeBetweenWaves = 50;
	public float timeBetweenMonsters = 0.5f;

	// Update is called once per frame
	void Update () {
	}

	IEnumerator waveRoutine;

	public void sendWave(){
		Debug.Log ("Starting enum: " + waveRoutine);
		StartCoroutine (waveRoutine);
	}

	public void pause(){
		StopCoroutine (waveRoutine);
	}

	private bool levelOver = false;


	private IEnumerator sendWaves(){
		Debug.Log ("Sending waves: "+monsterWaves.Count);
		for (int i = 0; i < monsterWaves.Count; i++) {
			yield return new WaitForSeconds(timeBetweenWaves);
			MonsterWave wave = (MonsterWave)monsterWaves [i];
			int monstersSent = 0;
			setTotalWaves (i+1);
			while (monstersSent <= wave.totalMonsters) {
				yield return new WaitForSeconds(timeBetweenMonsters);
				Debug.Log ("Sending monster");
				sendMonster (wave.monster);
				monstersSent++;
			}
		}
		levelOver = true;
	}

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
		if (health <= 0) {
			health = 0;
		}
		updateHealth ();
		checkLosingGame ();
	}


	public void checkLosingGame(){
		if (health <= 0) {
			this.transform.FindChild("LosingText").gameObject.SetActive(true);
			pause ();
		}
	}
}
