namespace BinarySearchTree
{
    class AVLTree
    {
        private AVLNode root;

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