namespace BalancedTree;

public class TreeNode
{
    public int Key;
    public TreeNode? Left;
    public TreeNode? Right;
    public int Height;

    public TreeNode(int key)
    {
        Key = key;
        Height = 1; // Initial height of a new node is 1
    }
}
