using System.Collections;
using UnityEngine;
using AssemblyCSharp;

public class BackgroundGenerator : MonoBehaviour {
	public GameObject grass;
	public GameObject path;
	public GameObject castle;
	public GameObject tower;
	public GridBoard gridPath;
	public GameObject canvas;
	public GameObject towerButton;


	// Use this for initialization
	void Start () {
	}

	public GridBoard setupPath(ArrayList pathList, ArrayList towerList){

		int numberRows = Mathf.FloorToInt(Camera.main.orthographicSize*2);
		int numberColumns = Mathf.FloorToInt(Camera.main.aspect * numberRows*2);

		gridPath = new GridBoard (numberRows, numberColumns,towerList, pathList,new GridPoint(6,1), tower, path,grass,castle,towerButton,this);
		return gridPath;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public GameObject buildSprite(GameObject sprite, Vector3 vector){
		return Instantiate (sprite, vector, Quaternion.identity);
	}

	public void buildCanvasSprite(GameObject sprite, Vector3 vector){
		GameObject btn = Instantiate (sprite, vector, Quaternion.identity);
		btn.transform.SetParent (canvas.transform,true);
	}

}
