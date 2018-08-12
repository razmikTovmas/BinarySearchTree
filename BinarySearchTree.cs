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

        public bool Contains(int value)
        {
            return ContainsRecursive(root, value);
        }

        private bool ContainsRecursive(Node node, int value)
        {
            if (node == null) return false;

            if (node.Value == value) return true;

            if (value < node.Value)
            {
                return ContainsRecursive(node.Left, value);
            }
            else
            {
                return ContainsRecursive(node.Right, value);
            }
        }
    }
}
