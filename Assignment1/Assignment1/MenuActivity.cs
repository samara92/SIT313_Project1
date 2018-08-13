using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Assignment1
{
    [Activity(Label = "MenuActivity", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class MenuActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.menu);

            Button btnSubmit1 = FindViewById<Button>(Resource.Id.btnSubmit1);
            btnSubmit1.Click += Button_Click;


        }

        private void Button_Click(object sender, EventArgs e)
        {

            SetContentView(Resource.Layout.main);
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}