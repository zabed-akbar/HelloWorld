using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.TreeGraphs;

namespace CSharpUnitTests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        [Owner("Zabed Akbar")]
        [TestCategory("Developer")]
        public void TestCommonAncestorShouldReturnExpectedValue()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Add(20);
            bst.Add(8);
            bst.Add(22);
            bst.Add(4);
            bst.Add(12);
            bst.Add(10);
            bst.Add(14);

            BinaryTreeNode<int> commonAncestorNode = bst.FindLowestCommonAncestor(bst.Root, 4, 14);
            Assert.AreEqual(commonAncestorNode.Value, 8, "Error: Actual ancstor is different than the expected one");
        }
    }
}
