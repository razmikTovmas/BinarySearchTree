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

        public bool Remove(int value)
        {
            Node nodeToRemove = FindNode(root, value);

            if (nodeToRemove == null) return false;

            if (nodeToRemove.Left != null && nodeToRemove.Right != null)
            // Case 4: The value to remove has both a left and right subtree
            {
                Node max = FindMax(nodeToRemove.Left);

                int temp = nodeToRemove.Value;
                nodeToRemove.Value = max.Value;
                max.Value = temp;

                nodeToRemove = max;
            }

            RemoveHelper(nodeToRemove);
            return true;
        }

        private void RemoveHelper(Node node)
        {
            Node parent = FindParent(root, node.Value);

            if(node.Left == null && node.Right == null)
            //  Case 1: The value to remove is a leaf node
            {
                if (node == root)
                {
                    root = null;
                }
                else
                {
                    if (parent.Left == node)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
            }
            else if(node.Right != null)
            // Case 2: The value to remove has a right subtree, but no left subtree
            {
                if (node == root)
                {
                    root = node.Right;
                }
                else
                {
                    if(parent.Left == node)
                    {
                        parent.Left = node.Right;
                    }
                    else
                    {
                        parent.Right = node.Right;
                    }
                }
            }
            else if(node.Left != null)
            // Case 3: The value to remove has a left subtree, but no right subtree
            {
                if (node == root)
                {
                    root = node.Left;
                }
                else
                {
                    if(parent.Left == node)
                    {
                        parent.Left = node.Left;
                    }
                    else
                    {
                        parent.Right = node.Left;
                    }
                }
            }
        }

        private Node FindParent(Node node, int value)
        {
            if (value == node.Value) return null;

            if(value < node.Value)
            {
                if(node.Left == null)
                {
                    return null;
                }
                else if(node.Left.Value == value)
                {
                    return node;
                }
                else
                {
                    return FindParent(node.Left, value);
                }
            }
            else
            {
                if(node.Right == null)
                {
                    return null;
                }
                else if(node.Right.Value == value)
                {
                    return node;
                }
                else
                {
                    return FindParent(node.Right, value);
                }
            }
        }

        private Node FindNode(Node node,int value)
        {
            if (node == null) return null;

            if (node.Value == value) return node;

            if(value < node.Value)
            {
                return FindNode(node.Left, value);
            }
            else
            {
                return FindNode(node.Right, value);
            }
        }

        private Node FindMin(Node node)
        {
            if (node.Left == null)
            {
                return node;
            }
            else
            {
                return FindMin(node.Left);
            }
        }

        private Node FindMax(Node node)
        {
            if(node.Right == null)
            {
                return node;
            }
            else
            {
                return FindMax(node.Right);
            }
        }
    }
}
