using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace Assignment1
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true)]
    //[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            InitViews();

        }

        // Set our view from the "main" layout resource
        //SetContentView(Resource.Layout.activity_main);

        private void InitViews()
        {

        
            
        }
    }
}

