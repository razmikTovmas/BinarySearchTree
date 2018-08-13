using System;
using System.Collections.Generic;

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

            xNode.Height = Max(Height(xNode.Left), Height(xNode.Right)) + 1;
            yNode.Height = Max(Height(yNode.Left), Height(yNode.Right)) + 1;


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

            xNode.Height = Max(Height(xNode.Left), Height(xNode.Right)) + 1;
            yNode.Height = Max(Height(yNode.Left), Height(yNode.Right)) + 1;

            return xNode;
        }

        public void Remove(int value) { root = RemoveHelper(root, value); }

        private AVLNode RemoveHelper(AVLNode node, int value)
        {
            // Binary Search Tree deletion
            if (node == null) return node;
            if (value < node.Value)
            // Node is in left subtree
            {
                node.Left = RemoveHelper(node.Left, value);
            }
            else if (value > node.Value)
            // Node is in right subtree
            {
                node.Right = RemoveHelper(node.Right, value);
            }
            else
            // Here we are
            {
                if((node.Left == null) || (node.Right == null))
                // Node with one child
                {
                    AVLNode temp = null;
                    if (temp == node.Left) temp = node.Right;
                    else temp = node.Left;

                    if(temp == null)
                    {
                        temp = node;
                        node = null;
                    }
                    else
                    {
                        node = temp;
                    }
                }
                else
                // Node with two children
                {
                    AVLNode temp = FindMin(node.Right);
                    node.Value = temp.Value;

                    node.Right = RemoveHelper(node.Right, temp.Value);
                }
            }

            if (node == null) return node; // Tree had one node

            node.Height = 1 + Max(Height(node.Left), Height(node.Right));

            int balance = Balance(node);

            
            if (balance > 1 && Balance(node.Left) >= 0)
            // Left Left Case
            {
                return RightRotation(node);
            }
            else if (balance > 1 && Balance(node.Left) < 0)
            // Left Right Case
            {
                node.Left = LeftRotation(node.Left);
                return RightRotation(node);
            }
            else if (balance < -1 && Balance(node.Right) <= 0)
            // Right Right Case
            {
                return LeftRotation(node);
            }
            else if (balance < -1 && Balance(node.Right) > 0)
            // Right Left Case
            {
                node.Right = RightRotation(node.Right);
                return LeftRotation(node);
            }

            return node;
        }

        private AVLNode FindMin(AVLNode node)
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

        public void Preorder()
        {
            PreorderHelper(root);
        }

        private void PreorderHelper(AVLNode node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value);
                PreorderHelper(node.Left);
                PreorderHelper(node.Right);
            }
        }

        public void Postorder()
        {
            PostorderHelper(root);
        }

        private void PostorderHelper(AVLNode node)
        {
            if (node != null)
            {
                PostorderHelper(node.Left);
                PostorderHelper(node.Right);
                Console.WriteLine(node.Value);
            }
        }

        public void Inorder()
        {
            InorderHelper(root);
        }

        private void InorderHelper(AVLNode node)
        {
            if (node != null)
            {
                InorderHelper(node.Left);
                Console.WriteLine(node.Value);
                InorderHelper(node.Right);
            }
        }

        public void BreadthFirst()
        {
            AVLNode node = root;
            List<AVLNode> list = new List<AVLNode>();
            while (node != null)
            {
                Console.WriteLine(node.Value);
                if (node.Left != null)
                {
                    list.Add(node.Left);
                }
                if (node.Right != null)
                {
                    list.Add(node.Right);
                }

                if (list.Count > 0)
                {
                    node = list[0];
                    list.Remove(list[0]);
                }
                else
                {
                    node = null;
                }
            }
        }
    }
}