using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSS_Demo
{
    public sealed class AsyncTimer : IDisposable
    {
        private bool hasStarted;

        private CancellationTokenSource cts = new CancellationTokenSource();

        private TimeSpan interval;

        private Action callback;

        public AsyncTimer(TimeSpan interval, Action callback)
        {
            this.interval = interval;
            this.callback = callback;
        }

        public void Start()
        {
            if (hasStarted)
            {
                //Timern har redan startat

                return;
            }
            hasStarted = true;
            Task.Run(execute);
        }

        private async Task execute()
        {
            while (!cts.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(interval, cts.Token);
                    callback();
                }

                catch (Exception)
                {
                    //Ingenting
                }
            }
        }

        public void Dispose()
        {
            cts.Cancel();
            cts.Dispose();
        }
    }
}