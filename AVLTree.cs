namespace BinarySearchTree
{
    class AVLTree
    {
        private AVLNode root;

        public void Insert(int value) { root = InsertHelper(root, value); }

        private AVLNode InsertHelper(AVLNode node, int value)
        {
            // Binary Search Tree insertion
            if (node == null) return new AVLNode(value);

            if(value < node.Value)
            {
                node.Left = InsertHelper(node.Left, value);
            }
            else if(value > node.Value)
            {
                node.Right = InsertHelper(node.Right, value);
            }
            else
            // Duplicate value
            {
                return node;
            }

            // Update height of this node
            node.Height = 1 + Max(Height(node.Left), Height(node.Right));

            // Get the balance of this node
            int balance = Balance(node);

            if (balance > 1 && value < node.Left.Value)
            //Left Left Case
            {
                return RightRotation(node);
            }
            else if (balance < -1 && value > node.Right.Value)
            // Right Right Case
            {
                return LeftRotation(node);
            }
            else if(balance > 1 && value > node.Left.Value)
            // Left Right Case
            {
                node.Left = LeftRotation(node.Left);
                return RightRotation(node);
            }
            else if(balance < -1 && value < node.Right.Value)
            // Right Left Case
            {
                node.Right = RightRotation(node.Right);
                return LeftRotation(node);
            }
            else
            // If subtree is balanced return this node
            {
                return node;
            }
        }

        private int Max(int a, int b) { return (a > b) ? a : b; }
        private int Height(AVLNode node) { return (node != null) ? node.Height : 0; }
        private int Balance(AVLNode node) { return (node != null) ? Height(node.Left) - Height(node.Right) : 0; }

        private AVLNode LeftRotation(AVLNode yNode)
        //    y                            x
        //   / \      Left Rotation       / \
        //  T1  x    - – – – – – – >     y  T3
        //     / \                      / \
        //    T2  T3                   T1  T2
        {
            AVLNode xNode = yNode.Right;

            yNode.Right = xNode.Left;
            xNode.Left = yNode;

            xNode.Height++;
            yNode.Height--;

            return xNode;
        }

        private AVLNode RightRotation(AVLNode yNode)
        //      y                          x
        //     / \     Right Rotation     / \
        //    x   T3   – – – – – – – >   T1  y
        //   / \                            / \
        //  T1  T2                         T2  T3
        {
            AVLNode xNode = yNode.Left;

            yNode.Left = xNode.Right;
            xNode.Right = yNode;

            xNode.Height++;
            yNode.Height--;

            return xNode;
        }
    }
}