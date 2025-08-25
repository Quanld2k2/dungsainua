using Unity.Notifications.Android;
using UnityEngine;

public class NotificationExample : MonoBehaviour
{
    void Start()
    {
        // Tạo kênh thông báo (chỉ cần tạo 1 lần khi mở app)
        var channel = new AndroidNotificationChannel()
        {
            Id = "game_channel",
            Name = "Game Notifications",
            Importance = Importance.Default,
            Description = "Thông báo từ game",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        // Tạo thông báo
        var notification = new AndroidNotification();
        notification.Title = "Quay lại chơi game nào!";
        notification.Text = "Có phần thưởng đang chờ bạn 🎁";
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";
        notification.FireTime = System.DateTime.Now.AddSeconds(10); // hiện sau 10 giây

        // Gửi thông báo
        AndroidNotificationCenter.SendNotification(notification, "game_channel");
    }
}
