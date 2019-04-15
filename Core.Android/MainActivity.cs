using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Content.PM;
using Android.Widget;
using System;
using Core.Services;
using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Android
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		private IAppCenter _appCenter;
		private Button _btnEvent1;
		private Button _btnEvent2;
		private Button _btnError1;
		private Button _btnCrash1;
		private Button _btnInvalid;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			AppCenterService.Init("8bef428d-8ebf-4475-a4a7-566062aa6224");
			_appCenter = AppCenterService.Instance;

			SetContentView(Resource.Layout.activity_main);

			LoadElements();
			AssignClickEvents();
		}

		private void LoadElements()
		{
			_btnEvent1 = FindViewById<Button>(Resource.Id.btnEvent1);
			_btnEvent2 = FindViewById<Button>(Resource.Id.btnEvent2);
			_btnError1 = FindViewById<Button>(Resource.Id.btnError1);
			_btnCrash1 = FindViewById<Button>(Resource.Id.btnCrash1);
		}

		private void AssignClickEvents()
		{
			_btnEvent1.Click += OnEvent1Click;
			_btnEvent2.Click += OnEvent2Click;
			_btnError1.Click += OnError1Click;
			_btnCrash1.Click += OnCrash1Click;
		}

		private void OnEvent1Click(object sender, EventArgs e)
		{
			_appCenter.TrackEvent("event1");
			Toast.MakeText(ApplicationContext, "Event 1 tapped", ToastLength.Long).Show();
		}

		private void OnEvent2Click(object sender, EventArgs e)
		{
			var dictionary = new Dictionary<string, string>();
			dictionary.Add("android_sdk", Build.VERSION.Sdk);

			_appCenter.TrackEvent("event2", dictionary);
			Toast.MakeText(ApplicationContext, "Event 2 tapped", ToastLength.Long).Show();
		}

		private void OnError1Click(object sender, EventArgs e)
		{
			try
			{
				AddEmptyTextToInvalidButton();
			}
			catch (Exception exception)
			{
				_appCenter.TrackError(exception);
				Toast.MakeText(ApplicationContext, "Error 1 tapped", ToastLength.Long).Show();
			}
		}

		private void OnCrash1Click(object sender, EventArgs e)
		{
			AddEmptyTextToInvalidButton();
		}

		private void AddEmptyTextToInvalidButton()
		{
			_btnInvalid.Text = string.Empty;
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		protected override void OnDestroy()
		{
			UnassignClickEvents();
			base.OnDestroy();
		}

		private void UnassignClickEvents()
		{
			_btnEvent1.Click -= OnEvent1Click;
			_btnEvent2.Click -= OnEvent2Click;
			_btnError1.Click -= OnError1Click;
			_btnCrash1.Click -= OnCrash1Click;
		}
	}
}