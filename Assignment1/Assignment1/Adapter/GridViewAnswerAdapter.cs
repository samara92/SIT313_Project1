using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Assignment1.Adapter
{
    public class GridViewAnswerAdapter:BaseAdapter 
    {
        private char[] answerCharacters;
        private Context context;

        public GridViewAnswerAdapter(char[] answerCharacters, Context context)
        {
            this.answerCharacters = answerCharacters;
            this.context = context;
        }

        public override int Count
        {
            get
            {
                return answerCharacters.Lenghth;
            }
        }

        public override Java.Lang.Object getItem(int position)
        {
            return answerCharacters[position];
        }

        public override long GetItemId(int position)
        {
            throw new NotImplementedException();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Button button;
            if (convertView == null)
            {
                button = new Button(context);
                button.LayoutParameters = new GrideView.LayoutParams(85, 85);
                button.SetPadding(8, 8, 8, 8);
                button.SetBackgroundColor(Color.DarkGray);
                button.SetTextColor(Color.Yellow);
                button.Text = Convert.ToString(answerCharacters[position]);

            }
            else
                button = (Button)convertView;
            return button;
        }


    }
}