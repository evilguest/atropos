using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Atropos
{
    public class TreeNode<T> : IEnumerable<T> where T : IComparable<T>
    {
        public readonly TreeNode<T> Left;

        public readonly TreeNode<T> Right;

        public readonly T Value;

        public readonly int Height;

        public TreeNode([NotNull] T value)
        {
            Value = value;
            Height = 1;
        }

        private TreeNode([NotNull] TreeNode<T> original, [NotNull] T value)
        {
            Left = original.Left;
            Right = original.Right;
            Height = original.Height;
            Value = value;
        }

        private TreeNode(TreeNode<T> left, TreeNode<T> right, [NotNull] T value)
        {
            Left = left;
            Right = right;
            Height = Math.Max(left.SafeHeight(), right.SafeHeight()) + 1;
            Value = value;
        }

        private TreeNode(
            TreeNode<T> leftLeft,
            TreeNode<T> leftRight,
            TreeNode<T> rightLeft,
            TreeNode<T> rightRight,
            [NotNull] T leftValue,
            [NotNull] T rightValue,
            [NotNull] T myValue)
        {
            Left = new TreeNode<T>(leftLeft, leftRight, leftValue);
            Right = new TreeNode<T>(rightLeft, rightRight, rightValue);
            Height = Math.Max(Left.Height, Right.Height) + 1;
            Value = myValue;
        }

        [Pure]
        private TreeNode<T> RotateRight()
        {
            Debug.Assert(Left != null);

            var a = Left.Left;
            var b = Left.Right;
            var c = Right;
            var rotatedThis = new TreeNode<T>(b, c, Value);
            var rotatedLeft = new TreeNode<T>(a, rotatedThis, Left.Value);

            return rotatedLeft;
        }

        [Pure]
        private TreeNode<T> RotateLeft()
        {
            Debug.Assert(Right != null);

            var a = Left;
            var b = Right.Left;
            var c = Right.Right;

            var rotatedThis = new TreeNode<T>(a, b, Value);
            var rotatedRight = new TreeNode<T>(rotatedThis, c, Right.Value);

            return rotatedRight;
        }

        [Pure]
        private TreeNode<T> Balance()
        {
            if (this.BalanceFactor() == 2)
            {
                Debug.Assert(Right != null);

                if (Right.BalanceFactor() >= 0)
                {
                    return RotateLeft();
                }

                Debug.Assert(Right.Left != null);

                var a = Left;
                var b = Right.Left.Left;
                var c = Right.Left.Right;
                var d = Right.Right;

                return new TreeNode<T>(a, b, c, d, Value, Right.Value, Right.Left.Value);
            }

            if (this.BalanceFactor() == -2)
            {
                Debug.Assert(Left != null);

                if (Left.BalanceFactor() <= 0)
                {
                    return RotateRight();
                }

                Debug.Assert(Left.Right != null);

                var a = Left.Left;
                var b = Left.Right.Left;
                var c = Left.Right.Right;
                var d = Right;

                return new TreeNode<T>(a, b, c, d, Left.Value, Value, Left.Right.Value);
            }

            return new TreeNode<T>(this, Value);
        }

        [Pure]
        public TreeNode<T> Insert([NotNull] T newValue)
        {
            var compareResult = newValue.CompareTo(Value);
            if (compareResult == 0)
            {
                throw new NotSupportedException($"Value {newValue} already exists.");
            }

            var newLeft = Left;
            var newRight = Right;
            if (compareResult < 0)
            {
                newLeft = Left?.Insert(newValue) ?? new TreeNode<T>(newValue);
            }

            if (compareResult > 0)
            {
                newRight = Right?.Insert(newValue) ?? new TreeNode<T>(newValue);
            }

            return new TreeNode<T>(newLeft, newRight, Value).Balance();
        }

        [Pure]
        public TreeNode<T> RemoveMin([NotNull] out T minValue)
        {
            if (Left == null)
            {
                Debug.Assert(Right?.Left == null);
                Debug.Assert(Right?.Right == null);
                minValue = Value;
                return Right;
            }

            var newLeft = Left.RemoveMin(out minValue);
            return new TreeNode<T>(newLeft, Right, Value).Balance();
        }

        [Pure]
        public TreeNode<T> Remove([NotNull] T valueToRemove, out bool success)
        {
            var compareResult = valueToRemove.CompareTo(Value);
            var value = Value;
            var newLeft = Left;
            var newRight = Right;

            if (compareResult < 0)
            {
                if (Left == null)
                {
                    success = false;
                    return this;
                }

                newLeft = Left.Remove(valueToRemove, out success);
            }
            else if (compareResult > 0)
            {
                if (Right == null)
                {
                    success = false;
                    return this;
                }

                newRight = Right.Remove(valueToRemove, out success);
            }
            else
            {
                success = true;
                if (newRight == null)
                {
                    return newLeft;
                }

                newRight = newRight.RemoveMin(out value);
            }

            return success ? new TreeNode<T>(newLeft, newRight, value).Balance() : this;
        }


        public TreeNode<T> FindNode([NotNull] T valueToFind)
        {
            var compareResult = valueToFind.CompareTo(Value);
            if (compareResult > 0)
            {
                return Right?.FindNode(valueToFind);
            }

            if (compareResult < 0)
            {
                return Left?.FindNode(valueToFind);
            }

            return this;
        }

        [Pure]
        public IEnumerator<T> GetEnumerator()
        {
            var stack = new Stack<TreeNode<T>>((int) Math.Pow(2, Height));
            var visited = new HashSet<TreeNode<T>>();
            stack.Push(this);
            while (stack.Any())
            {
                var node = stack.Peek();
                Debug.Assert(node != null, nameof(node) + " != null");

                if (visited.Contains(node))
                {
                    yield return node.Value;
                    stack.Pop();
                    if (node.Right != null && !visited.Contains(node.Right))
                    {
                        stack.Push(node.Right);
                    }

                    continue;
                }

                visited.Add(node);

                if (node.Left != null && !visited.Contains(node.Left))
                {
                    stack.Push(node.Left);
                }
            }
        }

        [Pure]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        [Pure]
        public override string ToString()
        {
            return $"Node{{{Value}}}";
        }
    }

    internal static class TreeNodeExtensions
    {
        public static int SafeHeight<T>(this TreeNode<T> node) where T : IComparable<T>
        {
            return node?.Height ?? 0;
        }

        public static int BalanceFactor<T>([NotNull] this TreeNode<T> node) where T : IComparable<T>
        {
            return node.Right.SafeHeight() - node.Left.SafeHeight();
        }
    }
}