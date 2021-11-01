using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;

using AndroidX.AppCompat.App;

namespace Phoneword
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        static readonly List<string> phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);

            string translatedNumber = string.Empty;
            translateButton.Click += (sender, e) =>
            {
                translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = "";
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                    phoneNumbers.Add(translatedNumber);
                    translationHistoryButton.Enabled = true;
                }
            };

            translationHistoryButton.Click += (sender, e) =>
            {
                //var intent = new Intent(this, typeof(TranslationHistoryActivity));
                var intent = new Intent(this, typeof(AzureActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}