using System;

namespace LinearStruct
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Sum and avararge
			Console.WriteLine ("Sum and Average. Enter space separated integers: ");
			try {
				var ints = new Integers (Console.ReadLine());
				Console.WriteLine ("Sum={0:G}; Average={1:G}", ints.Sum(), ints.Avg());
			}
			catch(FormatException e) {
				Console.WriteLine (e.Message);
			}



			// Sort words
			Console.WriteLine ("Sorting words. Enter space separated words: ");
			{
				var words = new Words (Console.ReadLine());
				Console.WriteLine (words.Sort());
			}



			// Longest subsequence
			Console.WriteLine ("Longest subsequence. Enter space separated integers: ");
			try {
				var ints = new Integers (Console.ReadLine());
				ints.LongestSeq().ForEach(i => Console.Write("{0} ", i));
				Console.Write ("\n");

			}
			catch(FormatException e) {
				Console.WriteLine (e.Message);
			}


			
			// Remove odd occurences
			Console.WriteLine ("Remove odd occurences. Enter space separated integers: ");
			try {
				var ints = new Integers (Console.ReadLine());
				ints.RemoveOddOcc().ForEach(i => Console.Write("{0} ", i));
				Console.Write ("\n");

			}
			catch(FormatException e) {
				Console.WriteLine (e.Message);
			}



			
			// Count occurences
			Console.WriteLine ("Count occurences. Enter space separated integers between 0 and 1000: ");
			try {
				var ints = new Integers (Console.ReadLine(), 0, 1000);
				foreach( var pair in ints.CountOcc()) {
					Console.WriteLine("{0} -> {1} times ", pair.Key, pair.Value);
				}

			}
			catch(FormatException e) {
				Console.WriteLine (e.Message);
			}
			catch(ArgumentOutOfRangeException e) {
				Console.WriteLine (e.Message);
			}



			// Reversed list
			Console.WriteLine ("Revered list. Adding elements 1,2,3,4 and changing index 0.");
			{
				var revList = new ReversedList<int> ();
				revList.Add (1);
				revList.Add (2);
				revList.Add (3);
				revList.Add (4);

				foreach (var item in revList) {
					Console.Write ("{0} ", item);
				}
				Console.Write ("\n");
				revList.Remove (0);
				foreach (var item in revList) {
					Console.Write ("{0} ", item);
				}
				Console.Write ("\n");
				revList.Add (4);
				foreach (var item in revList) {
					Console.Write ("{0} ", item);
				}
				Console.Write ("\n");

				revList [0] = 44;
				foreach (var item in revList) {
					Console.Write ("{0} ", item);
				}
				Console.Write ("\n");
				Console.Write (revList[0]);
				Console.Write ("\n");

			}



		}
	}
}
