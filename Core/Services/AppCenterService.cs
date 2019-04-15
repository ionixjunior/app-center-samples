using System;
using System.Collections.Generic;
using Core.Interfaces;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Core.Services
{
	public class AppCenterService : IAppCenter
	{
		public static IAppCenter Instance { get; private set; }

		public static void Init(string appSecret)
		{
			if (Instance != null)
				throw new Exception("The service only can be initialize a once");

			Instance = new AppCenterService();
			AppCenter.Start(appSecret, typeof(Analytics), typeof(Crashes));
		}

		public static void CleanInstance()
		{
			Instance = null;
		}

		private AppCenterService() {}

		public void TrackEvent(string name)
		{
			Analytics.TrackEvent(name);
		}

		public void TrackEvent(string name, IDictionary<string, string> dictionary)
		{
			Analytics.TrackEvent(name, dictionary);
		}

		public void TrackError(Exception exception)
		{
			Crashes.TrackError(exception);
		}
	}
}
