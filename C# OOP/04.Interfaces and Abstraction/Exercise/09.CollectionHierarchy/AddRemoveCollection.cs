using System.Linq;

namespace P09.CollectionHierarchy
{
    public class AddRemoveCollection : Collection, IRemovable
    {
        public override int Add(string word)
        {
            this.Words.Insert(0, word);
            return 0;
        }

        public virtual string Remove()
        {
            string lastElement = null;

            if (this.Words.Count > 0)
            {
                lastElement = this.Words.Last();
                this.Words.RemoveAt(this.Words.Count - 1);
            }

            return lastElement;
        }
    }
}
