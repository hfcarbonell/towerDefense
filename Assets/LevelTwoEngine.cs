using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class LevelTwoEngine : LevelEngine
{
	public GameObject monsterTypeWave1;
	public GameObject monsterTypeWave2;
	public GameObject monsterTypeWave3;
	public GameObject monsterTypeWave4;

	void Start(){

		this.pathList = new ArrayList ();
		pathList.Add (new GridPoint (1, 0));
		pathList.Add (new GridPoint (1, 2));
		pathList.Add (new GridPoint (3, 2));
		pathList.Add (new GridPoint (3, 4));
		pathList.Add (new GridPoint (5, 4));
		pathList.Add (new GridPoint (5, 6));
		pathList.Add (new GridPoint (7, 6));
		pathList.Add (new GridPoint (7, 8));
		pathList.Add (new GridPoint (11, 8));
		pathList.Add (new GridPoint (11, 4));
		pathList.Add (new GridPoint (9, 4));
		pathList.Add (new GridPoint (9, 1));
		pathList.Add (new GridPoint (6, 1));
		this.towerList = new ArrayList ();
		towerList.Add (new GridPoint (1,1));
		waitTime = 10;

		this.monsterWaves = new ArrayList ();
		monsterWaves.Add (new MonsterWave (2, monsterTypeWave4));
		monsterWaves.Add (new MonsterWave (10, monsterTypeWave1));
		monsterWaves.Add (new MonsterWave (10, monsterTypeWave2));
		monsterWaves.Add (new MonsterWave (4, monsterTypeWave3));
		monsterWaves.Add (new MonsterWave (7, monsterTypeWave3));
		monsterWaves.Add (new MonsterWave (5, monsterTypeWave1));

		base.setup ();
	}



}


