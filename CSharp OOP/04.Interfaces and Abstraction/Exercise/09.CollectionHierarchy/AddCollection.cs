using System.Collections.Generic;

namespace P09.CollectionHierarchy
{
    public class AddCollection : Collection
    {
        public override int Add(string word)
        {
            this.Words.Add(word);

            return this.Indexer;
        }
    }
}
