namespace P09.CollectionHierarchy
{
    public class MyList : AddRemoveCollection, IList
    {
        public int Used => this.Words.Count;
        public override string Remove()
        {
            string firstElement = null;

            if (this.Words.Count > 0)
            {
                firstElement = this.Words[0];
                this.Words.RemoveAt(0);
            }

            return firstElement;
        }
    }
}
