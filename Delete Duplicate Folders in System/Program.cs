namespace Delete_Duplicate_Folders_in_System
{
    class TrieNode
    {
        public Dictionary<string, TrieNode> Children = new();
        public bool Deleted = false;
    }

    class Solution
    {
        public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths)
        {
            var root = new TrieNode();
            var subtreeMap = new Dictionary<string, List<TrieNode>>();

            // Build Trie
            foreach (var path in paths)
            {
                var node = root;
                foreach (var folder in path)
                {
                    if (!node.Children.ContainsKey(folder))
                        node.Children[folder] = new TrieNode();
                    node = node.Children[folder];
                }
            }

            // Serialize subtrees
            string Serialize(TrieNode node)
            {
                var serial = new List<string>();
                foreach (var kvp in node.Children.OrderBy(k => k.Key))
                {
                    serial.Add(kvp.Key + Serialize(kvp.Value));
                }
                var result = "(" + string.Join("", serial) + ")";
                if (result != "()")
                {
                    if (!subtreeMap.ContainsKey(result))
                        subtreeMap[result] = new List<TrieNode>();
                    subtreeMap[result].Add(node);
                }
                return result;
            }

            Serialize(root);

            // Mark duplicates
            foreach (var nodes in subtreeMap.Values)
            {
                if (nodes.Count > 1)
                {
                    foreach (var node in nodes)
                        node.Deleted = true;
                }
            }

            // Collect remaining paths
            var output = new List<IList<string>>();
            void Collect(TrieNode node, List<string> path)
            {
                foreach (var kvp in node.Children)
                {
                    if (!kvp.Value.Deleted)
                    {
                        path.Add(kvp.Key);
                        output.Add(new List<string>(path));
                        Collect(kvp.Value, path);
                        path.RemoveAt(path.Count - 1);
                    }
                }
            }

            Collect(root, new List<string>());
            return output;
        }
    }
}
