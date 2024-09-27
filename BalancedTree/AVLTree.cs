namespace BalancedTree;

public class AVLTree
{
    // Get the height of the node
    private static int GetHeight(TreeNode? node)
    {
        return node == null ? 0 : node.Height;
    }

    // Get the balance factor of the node
    private static int GetBalance(TreeNode? node)
    {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }

    // Perform a right rotation
    private static TreeNode? RightRotate(TreeNode y)
    {
        TreeNode? x = y.Left;
        TreeNode? T2 = x?.Right;

        // Perform rotation

        if (x is not null)
            x.Right = y;
        y.Left = T2;

        // Update heights
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        if (x is not null)
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        // Return new root
        return x;
    }

    // Perform a left rotation
    private static TreeNode? LeftRotate(TreeNode x)
    {
        TreeNode? y = x.Right;
        TreeNode? T2 = y?.Left;

        // Perform rotation
        if (y is not null)
            y.Left = x;
        x.Right = T2;

        // Update heights
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        if (y is not null)
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        // Return new root
        return y;
    }

    // Insert a node in the AVL tree
    public static TreeNode? Insert(TreeNode? node, int key)
    {
        // Step 1: Perform normal BST insertion
        if (node == null)
            return new TreeNode(key);

        if (key < node.Key)
            node.Left = Insert(node.Left, key);
        else if (key > node.Key)
            node.Right = Insert(node.Right, key);
        else
            return node; // No duplicates allowed

        // Step 2: Update height of this ancestor node
        node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

        // Step 3: Get the balance factor to check if this node became unbalanced
        int balance = GetBalance(node);

        // Step 4: If the node is unbalanced, perform rotations

        // Left Left Case
        if (balance > 1 && key < node?.Left?.Key)
            return RightRotate(node);

        // Right Right Case
        if (balance < -1 && key > node?.Right?.Key)
            return LeftRotate(node);

        // Left Right Case
        if (balance > 1 && key > node?.Left?.Key)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Right Left Case
        if (balance < -1 && key < node?.Right?.Key)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        // Return the (unchanged) node pointer
        return node;
    }

    // Inorder traversal of the AVL tree
    public void InOrder(TreeNode? root)
    {
        if (root == null)
        {
            return;
        }

        InOrder(root.Left);
        Console.WriteLine(root.Key + " ");
        InOrder(root.Right);
    }

    public static void PrintTree(TreeNode? root, string indent = "", bool isLeft = true)
    {
        if (root == null)
        {
            return;
        }

        // Print the right subtree
        PrintTree(root.Right, indent + (isLeft ? "│   " : "    "), false);

        // Print the current node
        Console.WriteLine(indent + (isLeft ? "└── " : "┌── ") + root.Key);

        // Print the left subtree
        PrintTree(root.Left, indent + (isLeft ? "    " : "│   "), true);
    }
}
