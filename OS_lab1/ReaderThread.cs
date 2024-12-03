using Lab1;
using System;
using System.Threading;

namespace OS_lab1
{
    public class ReaderThread
    {
        private ThreadSafeStack<int> _buffer;
        private Thread _reader;
        private bool _isPaused = false;
        public bool IsStoped { get; private set; } = false;

        public ReaderThread(ThreadSafeStack<int> buffer, Action<string> print)
        {
            _buffer = buffer;
            _reader = new Thread(() =>
            {
                print("reader : запустился");
                var rand = new Random();
                while (!IsStoped)
                {
                    while (_isPaused)
                        Thread.Sleep(1);

                    int value = _buffer.Pop();
                    print($"reader : {value}");

                    Thread.Sleep(rand.Next(2, 4) * 100);
                }
                print("reader : завершился");
            });
        }
        public void Start() => _reader.Start();

        public void Pause() => _isPaused = true;
        public void Resume() => _isPaused = false;
        public void Stop()
        { 
            _isPaused = false;
            IsStoped = true;
        }

        public void Join() => _reader.Join();
    }
}
