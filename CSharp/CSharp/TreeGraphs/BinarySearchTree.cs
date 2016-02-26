using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.TreeGraphs
{
    /// <summary>
    /// Implements Generic Binary Search Tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> : BinaryTree<T>
    {
        public BinarySearchTree() : base() { }

        /// <summary>
        /// Add new node to BST
        /// </summary>
        /// <param name="data"></param>
        public virtual void Add(T data)
        {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(data);
            BinaryTreeNode<T> current = this.Root;
            BinaryTreeNode<T> parent = null;
            int comparisonResult;

            while (current != null)
            {
                comparisonResult = Comparer.DefaultInvariant.Compare(current.Value, data);

                if (comparisonResult == 0)
                {
                    return;
                }
                else if (comparisonResult > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (comparisonResult < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }

            if (parent == null)
            {
                this.Root = newNode;
            }
            else
            {
                comparisonResult = Comparer.DefaultInvariant.Compare(parent.Value, data);
                if (comparisonResult > 0)
                {
                    parent.Left = newNode;
                }
                else
                {
                    parent.Right = newNode;
                }
            }

        }

        /// <summary>
        /// Given two nodes in a binary search tree, finds their lowest common ancestor
        /// </summary>
        /// <param name="root"></param>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public virtual BinaryTreeNode<T> FindLowestCommonAncestor(BinaryTreeNode<T> root, BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
        {
            if (this.Root == null || node1 == null || node2 == null)
            {
                return null;
            }
            return FindLowestCommonAncestor(root, node1.Value, node2.Value);
        }

        /// <summary>
        /// Given the value of two nodes in a binary search tree, finds the lowest common ancestor
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="node1Value"> Node 1 value</param>
        /// <param name="node2Value">Node 2 value</param>
        /// <returns></returns>
        public virtual BinaryTreeNode<T> FindLowestCommonAncestor(BinaryTreeNode<T> root, T node1Value, T node2Value)
        {
            while (root != null)
            {
                T value = root.Value;
                if (Comparer.DefaultInvariant.Compare(value, node1Value) > 0 && Comparer.DefaultInvariant.Compare(value, node2Value) > 0)
                {
                    root = root.Left;
                }
                else if (Comparer.DefaultInvariant.Compare(value, node1Value) < 0 && Comparer.DefaultInvariant.Compare(value, node2Value) < 0)
                {
                    root = root.Right;
                }
                else
                {
                    return root;
                }
            }
            return null;
        }
    }
}
