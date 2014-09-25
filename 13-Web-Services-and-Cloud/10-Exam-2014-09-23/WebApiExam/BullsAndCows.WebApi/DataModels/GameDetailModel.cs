namespace BullsAndCows.WebApi.DataModels
{
    using BullsAndCows.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class GameDetailModel
    {
        public GameDetailModel()
        {
            this.OpponentGuesses = new HashSet<GuessModel>();
            this.YourGuesses = new HashSet<GuessModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public ICollection<GuessModel> YourGuesses { get; set; }

        public ICollection<GuessModel> OpponentGuesses { get; set; }

        public string YourColor { get; set; }

        public string GameState { get; set; }
    }
}