namespace WordCountInText
{
    class TrieNode
    {
        private readonly char startSymbol;

        private int words;
        private int prefixes;
        private TrieNode[] edges;       

        public TrieNode(char startSymbol)
        {
            this.edges = new TrieNode[32]; // а-я + э + ы
            this.Words = 0;
            this.Prefixes = 0;
            this.startSymbol = startSymbol;
        }

        public int Words
        {
            get
            {
                return this.words;
            }
            set
            {
                this.words = value;
            }
        }

        public int Prefixes
        {
            get
            {
                return this.prefixes;
            }
            set
            {
                this.prefixes = value;
            }
        }

        public TrieNode AddWord(TrieNode node, string word)
        {
            return this.AddWord(node, word, 0);
        }

        public void AddOccuranceIfExists(TrieNode node, string word)
        {
            AddOccuranceIfExists(node, word, 0);
        }

        public int CountWords(TrieNode node, string word)
        {
            return this.CountWords(node, word, 0);
        }

        public int CountPrefix(TrieNode node, string word)
        {
            return this.CountPrefix(node, word, 0);
        }


        private void AddOccuranceIfExists(TrieNode node, string word, int indexInWord)
        {
            if (word.Length == indexInWord)
            {
                node.Words += 1;
            }
            else
            {
                int nextCharIndex = word[indexInWord] - this.startSymbol;
                indexInWord++;
                node.Prefixes += 1;

                if (node.edges[nextCharIndex] == null)
                {
                    return;
                }
                else
                {
                    AddOccuranceIfExists(node.edges[nextCharIndex], word, indexInWord);
                }
            }
        }

        private TrieNode AddWord(TrieNode node, string word, int indexInWord)
        {
            if (word.Length != indexInWord)
            {
                node.Prefixes += 1;

                int index = word[indexInWord] - this.startSymbol;
                indexInWord++;

                if (node.edges[index] == null)
                {
                    node.edges[index] = new TrieNode(this.startSymbol);
                }

                node.edges[index] = AddWord(node.edges[index], word, indexInWord);
            }

            return node;
        }

        private int CountWords(TrieNode node, string word, int indexInWord)
        {
            if (word.Length == indexInWord)
            {
                return node.words;
            }
            else
            {
                int nextCharIndex = word[indexInWord] - this.startSymbol;
                indexInWord++;
                if (node.edges[nextCharIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return CountWords(node.edges[nextCharIndex], word, indexInWord);
                }
            }
        }

        private int CountPrefix(TrieNode node, string word, int indexInWord)
        {
            if (word.Length == indexInWord)
            {
                return node.prefixes;
            }
            else
            {
                int nextCharIndex = word[indexInWord] - this.startSymbol;
                indexInWord++;
                if (node.edges[nextCharIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return CountPrefix(node.edges[nextCharIndex], word, indexInWord);
                }
            }
        }
    }
}
