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
		public string action { get; set; }
		public bool booked { get; set; }
		public bool fullt { get; set; }

		private string _status;
		public string status 
		{ 	
			get{ return _status; } 
			set
			{ 
				_status = value;
				this.booked = value == "Booket";
				this.fullt = value == "Fullt";
			} 
		}
		
		
		public GymClass( string title, string date, string time)
		{
			this.title = title;
			this.time = time;
			this.date = date;
			
		}
		
	
	}
	

}

