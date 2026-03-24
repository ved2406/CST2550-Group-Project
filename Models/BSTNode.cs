namespace PestControlWebApp.Models
{
    public class BSTNode
    {
        public PestRecord Data { get; set; } = new PestRecord();
        public BSTNode? Left { get; set; }
        public BSTNode? Right { get; set; }

        public BSTNode(PestRecord record)
        {
            Data = record;
            Left = null;
            Right = null;
        }
    }
}
