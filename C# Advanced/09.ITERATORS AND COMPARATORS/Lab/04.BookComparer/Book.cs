namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Book : IComparable<Book>
    {
        private BookComparator bookComparator;
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
            bookComparator = new BookComparator();
        }
        public string Title { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyList<string> Authors { get; private set; }

        public int CompareTo(Book other)
        {
            return this.bookComparator.Compare(this, other);
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
