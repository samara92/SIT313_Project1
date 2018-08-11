using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using Assignment1.Adapter;
using System.Linq;

namespace Assignment1
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        public List<string> suggestSource = new List<string>();

        public GridViewAnswerAdapter answerAdapter;
        public GrideViewSuggestAdapter suggestAdapter;

        public Button btnSubmit;

        public GridView gvAnswer, gvSuggest;
        public ImageView imgLogo;
        int[] image_list = {

            Resource.Drawable.mango,
            Resource.Drawable.apple,
            Resource.Drawable.orange


        };
        public char[] answer;
        string correct_answer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);

            InitViews();

        }

        private void InitViews()
        {
            gvAnswer = FindViewById<GridView>(Resource.Id.gvAnswer);
            gvSuggest = FindViewById<GridView>(Resource.Id.gvSuggest);

            imgLogo = FindViewById<ImageView>(Resource.Id.imgLogo);

            SetupList();

            btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);
            btnSubmit.Click += delegate
            {
                //convert char arrays to string
                string result = new string(Common.Common.user_submit_answer);

                if (result.Equals(correct_answer))
                {
                    Toast.MakeText(ApplicationContext, "Finish! This is" + result.ToUpper(), ToastLength.Short).Show();

                    //Reset
                    Common.Common.user_submit_answer = new char[correct_answer.Length];

                    //Update UI
                    GridViewAnswerAdapter answerAdapter = new GridViewAnswerAdapter(setupNullList(), this);
                    gvAnswer.Adapter = answerAdapter;
                    answerAdapter.NotifyDataSetChanged();

                    GrideViewSuggestAdapter suggestAdapter = new GrideViewSuggestAdapter(suggestSource, this, this);
                    gvSuggest.Adapter = suggestAdapter;
                    suggestAdapter.NotifyDataSetChanged();

                    SetupList();
                }
                else
                    Toast.MakeText(this, "Incorrect!", ToastLength.Short).Show();


            };
            
        }

        private char[] setupNullList()
        {
            char[] result = new char[answer.Length];
            return result;
        }

        private void SetupList()
        {
            //Random Image
            Random random = new Random();
            int imageSelected = image_list[random.Next(image_list.Length)];
            imgLogo.SetImageResource(imageSelected);

            correct_answer = Resources.GetResourceName(imageSelected);
            correct_answer = correct_answer.Substring(correct_answer.LastIndexOf("/") + 1);

            answer = correct_answer.ToCharArray();

            Common.Common.user_submit_answer = new char[answer.Length];

            //add answr character to list
            suggestSource.Clear();
            foreach (char item in answer)
                suggestSource.Add(Convert.ToString(item));
            //Random character from alphabet list and add to the list

            for (int i = answer.Length; i < answer.Length * 2; i++)
                suggestSource.Add(Common.Common.alphabet_characters[random.Next(Common.Common.alphabet_characters.Length)]);
            //sort list
            suggestSource = suggestSource.OrderBy(x => Guid.NewGuid()).ToList();

            //set adapter for grid view
            answerAdapter = new GridViewAnswerAdapter(setupNullList(), this);
            suggestAdapter = new GrideViewSuggestAdapter(suggestSource, this, this);

            answerAdapter.NotifyDataSetChanged();
            suggestAdapter.NotifyDataSetChanged();

            gvAnswer.Adapter = answerAdapter;
            gvSuggest.Adapter = suggestAdapter;


        }
    }
}

