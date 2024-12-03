using Lab1;
using System;
using System.Collections.Generic;
using System.Threading;

namespace OS_lab1
{
    public class ThreadingService
    {
        private ThreadSafeStack<int> _buffer;
        private ReaderThread _reader;
        private List<WriterThread> _writers;
        private bool _isPaused = false;
        private bool _isStoped = false;
        private Thread _mainThread;

        public ThreadingService(Action<string> pushPrint, Action<string> popPrint, Action<string> readerPrint, Action<string> writerPrint)
        {
            var rand = new Random();
            _buffer = new ThreadSafeStack<int>(rand.Next(4, 15), pushPrint, popPrint);
            _reader = new ReaderThread(_buffer, readerPrint);
            _writers = new List<WriterThread>();

            _mainThread = new Thread(() =>
            {
                _reader.Start();

                while (!_isStoped)
                {
                    while(_isPaused)
                        Thread.Sleep(1);

                    var writer = new WriterThread(_buffer, writerPrint);
                    _writers.Add(writer);
                    writer.Start();
                    
                    RemoveDeadWriters(_writers.Count); 

                    Thread.Sleep(rand.Next(3, 6) * 1000);
                }

                _reader.Stop();
                _reader.Join();

                foreach (var writer in _writers)
                {
                    writer.Stop();
                    writer.Join();
                }

                _buffer.Dispose();
            });
        }

        private void RemoveDeadWriters(int count)
        {
            for (int i = 0; i < count; ++i, --count)
                if (_writers[i].IsStoped)
                {
                    _writers[i].Join();
                    _writers.RemoveAt(i);
                    i--;
                }
        }

        public void Start()
        {

            _mainThread.Start();
        }

        public void Stop()
        {
            if (_isStoped) return;

            _isStoped = true;
            ResumeReader();
            ResumeWriters();
            _mainThread.Join();
        }

        public void PauseReader()
        {
            _reader.Pause();
        }

        public void ResumeReader()
        { 
            _reader.Resume();
        }

        public void PauseWriters()
        {
            _isPaused = true;
            foreach (var writer in _writers)
            {
                writer.Pause();
            }
        }

        public void ResumeWriters()
        {
            foreach (var writer in _writers)
            {
                writer.Resume();
            }
            _isPaused = false;
        }
    }
}
