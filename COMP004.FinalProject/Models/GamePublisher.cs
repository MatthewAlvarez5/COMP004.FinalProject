using COMP004.FinalProject.Models;



namespace COMP004.FinalProject.Models
{
    public class GamePublisher
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }

        public virtual Game? Game { get; set; }
        public virtual Developer? Developer { get; set; }
        public virtual Publisher? Publisher { get; set; }
    }
}
