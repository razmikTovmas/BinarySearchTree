namespace BinarySearchTree
{
    class AVLNode
    {
        private int value;
        private int height;
        private AVLNode left;
        private AVLNode right;

        public AVLNode(int value)
        {
            Value = value;
            Height = 1;
        }

        public int Value { get => value; set => this.value = value; }
        public int Height { get => height; set => height = value; }
        public AVLNode Left { get => left; set => left = value; }
        public AVLNode Right { get => right; set => right = value; }
    }
}