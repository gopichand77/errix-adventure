using System;
using UnityEngine;
using System.Collections;
// #if UNITY_IOS
// using Unity.Notifications.iOS;
// #elif UNITY_ANDROID
using Assets.SimpleAndroidNotifications;
// #endif
public class Local_noti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
   
    }
    // Update is called once per frame
    void Update()
    {

    }
    // public void Click()
    // {
    //          #if UNITY_ANDROID
    //     var channel = new AndroidNotificationChannel()
    //     {
    //         Id = "channel_id",
    //         Name = "Default Channel",
    //         Importance = Importance.Default,
    //         Description = "Generic notifications",
    //     };
    //     AndroidNotificationCenter.RegisterNotificationChannel(channel);

    //     // AndroidNotification notification = new AndroidNotification();
    //     // {
    //         var notification = new AndroidNotification();
    //         notification.Title = "Your Title";
    //         notification.Text = "Your Text";
    //         notification.FireTime = System.DateTime.Now.AddMinutes(1);
    //     // };
    //     AndroidNotificationCenter.SendNotification(notification, "channel_id");
    //     #endif
    // }
     public void ScheduleCustom()
        {
            var notificationParams = new NotificationParams
            {
                Id = UnityEngine.Random.Range(0, int.MaxValue),
                Delay = TimeSpan.FromSeconds(5),
                Title = "Custom notification",
                Message = "Message",
                Ticker = "Ticker",
                Sound = true,
                Vibrate = true,
                Light = true,
                SmallIcon = NotificationIcon.Heart,
                SmallIconColor = new Color(0, 0.5f, 0),
                LargeIcon = "app_icon"
            };

            NotificationManager.SendCustom(notificationParams);
        }

    
}