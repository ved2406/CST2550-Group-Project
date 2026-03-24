namespace PestControlWebApp.Models
{
    public class BST
    {
        private BSTNode? root;

        public BST() { root = null; }

        public void Insert(PestRecord record)
        {
            root = InsertNode(root, record);
        }

        private BSTNode InsertNode(BSTNode? node, PestRecord record)
        {
            if (node == null) return new BSTNode(record);
            if (record.Id < node.Data.Id)
                node.Left = InsertNode(node.Left, record);
            else if (record.Id > node.Data.Id)
                node.Right = InsertNode(node.Right, record);
            return node;
        }

        public PestRecord? Search(int id)
        {
            return SearchNode(root, id);
        }

        private PestRecord? SearchNode(BSTNode? node, int id)
        {
            if (node == null) return null;
            if (id == node.Data.Id) return node.Data;
            else if (id < node.Data.Id) return SearchNode(node.Left, id);
            else return SearchNode(node.Right, id);
        }

        public void Delete(int id)
        {
            root = DeleteNode(root, id);
        }

        private BSTNode? DeleteNode(BSTNode? node, int id)
        {
            if (node == null) return null;
            if (id < node.Data.Id)
                node.Left = DeleteNode(node.Left, id);
            else if (id > node.Data.Id)
                node.Right = DeleteNode(node.Right, id);
            else
            {
                if (node.Left == null && node.Right == null) return null;
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;
                BSTNode minNode = FindMin(node.Right);
                node.Data = minNode.Data;
                node.Right = DeleteNode(node.Right, minNode.Data.Id);
            }
            return node;
        }

        private BSTNode FindMin(BSTNode node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }

        public List<PestRecord> GetAll()
        {
            List<PestRecord> records = new List<PestRecord>();
            InOrder(root, records);
            return records;
        }

        private void InOrder(BSTNode? node, List<PestRecord> records)
        {
            if (node == null) return;
            InOrder(node.Left, records);
            records.Add(node.Data);
            InOrder(node.Right, records);
        }
    }
}
