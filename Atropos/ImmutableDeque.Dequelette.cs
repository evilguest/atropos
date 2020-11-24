using System;

namespace Atropos
{

    public sealed partial class ImmutableDeque<T>
    {
        private abstract class Dequelette
        {
            public abstract int Size { get; }
            public virtual bool Full { get { return false; } }
            public abstract T PeekLeft();
            public abstract T PeekRight();
            public abstract Dequelette EnqueueLeft(T t);
            public abstract Dequelette EnqueueRight(T t);
            public abstract Dequelette DequeueLeft();
            public abstract Dequelette DequeueRight();
        }
        private class One : Dequelette
        {
            public One(T t1) => v1 = t1;
            public override int Size => 1;
            public override T PeekLeft() => v1;
            public override T PeekRight() => v1;
            public override Dequelette EnqueueLeft(T t) => new Two(t, v1);
            public override Dequelette EnqueueRight(T t) => new Two(v1, t);
            public override Dequelette DequeueLeft() => throw new Exception("Impossible");
            public override Dequelette DequeueRight() => throw new Exception("Impossible");
            private readonly T v1;
        }
        private class Two : Dequelette
        {
            public Two(T t1, T t2) => (v1, v2) = (t1, t2);
            public override int Size => 2;
            public override T PeekLeft() => v1;
            public override T PeekRight() => v2;
            public override Dequelette EnqueueLeft(T t) => new Three(t, v1, v2);
            public override Dequelette EnqueueRight(T t) => new Three(v1, v2, t);
            public override Dequelette DequeueLeft() => new One(v2);
            public override Dequelette DequeueRight() => new One(v1);
            private readonly T v1;
            private readonly T v2;
        }
        private class Three : Dequelette
        {
            public Three(T t1, T t2, T t3) => (v1, v2, v3) = (t1, t2, t3);
            public override int Size => 3;
            public override T PeekLeft() => v1;
            public override T PeekRight() => v3;
            public override Dequelette EnqueueLeft(T t) => new Four(t, v1, v2, v3);
            public override Dequelette EnqueueRight(T t) => new Four(v1, v2, v3, t);
            public override Dequelette DequeueLeft() => new Two(v2, v3);
            public override Dequelette DequeueRight() => new Two(v1, v2);
            private readonly T v1;
            private readonly T v2;
            private readonly T v3;
        }
        private class Four : Dequelette
        {
            public Four(T t1, T t2, T t3, T t4)
                => (v1, v2, v3, v4) = (t1, t2, t3, t4);
            public override int Size => 4;
            public override bool Full => true;
            public override T PeekLeft() => v1;
            public override T PeekRight() => v4;
            public override Dequelette EnqueueLeft(T t) => throw new Exception("Impossible");
            public override Dequelette EnqueueRight(T t) => throw new Exception("Impossible");
            public override Dequelette DequeueLeft() => new Three(v2, v3, v4);
            public override Dequelette DequeueRight() => new Three(v1, v2, v3);
            private readonly T v1;
            private readonly T v2;
            private readonly T v3;
            private readonly T v4;
        }

    }
}
