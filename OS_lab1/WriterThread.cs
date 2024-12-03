using Lab1;
using System;
using System.Threading;

namespace OS_lab1
{
    public class WriterThread
    {
        private ThreadSafeStack<int> _buffer;
        private Thread _writer;
        private bool _isPaused = false;
        public bool IsStoped { get; private set; } = false;

        public WriterThread(ThreadSafeStack<int> buffer, Action<string> print)
        {
            _buffer = buffer;
            _writer = new Thread(() =>
            {
                print($"writer.{_writer.ManagedThreadId} : запустился");
                var rand = new Random();
                while (!IsStoped)
                {
                    while (_isPaused)
                        Thread.Sleep(1);

                    int value = rand.Next(100);
                    if (!_buffer.Push(value))
                        IsStoped = true;
                    else
                    {
                        print($"writer.{_writer.ManagedThreadId} : {value}");
                        Thread.Sleep(rand.Next(2, 4) * 100);
                    }
                }
                print($"writer.{_writer.ManagedThreadId} : завершился");
            });
        }
        public void Start() => _writer.Start();
        public void Pause() => _isPaused = true;
        public void Resume() => _isPaused = false;
        public void Stop()
        {
            _isPaused = false;
            IsStoped = true;
        }
        public void Join() => _writer.Join();
    }
}
