﻿using System;
using System.Linq;

namespace CreateLinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {    
            public int Value { get; set; }

            public ListNode NextNode { get; set; }

            public ListNode PrevNode { get; set; }

            public ListNode(int value)
            {
                this.Value = value;
            }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PrevNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PrevNode = this.tail;
                this.tail.PrevNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is Empty !!!");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PrevNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;

            return firstElement;
        }

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is Empty !!!");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.PrevNode;

            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;

            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            int counter = 0;
            var currentNode = this.head;

            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }

            return array;
        }
    }
}
