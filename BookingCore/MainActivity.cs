using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace BookingCore
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@mipmap/favicon")]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private WebView webView;
        private static ProgressBar progressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            webView = FindViewById<WebView>(Resource.Id.webView);
            progressBar = FindViewById<ProgressBar>(Resource.Id.prb_webview);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            webView.LoadUrl("http://hafashta.ir");
            webView.Settings.JavaScriptEnabled = true;
            webView.SetWebViewClient(new ActWebView());
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    progressBar.Visibility = ViewStates.Visible;
                    webView.LoadUrl("http://hafashta.ir");
                    webView.Settings.JavaScriptEnabled = true;
                    webView.SetWebViewClient(new ActWebView());
                    return true;
                case Resource.Id.navigation_dashboard:
                    progressBar.Visibility = ViewStates.Visible;
                    webView.LoadUrl("http://hafashta.ir/login");
                    webView.Settings.JavaScriptEnabled = true;
                    webView.SetWebViewClient(new ActWebView());
                    return true;
                case Resource.Id.navigation_notifications:
                    progressBar.Visibility = ViewStates.Visible;
                    webView.LoadUrl("http://hafashta.ir:2222");
                    webView.Settings.JavaScriptEnabled = true;
                    webView.SetWebViewClient(new ActWebView());
                    return true;
            }
            return false;
        }

        public override void OnBackPressed()
        {
            if (webView.CanGoBack())
                webView.GoBack();
            else
                base.OnBackPressed();
        }

        public static void SetVisibility(ViewStates viewStates)
        {
            progressBar.Visibility = viewStates;
        }
    }
}

