using System;
using System.Collections;
using UnityEngine;

namespace CommonLibrary
{
	public class Path
	{

		private ArrayList pathList;

		public Path (ArrayList pathList)
		{
			this.pathList = pathList;
		}

		public bool isOnPath(Vector2 vector){
			for (int i = 0; i < pathList.Count; i++) {
				Vector2 pathVector = (Vector2) pathList[i];

			}

			return false;
		}
	}
}

