namespace tower_defense
{
    class Player
    {
        public string pseudo { get; set; }
        public int score { get; set; }
        public Player()
        {
            this.pseudo = "No Pseudo";
            this.score = 0;
        }

        public Player(string pseudo, int score)
        {
            this.pseudo = pseudo;
            this.score = score;
        }
        public Player(int score)
        {
            this.pseudo = "No Pseudo";
            this.score = score;
        }
    }
}
