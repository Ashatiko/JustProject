namespace JustProject.Models.Tests
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Choices { get; set; }
        public int CorrectChoiceIndex { get; set; }
        public string NumberQuestion { get; set; }
        public List<string> IdQuestion { get; set; }
    }
}
