﻿using System;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            if (this.left.CompareTo(this.right) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
