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
using Android.Webkit;


namespace BookingCore
{
    class ActWebView : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            base.ShouldOverrideUrlLoading(view, url);
            view.LoadUrl(url);
            return true;
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            MainActivity.SetVisibility(ViewStates.Gone);
        }
    }
}