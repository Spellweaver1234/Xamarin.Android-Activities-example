using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Phoneword
{
    [Activity(Label = "AzureActivity")]
    public class AzureActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_azure);

            Button toMainButton = FindViewById<Button>(Resource.Id.ToMainButton);
            toMainButton.Click += (o, e) =>
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };

            Button toTranslationHistoryButton = FindViewById<Button>(Resource.Id.ToTranslationHistoryButton);
            toTranslationHistoryButton.Click += (o, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                StartActivity(intent);
            };
        }
    }
}