using System;

namespace BinarySearchTree
{
    class BinarySearchTree
    {
        private Node root;

        public Node Insert(int value)
        {
            Node node = new Node(value);

            if (root == null)
            {
                root = node;
                return root;
            }
            else
            {
                return InsertNode(root, node);
            }
        }

        private Node InsertNode(Node current, Node node)
        {
            if(node.Value < current.Value)
            {
                if(current.Left == null)
                {
                    current.Left = node;
                    return node;
                }
                else
                {
                    return InsertNode(current.Left, node);
                }
            }
            else if (node.Value > current.Value)
            {
                if(current.Right == null)
                {
                    current.Right = node;
                    return node;
                }
                else
                {
                    return InsertNode(current.Right, node);
                }
            }

            return null;
        }
    }
}
