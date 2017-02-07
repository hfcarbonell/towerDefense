using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class MonsterWave
	{
		public int totalMonsters;
		public GameObject monster;
		public MonsterWave (int totalMonsters, GameObject monster )
		{
			this.totalMonsters = totalMonsters;
			this.monster = monster;
		}
	}
}

