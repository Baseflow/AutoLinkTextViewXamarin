using Android.App;
using Android.Widget;
using Android.OS;
using Com.Luseen.Autolinklibrary;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using System;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true, Icon = "@mipmap/icon", Theme="@style/AppTheme")]
    public class MainActivity : AppCompatActivity, IAutoLinkOnClickListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            AutoLinkTextView autoLinkTextView = FindViewById<AutoLinkTextView>(Resource.Id.active);

            autoLinkTextView.AddAutoLinkMode(new[] {
                    AutoLinkMode.ModeHashtag,
                    AutoLinkMode.ModePhone,
                    AutoLinkMode.ModeUrl,
                    AutoLinkMode.ModeMention,
                    AutoLinkMode.ModeCustom});

            autoLinkTextView.SetCustomRegex("\\sAllo\\b");

            autoLinkTextView.SetHashtagModeColor(ContextCompat.GetColor(this, Resource.Color.color2));
            autoLinkTextView.SetPhoneModeColor(ContextCompat.GetColor(this, Resource.Color.color3));
            autoLinkTextView.SetCustomModeColor(ContextCompat.GetColor(this, Resource.Color.color1));
            autoLinkTextView.SetMentionModeColor(ContextCompat.GetColor(this, Resource.Color.color5));

            autoLinkTextView.SetAutoLinkText(GetString(Resource.String.long_text));

            autoLinkTextView.SetAutoLinkOnClickListener(this);
        }

        public void OnAutoLinkTextClick(AutoLinkMode autoLinkMode, string matchedText)
        {
            Toast.MakeText(this, matchedText + " Mode is: " + autoLinkMode.ToString(), ToastLength.Long).Show();
            //ShowDialog(matchedText, "Mode is: " + autoLinkMode.ToString());
        }
    }
}

