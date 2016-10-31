using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public class MyEnumerator<T> : IEnumerator<T>
    {
        private readonly T[,] _source;
        private int _positionX;
        private int _positionY;
        private int _count = 0;

        public MyEnumerator(T[,] source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            _source = source;
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            try
            {
                if (_count == 0) return true;
                if (_count >= _source.GetLength(1) * _source.GetLength(0)) return false;
                if (_positionY == _source.GetLength(1) - 1)
                {
                    _positionX++;
                    _positionY = 0;
                    return _positionX != _source.GetLength(0);
                }
                _positionY++;
                return true;
            }
            finally
            {
                _count++;
            }
        }

        public void Reset()
        {
            _positionX = 0;
            _positionY = 0;
            _count = 0;
        }


        public T Current => _source[_positionX, _positionY];

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }

    class MyEnumeratorProxy<T> : IEnumerable<T>
    {
        private readonly T[,] _source;

        public MyEnumeratorProxy(T[,] source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            _source = source;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_source);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
