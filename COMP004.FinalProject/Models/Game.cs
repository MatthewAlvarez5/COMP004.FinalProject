namespace COMP004.FinalProject.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }
        public int DeveloperId { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual Developer? Developer { get; set; }

    }
}
