using System.ComponentModel.DataAnnotations;

namespace COMP004.FinalProject.Models

{
    public class Rating
    {
        public int RatingId { get; set; }
        public string GameName { get; set;}
        [Range(0, 100)]
        public int RatingNum { get; set; }

        public virtual Game? Game { get; set; }
    }
}
