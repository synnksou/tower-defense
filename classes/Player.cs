namespace tower_defense
{
    class Player
    {
        public string pseudo { get; set; }
        public int score { get; set; }
        public int money { get; set; }

        public Player()
        {
            this.pseudo = "No Pseudo";
            this.money = 0;
            this.score = 0;
        }

        public Player(string pseudo)
        {
            this.pseudo = pseudo;
            this.score = 0;
            this.money = 0;
        }
    }
}
