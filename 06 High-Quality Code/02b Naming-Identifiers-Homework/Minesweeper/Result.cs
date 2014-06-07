namespace MinesweeperGame
{
    public class Result
    {
        private string name;
        private int score;

        public Result()
        {
        }

        public Result(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }
    }
}
