using System;
using System.Globalization;
namespace TheGym
{
	public class GymClass 
	{
		public string title { get; set;	  }
		public string instructor { get; set; }
		private string _time;
		public string time 		{ 	get { return _time; }		}
		public string vacant { get; set; }
		public string gym { get; set; }
		public string date { get ;set;  }
		public string bookAction { get; set; }
		public string unbookAction { get; set; }
		public bool booked { get; set; }
		public bool fullt { get; set; }
		private DateTime _startTime;
		public DateTime startTime 
		{ 	 get { return _startTime; }
		}

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
			this._time = time;
			this.date = date;	
			if ( date != "" ) 
			{
				string dateTimeString = date.Substring( date.Length-10)  + " " + _time.Substring(0,5);
				_startTime = DateTime.Parse( dateTimeString,new CultureInfo("nn-NO"));
			}
		}
		
		public void book()
		{
			if ( booked ) 
			{
				TTTBook.unBook( unbookAction );
				booked = false;
			} else
			{
				TTTBook.book ( bookAction );
				booked = true;
			}
		}
		
		
	
	}
	

}

