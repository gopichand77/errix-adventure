using System;
using UnityEngine;


using System.Collections;
#if UNITY_IOS
using Unity.Notifications.iOS;
#elif UNITY_ANDROID
using Unity.Notifications.Android;
#endif
public class Local_noti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
var channel = new AndroidNotificationChannel()
{
    Id = "channel_id",
    Name = "Default Channel",
    Importance = Importance.Default,
    Description = "Generic notifications",
};
AndroidNotificationCenter.RegisterNotificationChannel(channel);

AndroidNotification notification =  new AndroidNotification();
{
  var notification1 = new AndroidNotification();
notification1.Title = "Your Title";
notification1.Text = "Your Text";
notification1.FireTime = System.DateTime.Now.AddMinutes(1);

  
};
AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}