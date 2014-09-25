namespace BullsAndCows.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        private ICollection<Guess> redPlayerGuesses;
        private ICollection<Guess> bluePlayerGuesses;

        public Game()
        {
            this.redPlayerGuesses = new HashSet<Guess>();
            this.bluePlayerGuesses = new HashSet<Guess>();
        }

        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RedPlayerId { get; set; }

        public virtual User RedPlayer { get; set; }

        public string BluePlayerId { get; set; }

        public virtual User BluePlayer { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int RedPlayerNumber { get; set; }

        public int? BluePlayerNumber { get; set; }

        public Status GameStatus { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Guess> RedPlayerGuesses
        {
            get
            {
                return this.redPlayerGuesses;
            }

            set
            {
                this.redPlayerGuesses = value;
            }
        }

        public virtual ICollection<Guess> BluePlayerGuesses
        {
            get
            {
                return this.bluePlayerGuesses;
            }

            set
            {
                this.bluePlayerGuesses = value;
            }
        }
    }
}
