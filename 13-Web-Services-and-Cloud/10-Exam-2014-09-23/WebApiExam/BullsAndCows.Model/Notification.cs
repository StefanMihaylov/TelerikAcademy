namespace BullsAndCows.Model
{
    using System;

    public class Notification
    {
        public const string YourTurnMessage = "It is your turn in game \"{0}\"";
        public const string GameWon = "You beat {1} in game \"{0}\"";
        public const string GameLost = "{1} beat you in game \"{0}\"";
        public const string GameJoined = "{1} joined your game \"{0}\"";

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public NotificationType Type { get; set; }

        public NotificationState State { get; set; }

        public int GameId { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
