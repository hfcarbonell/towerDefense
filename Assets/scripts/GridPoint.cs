using System;

namespace AssemblyCSharp
{
	public class GridPoint
	{
		private int x;
		private int y;


		public GridPoint (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public void setX(int x){

			this.x = x;
		}

		public void setY(int y ){
			this.y = y;
		}

		public int getX(){
			return x;
		}
		public int getY(){
			return y;
		}

		public override String ToString(){
			return "Point { x: " + x + ", y: " + y + " } ";
		}

		public override bool Equals (object obj)
		{
			if (obj.GetType() != this.GetType()) {
				return false;
			} else {
				GridPoint other = (GridPoint)obj;
				return other.x == this.x && other.y == this.y;
			}
		}
	}
}

