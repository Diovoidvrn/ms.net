using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab1
{
    public class ThreadSafeStack<T> : IDisposable
    {
        private Stack<T> _buffer ;
        private int _maxBufferSize;
        private Semaphore _emptySemaphore;
        private Semaphore _maxSizeSemaphore;
        private Mutex _mutex;
        private Action<string> _pushPrint;
        private Action<string> _popPrint;

        public ThreadSafeStack(int maxBufferSize, Action<string> pushPrint, Action<string> popPrint)
        {
            _maxBufferSize = maxBufferSize;
            _buffer = new Stack<T>(maxBufferSize);
            _mutex = new Mutex();
            _emptySemaphore = new Semaphore(0, _maxBufferSize);
            _maxSizeSemaphore = new Semaphore(_maxBufferSize, _maxBufferSize);
            _pushPrint = pushPrint;
            _popPrint = popPrint;
        }

        public bool Push(T value)
        {
            if (!_maxSizeSemaphore.WaitOne(0))
                return false;

            _mutex.WaitOne();          
            _buffer.Push(value);
            _pushPrint(value.ToString());
            _emptySemaphore.Release();
            _mutex.ReleaseMutex();
                              
            return true;
        }

        public T Pop()
        {
            _emptySemaphore.WaitOne();
            _mutex.WaitOne();
            T value;            
            value = _buffer.Pop();
            _popPrint(value.ToString());
            _mutex.ReleaseMutex();
            _maxSizeSemaphore.Release();
                      
            return value;
        }

        public void Dispose()
        {
            _buffer.Clear();
            _maxBufferSize = 0;
            _mutex.Dispose();
            _emptySemaphore.Dispose();
        }
    }
}
