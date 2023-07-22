using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JEstrellaS6.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[assembly: Xamarin.Forms.Dependency(typeof(Mensaje_Android))]

namespace JEstrellaS6.Droid
{
    public class Mensaje_Android : mensaje
    {
        public void LongAlert(string mensaje)
        {

            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();
        }

        public void ShorAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }

        public void ShortAlert(string message)
        {
            throw new NotImplementedException();
        }
    }
}