namespace COMP004.FinalProject.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public int PublisherId { get; set; }

        public virtual Publisher? Publisher { get; set; }

    }
}
