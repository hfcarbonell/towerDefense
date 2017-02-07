using System;
using System.Collections;
using UnityEngine;

namespace AssemblyCSharp
{
	public class GridBoard
	{
		private ArrayList pathList;
		private GridPoint castle;
		private GameObject pathSprite;
		private GameObject castleSprite;
		private GameObject grassSprite;
		private GameObject towerSprite;
		private GameObject towerButton;
		private int numberRows;
		private int numberColumns;
		private BackgroundGenerator instantiator;
		private ArrayList towerList;

		public ArrayList pathTargets;

		public GridBoard (int numberRows,
			int numberColumns, 
			ArrayList towerList,
			ArrayList pathList,
			GridPoint castle,
			GameObject towerSprite,
			GameObject pathSprite,
			GameObject grassSprite,
			GameObject castleSprite,
			GameObject towerButton,
			BackgroundGenerator instantiator)
		{
			this.towerList = towerList;
			this.pathList = pathList;
			this.castle = castle;
			this.numberRows = numberRows;
			this.numberColumns = numberColumns;
			this.instantiator = instantiator;
			this.towerButton = towerButton;

			this.grassSprite = grassSprite;
			this.pathSprite = pathSprite;
			this.castleSprite = castleSprite;
			this.towerSprite = towerSprite;
			this.pathTargets = new ArrayList ();
			buildGrid ();
		}

		public void buildGrid(){
			ArrayList list = new ArrayList ();
			float camHalfHeight = Camera.main.orthographicSize ;
			float camHalfWidth = Camera.main.aspect * camHalfHeight; 

			for (int i = 0; i < numberRows; i++) {
				for (int j = 0; j < numberColumns; j++) {
					GridPoint currentpoint = new GridPoint (j, i);
					if (!isOnPath (currentpoint) && !isCastle (currentpoint) ) {
						GameObject obj = instantiator.buildSprite (grassSprite, new Vector3 (-camHalfWidth + j + grassSprite.GetComponent<SpriteRenderer> ().bounds.size.x / 2 - .05f, -camHalfHeight + i + grassSprite.GetComponent<SpriteRenderer> ().bounds.size.y / 2 - .05f, 0));
						if (isATower (currentpoint)) {
							list.Add (obj);
						}
					} else if (isOnPath (currentpoint)) {
						instantiator.buildSprite (pathSprite, new Vector3 (-camHalfWidth + j + pathSprite.GetComponent<SpriteRenderer> ().bounds.size.x / 2 - .05f, -camHalfHeight + i + pathSprite.GetComponent<SpriteRenderer> ().bounds.size.y / 2 - .05f, 0));
					} 
				}
			}
			instantiator.buildSprite  (castleSprite, new Vector3 (-camHalfWidth + castle.getX(), -camHalfHeight + castle.getY() + .35f, 0));

			for (int i = 0; i < pathList.Count; i++) {
				GridPoint pathPoint = (GridPoint) pathList [i];
				float xLocation = -camHalfWidth + pathPoint.getX () + pathSprite.GetComponent<SpriteRenderer> ().bounds.size.x /2 - .05f;
				float yLocation = -camHalfHeight + pathPoint.getY () + pathSprite.GetComponent<SpriteRenderer> ().bounds.size.y / 2;
				pathTargets.Add(new Vector3(xLocation, yLocation));
			}

			foreach(GameObject tower in list){
				towerButton.transform.localScale = tower.transform.localScale;
				instantiator.buildCanvasSprite (towerButton, tower.transform.position);
			}
		}


		public bool isOnPath( GridPoint point){
			for (int i = 0; i < pathList.Count; i++) {
				GridPoint pathPoint = (GridPoint)pathList [i];
				if (point.Equals (pathPoint)) {
					return true;
				} else {
					if (i < pathList.Count - 1) {
						if (pointBetweenTwoPoints (pathPoint, (GridPoint)pathList [i + 1], point)) {
							return true;
						}
					} 
				}
			}
			return false;
		}

		public bool isATower(GridPoint x){
			foreach(GridPoint gridPoint in towerList){
				if (x.Equals (gridPoint)) {
					return true;
				}
			}
			return false;
		}

		public bool isCastle(GridPoint point){
			return point.Equals (castle);
		}

		public bool pointBetweenTwoPoints(GridPoint one, GridPoint two, GridPoint testPoint){
			if (testPoint.getX() != one.getX() && testPoint.getY() != one.getY()) {
				return false;
			} else if (testPoint.getX()== one.getX()) {
				return (testPoint.getY() >= one.getY() && testPoint.getY() <= two.getY()) || (testPoint.getY() <= one.getY() && testPoint.getY() >= two.getY());
			} else {
				return (testPoint.getX ()>= one.getX() && testPoint.getX() <= two.getX()) || (testPoint.getX() <= one.getX() && testPoint.getX() >= two.getX());
			}
		}
	}
}

