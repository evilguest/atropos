using System;

namespace Atropos
{

    public sealed partial class ImmutableDeque<T>
    {
        private abstract class Dequelette
        {
            public abstract int Size { get; }
            public virtual bool Full { get { return false; } }
            public abstract T Left { get; }

            public abstract T Right { get; }

            public abstract Dequelette EnqueueLeft(T t);
            public abstract Dequelette EnqueueRight(T t);
            public abstract Dequelette DequeueLeft();
            public abstract Dequelette DequeueRight();
        }
        private class One : Dequelette
        {
            public One(T t1) => left = t1;
            public override int Size => 1;
            public override T Left => left;
            public override T Right => left;
            public override Dequelette EnqueueLeft(T t) => new Two(t, left);
            public override Dequelette EnqueueRight(T t) => new Two(left, t);
            public override Dequelette DequeueLeft() => throw new Exception("Impossible");
            public override Dequelette DequeueRight() => throw new Exception("Impossible");
            protected readonly T left;
        }
        private class Two : One
        {
            public Two(T t1, T t2) : base(t1) => right = t2;
            public override int Size => 2;
            public override T Right => right;
            public override Dequelette EnqueueLeft(T t) => new Three(t, left, right);
            public override Dequelette EnqueueRight(T t) => new Three(left, right, t);
            public override Dequelette DequeueLeft() => new One(right);
            public override Dequelette DequeueRight() => new One(left);
            protected readonly T right;
        }
        private class Three : Two
        {
            public Three(T t1, T t2, T t3) : base(t1, t3) => midLeft = t2;
            public override int Size => 3;
            public override Dequelette EnqueueLeft(T t) => new Four(t, left, midLeft, right);
            public override Dequelette EnqueueRight(T t) => new Four(left, midLeft, right, t);
            public override Dequelette DequeueLeft() => new Two(midLeft, right);
            public override Dequelette DequeueRight() => new Two(left, midLeft);
            protected readonly T midLeft;
        }
        private class Four : Three
        {
            public Four(T t1, T t2, T t3, T t4) : base(t1, t2, t4) => midRight = t3;
            public override int Size => 4;
            public override bool Full => true;
            public override Dequelette EnqueueLeft(T t) => throw new Exception("Impossible");
            public override Dequelette EnqueueRight(T t) => throw new Exception("Impossible");
            public override Dequelette DequeueLeft() => new Three(midLeft, midRight, right);
            public override Dequelette DequeueRight() => new Three(left, midLeft, midRight);
            private readonly T midRight;
        }

    }
}
