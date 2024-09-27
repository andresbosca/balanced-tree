using BalancedTree;

AVLTree tree = new();
TreeNode? root = null;

Console.Write("Input: [");
foreach (int data in MockData.EntryData)
{
    Console.Write(data + ",");
    root = AVLTree.Insert(root, data);
}
Console.Write("]");
Console.WriteLine("");

Console.WriteLine("");
Console.WriteLine("In-order traversal of the constructed AVL tree is:");
tree.InOrder(root);

Console.WriteLine("");
Console.WriteLine("");

Console.WriteLine("Tree structure:");
AVLTree.PrintTree(root);
