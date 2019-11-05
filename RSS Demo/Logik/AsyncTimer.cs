using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSS_Demo
{
    public sealed class AsyncTimer : IDisposable
    {
        private bool hasStarted;

        private readonly CancellationTokenSource cts = new CancellationTokenSource();

        private TimeSpan interval;

        private readonly Action callback;

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
            Task.Run(Execute);
        }

        private async Task Execute()
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