using System;
using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;

/*
 * Payload
 * {"data":{}, "notification" : {"body" : "This is a Azure msg","title" : "Azure Message"}}
 * in th "data" key would have only one of "jobid" or "jobapplicantid" keys.
 */

namespace Pt_Hippo_Mobile.Droid.pushnotfications
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]

    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "Messagereceived");

            if (string.IsNullOrEmpty(Pt_Hippo_Mobile.Helpers.Settings.Username))
                return;

            Log.Debug(TAG, "Message received");
            var msg = message.GetNotification();
            if (msg != null || message.Data.Keys.Count > 0)
            {
                try
                {
                    var msgdata = message.Data;
                    string body, title, jobId, jobapplicantid;
                    body = "Empty notification";

                    if (msg?.Body != null)
                        body = msg.Body;
                    else
                        msgdata.TryGetValue("body", out body);
                    if (msg?.Title != null)
                        title = msg.Title;
                    else
                        msgdata.TryGetValue("title", out title);
                    msgdata.TryGetValue("jobid", out jobId);
                    msgdata.TryGetValue("jobapplicantid", out jobapplicantid);
                    SendNotification(title, body, jobId, jobapplicantid);
                }
                catch (Exception ex)
                {
                    var logged = new LoggedException.LoggedException("Error in firebase", ex);
                    logged.LoggAPI();
                    SendNotification("Unknown sender", "unreadable message", null, null);
                }
            }
            else
            {
                SendNotification("Unknown sender", "unreadable message", null, null);
            }
            //Log.Debug(TAG, "Notification Message Body: " + body);

        }

        void SendNotification(string messageBody, string messageTitle, string jobid, string jobapplicantid)
        {
            var intent = new Intent(this, typeof(MainActivity));
            //intent.AddFlags(ActivityFlags.NewTask | ActivityFlags.SingleTop | ActivityFlags.ClearTop);

            if (jobid != null)
                intent.PutExtra("jobid", jobid);
            if (jobapplicantid != null)
                intent.PutExtra("jobapplicantid", jobapplicantid);

            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.UpdateCurrent);

            var notificationBuilder = new Notification.Builder(this)
                .SetSmallIcon(Resource.Drawable.ic_launcher)
                .SetContentTitle(messageTitle)
                .SetContentText(messageBody)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(this);
            notificationManager.Notify(0, notificationBuilder.Build());
        }
    }
}