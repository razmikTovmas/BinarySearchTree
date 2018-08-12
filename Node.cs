namespace BinarySearchTree
{
    class Node
    {
        private int value;
        private Node left;
        private Node right;

        public Node(int value)
        {
            Value = value;
        }

        public int Value { get => value; set => this.value = value; }
        public Node Left { get => left; set => left = value; }
        public Node Right { get => right; set => right = value; }
    }
}
