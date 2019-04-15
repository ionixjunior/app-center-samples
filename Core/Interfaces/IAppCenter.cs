using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
	public interface IAppCenter
	{
		void TrackEvent(string name);
		void TrackEvent(string name, IDictionary<string, string> dictionary);
		void TrackError(Exception exception);
	}
}
