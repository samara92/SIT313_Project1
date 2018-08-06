﻿using System;
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
    public class GridViewSuggestAdapter:BaseAdapter
    {
        private List<string> suggestSource;
        private Context context;
        private MainActivity mainActivity;

        public GridViewSuggestAdapter(List<string> suggestSource, Context context, MainActivity mainActivity)
        {
            this.suggestSource = suggestSource;
            this.context = context;
            this.mainActivity = mainActivity;
        }

        public override int Count
        {
            get
            {
                return suggestSource.Count;
            }

        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Button button;
            if (convertView == null)
            {
                if (suggestSource[position].Equals("null"))
                {
                    button = new Button(context);
                    button.LayoutParameters = new GridViewSuggestAdapter.LayoutParams(85, 85);
                    button.SetPadding(8, 8, 8, 8);
                    button.SetBackgroundColor(Color.DarkGray);
                }
                else
                {
                    button = new Button(context);
                    button.LayoutParameters = new GridViewSuggestAdapter.LayoutParams(85, 85);
                    button.SetPadding(8, 8, 8, 8);
                    button.SetBackgroundColor(Color.DarkGray);
                    button.SetTextColor(Color.Yellow);
                    button.Text = suggestSource[position];
                    button.Click += delegate
                    {
                        //
                    };
                }

            }
            else
                button = (button)convertView;
            return button;
        }
    }

}