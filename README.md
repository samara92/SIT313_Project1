# SIT313_Project1
# SIT313 Developing Client-Server Web Application 
# Name:Sameera Dinusha Priyananda
# SID: 215158268

# App Name: Kids preschool game
# Platform: Xamarin with  Android

# Directory Layout

  - Adapter
  - Assets
  - Common
  - Resources
      - Drawable
      - layout
  - Values
  
# public classes/functions/methods

public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Button button;
            if (convertView == null)
            {
                button = new Button(context);
                button.LayoutParameters = new GridView.LayoutParams(85, 85);
                button.SetPadding(8, 8, 8, 8);
                button.SetBackgroundColor(Color.DarkGray);
                button.SetTextColor(Color.Yellow);
                button.Text = Convert.ToString(answerCharacters[position]);

            }
            else
                button = (Button)convertView;
            return button;
            
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
                    Toast.MakeText(ApplicationContext, "Correct Answer! This is " + result.ToUpper(), ToastLength.Short).Show();

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
                    Toast.MakeText(this, "Incorrect! Try again!!", ToastLength.Short).Show();


            };
            
        }
