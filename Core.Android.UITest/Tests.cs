using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace Core.Android.UITest
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			// TODO: If the Android app being tested is included in the solution then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			app = ConfigureApp
				.Android
				// TODO: Update this path to point to your Android app and uncomment the
				// code if the app is not included in the solution.
				//.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
				.StartApp();
		}

		[Test]
		public void MainActivityTest()
		{
			app.Screenshot("When app start");

			app.Tap("Event 1");
			app.WaitForElement("Event 1 tapped");
			app.Screenshot("Event 1 tapped");

			app.Tap("Event 2");
			app.WaitForElement("Event 2 tapped");
			app.Screenshot("Event 2 tapped");

			app.Tap("Error 1");
			app.WaitForElement("Error 1 tapped");
			app.Screenshot("Error 1 tapped");
		}
	}
}
