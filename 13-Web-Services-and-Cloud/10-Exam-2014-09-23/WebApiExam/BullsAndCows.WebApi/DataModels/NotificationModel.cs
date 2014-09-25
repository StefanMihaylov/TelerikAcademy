using BullsAndCows.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.WebApi.DataModels
{
    public class NotificationModel
    {
        public static Expression<Func<Notification, NotificationModel>> FromDb
        {
            get
            {
                return n => new NotificationModel()
                {
                    Id = n.Id,
                    Message = n.Message,
                    DateCreated = n.DateCreated,
                    Type = n.Type.ToString(),
                    State = n.State.ToString(),
                    GameId = n.GameId
                };
            }
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }
    }
}