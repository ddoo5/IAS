using System;
using System.Diagnostics.Metrics;

namespace IAS.Services
{
	public class IndexedSearcher
	{
        private readonly Dictionary<string, HashSet<int>> _index = new Dictionary<string, HashSet<int>>();
        private readonly List<string> _content = new List<string>();
        private readonly Selector _lexer = new();
        private readonly Searcher _searcher = new();



        public void AddStringToIndex(string text)
        {
            int documentId = _content.Count;

            foreach (var token in _lexer.GetTokens(text))
            {
                if (_index.TryGetValue(token, out var set))
                    set.Add(documentId);

                else

                    _index.Add(token, new HashSet<int>() { documentId });
            }

            _content.Add(text);
        }


        public IEnumerable<int> Search(string word)
        {
            word = word.ToLowerInvariant();

            if (_index.TryGetValue(word, out var set))
                return set;

            return Enumerable.Empty<int>();
        }
    }
}

