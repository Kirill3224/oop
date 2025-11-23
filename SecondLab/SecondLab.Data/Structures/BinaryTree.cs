using System.Collections;

namespace SecondLab.Data.Sturctures;

public class BinaryTree<T> : IEnumerable<T> where T : class
{
    private TreeNode _root;
    private IComparer<T> _comparer;

    private class TreeNode
    {
        public T Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public BinaryTree() : this(Comparer<T>.Default) { }

    public BinaryTree(IComparer<T> comparer)
    {
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public void Add(T data)
    {
        _root = AddRecursive(_root, data);
    }

    private TreeNode AddRecursive(TreeNode current, T data)
    {
        if (current == null)
        {
            return new TreeNode(data);
        }

        int comparison = _comparer.Compare(data, current.Data);

        if (comparison < 0)
        {
            current.Left = AddRecursive(current.Left, data);
        }
        else if (comparison > 0)
        {
            current.Right = AddRecursive(current.Right, data);
        }

        return current;
    }

    public bool Contains(T data)
    {
        return FindRecursive(_root, data) != null;
    }

    private TreeNode FindRecursive(TreeNode current, T data)
    {
        if (current == null) return null;

        int comparison = _comparer.Compare(data, current.Data);

        if (comparison == 0) return current;
        if (comparison < 0) return FindRecursive(current.Left, data);
        return FindRecursive(current.Right, data);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new BinaryTreeEnumerator(_root);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class BinaryTreeEnumerator : IEnumerator<T>
    {
        private List<T> _items;
        private int _position = -1;

        public BinaryTreeEnumerator(TreeNode root)
        {
            _items = new List<T>();
            BuildPostorderList(root);
        }

        private void BuildPostorderList(TreeNode node)
        {
            if (node == null) return;

            BuildPostorderList(node.Left);
            BuildPostorderList(node.Right);
            _items.Add(node.Data);
        }

        public T Current => _position >= 0 && _position < _items.Count ? _items[_position] : default(T);
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _position++;
            return _position < _items.Count;
        }

        public void Reset() => _position = -1;
        public void Dispose() { }
    }

    public List<T> ToSortedList()
    {
        var list = new List<T>();
        InOrderTraversal(_root, list);
        return list;
    }

    private void InOrderTraversal(TreeNode node, List<T> result)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, result);
            result.Add(node.Data);
            InOrderTraversal(node.Right, result);
        }
    }

    public bool IsEmpty => _root == null;
    public int Count => this.Count();
}