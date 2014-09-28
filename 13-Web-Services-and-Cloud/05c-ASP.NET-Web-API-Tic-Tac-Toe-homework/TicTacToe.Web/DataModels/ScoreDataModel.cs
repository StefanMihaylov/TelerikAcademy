namespace TicTacToe.Web.DataModels
{
    public class ScoreDataModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int Wins { get; set; }

        public int Draws { get; set; }

        public int Losses { get; set; }

        public long Rank { get; set; }
    }
}