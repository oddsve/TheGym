using System;
namespace TheGym
{
	public class GymClass 
	{
		public string title { get; set;	  }
		public string instructor { get; set; }
		public string time { get ;set;  }
		public string vacant { get; set; }
		public string gym { get; set; }
		public string date { get ;set;  }
		public string status { get; set; }
		public string action { get; set; }
		
		
		public GymClass( string title, string date, string time)
		{
			this.title = title;
			this.time = time;
			this.date = date;
			
		}
		
	
	}
	

}

