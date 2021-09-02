using System.Runtime.InteropServices;

namespace Atropos
{
    internal struct Bunch<T>
    {
        internal T _data0;
        internal T _data1;
        internal T _data2;
        internal T _data3;
        internal T _data4;
        internal T _data5;
        internal T _data6;
        internal T _data7;
        internal T _data8;
        internal T _data9;
        internal T _dataA;
        internal T _dataB;
        internal T _dataC;
        internal T _dataD;
        internal T _dataE;
        internal T _dataF;
        public ref T this[int index]=>ref MemoryMarshal.CreateSpan(ref _data0, 16)[index];
    }
}