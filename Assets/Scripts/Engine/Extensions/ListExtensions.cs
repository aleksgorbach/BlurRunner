// Created 02.11.2015 
// Modified by Gorbach Alex 02.11.2015 at 12:42

namespace Assets.Scripts.Engine.Extensions {
    #region References

    using System.Collections.Generic;

    #endregion

    public static class ListExtensions {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> item) {
            return item.Next ?? item.List.First;
        }

        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> item) {
            return item.Previous ?? item.List.Last;
        }
    }
}