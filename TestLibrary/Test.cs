using System;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using AssemblyCSharp;

namespace TestLibrary
{
	[TestFixture ()]
	public class Test
	{


		[Test ()]
		public void test_path_isOnPath_Level1 ()
		{
			ArrayList pathList= new ArrayList ();
			pathList.Add (new GridPoint (3, 0));
			pathList.Add (new GridPoint (3, 6));
			pathList.Add (new GridPoint (14, 6));
			pathList.Add (new GridPoint (14, 1));
			pathList.Add (new GridPoint (7, 1));
			GridBoard bg = new GridBoard (pathList);

			bool val = bg.isOnPath ( new GridPoint(4,6));

			Assert.True(val);
		}

		[Test ()]
		public void test_path_isOnPath_zeroPathPoints ()
		{
			ArrayList list = new ArrayList ();
			GridBoard bg = new GridBoard (list);

			bool val = bg.isOnPath ( new GridPoint(1,2));

			Assert.False(val);
		}

		[Test ()]
		public void test_path_isOnPath_singlePathEntry_validPoint ()
		{

			ArrayList list = new ArrayList ();
			GridBoard bg = new GridBoard (list);
			list.Add (new GridPoint (1, 2));

			bool val = bg.isOnPath ( new GridPoint(1,2));

			Assert.True (val);
		}

		[Test ()]
		public void test_path_isOnPath_singlePathEntry_invalidPoint ()
		{
			ArrayList list = new ArrayList ();
			GridBoard bg = new GridBoard (list);
			list.Add (new GridPoint (1, 2));
			bool val = bg.isOnPath ( new GridPoint(5,6));

			Assert.False (val);
		}


		[Test ()]
		public void test_path_isOnPath_multiplePathEntries_validPoint ()
		{
			ArrayList list = new ArrayList ();
			list.Add (new GridPoint (1, 2));
			list.Add (new GridPoint (3, 2));
			GridBoard bg = new GridBoard (list);
			bool val = bg.isOnPath ( new GridPoint(2,2));
			Assert.True (val);
		}


		[Test ()]
		public void test_path_pointBetweenTwoPoints_validPoint ()
		{
			GridBoard bg = new GridBoard (new ArrayList());
			bool val = bg.pointBetweenTwoPoints(new GridPoint(2,2),new GridPoint(2,2), new GridPoint(2,2));
			Assert.True (val);

			val = bg.pointBetweenTwoPoints(new GridPoint(0,2),new GridPoint(2,2), new GridPoint(1,2));
			Assert.True (val);

			val = bg.pointBetweenTwoPoints(new GridPoint(0,2),new GridPoint(0,4), new GridPoint(0,3));
			Assert.True (val);
		}


		[Test ()]
		public void test_path_pointBetweenTwoPoints_invalidPoint ()
		{
			GridBoard bg = new GridBoard (new ArrayList());
			bool val = bg.pointBetweenTwoPoints( new GridPoint(0,1),new GridPoint(3,1),new GridPoint(7,1));
			Assert.False (val);

			val = bg.pointBetweenTwoPoints( new GridPoint(0,1),new GridPoint(3,1),new GridPoint(-1,1));
			Assert.False (val);

			val = bg.pointBetweenTwoPoints( new GridPoint(3,1),new GridPoint(0,1),new GridPoint(7,1));
			Assert.False (val);

			val = bg.pointBetweenTwoPoints( new GridPoint(3,1),new GridPoint(0,1),new GridPoint(2,3));
			Assert.False (val);

			val = bg.pointBetweenTwoPoints( new GridPoint(3,1),new GridPoint(3,2),new GridPoint(3,0));
			Assert.False (val);

			val = bg.pointBetweenTwoPoints( new GridPoint(3,1),new GridPoint(3,2),new GridPoint(3,6));
			Assert.False (val);

			val = bg.pointBetweenTwoPoints( new GridPoint(3,1),new GridPoint(3,2),new GridPoint(4,5));
			Assert.False (val);
		}

	}
}

