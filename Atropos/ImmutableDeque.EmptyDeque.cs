﻿using System;

namespace Atropos
{

    public sealed partial class ImmutableDeque<T>
    {
        private sealed class EmptyDeque : IImmutableDeque<T>
        {
            private static readonly Exception _ioe = new InvalidOperationException("This deque is empty");
            public bool IsEmpty => true;
            public IImmutableDeque<T> EnqueueLeft(T value) => new SingleDeque(value);
            public IImmutableDeque<T> EnqueueRight(T value) => new SingleDeque(value);
            public IImmutableDeque<T> DequeueLeft() => throw _ioe;
            public IImmutableDeque<T> DequeueRight() => throw _ioe;
            public T PeekLeft() => throw _ioe;
            public T PeekRight() => throw _ioe;
        }
    }
}