using System.Collections.Generic;

namespace P09.CollectionHierarchy
{
    public abstract class Collection : IAddable
    {
        public Collection()
        {
            this.Words = new List<string>();
        }

        public virtual int Indexer => this.Words.Count - 1;

        internal List<string> Words { get; set; }
        public abstract int Add(string word);
    }
}
