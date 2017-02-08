using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class LevelOneEngine : LevelEngine
{
	public GameObject monsterTypeWave1;
	public GameObject monsterTypeWave2;
	public GameObject monsterTypeWave3;
	public GameObject monsterTypeWave4;

	void Start(){

		this.pathList = new ArrayList ();
		pathList.Add (new GridPoint (3, 0));
		pathList.Add (new GridPoint (3, 6));
		pathList.Add (new GridPoint (14, 6));
		pathList.Add (new GridPoint (14, 1));
		pathList.Add (new GridPoint (6, 1));
		this.towerList = new ArrayList ();
		towerList.Add (new GridPoint (2,1));
		towerList.Add (new GridPoint (2,4));
		towerList.Add (new GridPoint (4,7));
		towerList.Add (new GridPoint (6,5));
		towerList.Add (new GridPoint (11,5));
		towerList.Add (new GridPoint (9,7));
		towerList.Add (new GridPoint (15,5));
		towerList.Add (new GridPoint (15,3));

		waitTime = 10;

		this.monsterWaves = new ArrayList ();
		monsterWaves.Add (new MonsterWave (2, monsterTypeWave4));
		monsterWaves.Add (new MonsterWave (10, monsterTypeWave1));
		monsterWaves.Add (new MonsterWave (10, monsterTypeWave2));
		monsterWaves.Add (new MonsterWave (4, monsterTypeWave3));
		monsterWaves.Add (new MonsterWave (7, monsterTypeWave3));
		monsterWaves.Add (new MonsterWave (5, monsterTypeWave1));
			
		setupBackground ();
	}



}


