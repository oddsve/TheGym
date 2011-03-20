using System;
namespace TheGym
{
	public class GymClass : IComparable
	{
		public string title { get; set; }
		public string instructor { get; set; }
		public string time { get; set; }
		public string vacant { get; set; }
		public string gym { get; set; }
		public string date { get; set; }
		public string status { get; set; }
		public string action { get; set; }
		
		
		public GymClass()
		{
			
		}
		
		public  int CompareTo (object obj)
		{
			GymClass otherGymClass = ( GymClass ) obj;
			if ( GymState.PerViewType == GymState.PER_CLASS )
				return title.CompareTo( otherGymClass.title );
			else if ( GymState.PerViewType == GymState.PER_GYM )
				return gym.CompareTo( otherGymClass.gym );
			else
				return time.CompareTo( otherGymClass.time );
		}
		
		
	}
	

}

