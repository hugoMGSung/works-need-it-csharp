using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading.Tasks.Dataflow;

namespace Chap01App
{
    public class Ch01_01
    {
        public async Task DoSomethingAsync()
        {
            int value = 13;
            await Task.Delay(TimeSpan.FromSeconds(1));  // 비동기로 1초간 대기

            value *= 2;
            await Task.Delay(TimeSpan.FromSeconds(1));  // 비동기로 1초간 대기

            Trace.WriteLine(value);
            Console.WriteLine(value);
        }
    }

    public abstract class Ch01_02
    {
        public async Task DoSomethingAsync()
        {
            int value = 13;
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            value *= 2;
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            Trace.WriteLine(value);
            Console.WriteLine(value);
        }
    }

    public class Ch01_02_1 : Ch01_02
    {
        // 상속해야 함
    }

    public abstract class Ch01_03
    {
        public abstract Task PossibleExceptionAsync();
        public abstract void LogException(Exception ex);

        public async Task TrySomethingAsync()
        {
            try
            {
                await PossibleExceptionAsync();
            }
            catch (NotSupportedException ex)
            {
                LogException(ex);
                throw;
            }
        }
    }

    public class Ch01_03_1 : Ch01_03
    {
        public override async Task PossibleExceptionAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine("Ch01_03_1");
        }
        public override void LogException(Exception ex)
        {
            Trace.WriteLine(ex.Message);
            Console.WriteLine(ex.Message);
        }
    }

    public class Ch01_08
    {
        public void ProcessArray(double[] array)
        {
            Parallel.Invoke(
                () => ProcessPartialArray(array, 0, array.Length / 2),
                () => ProcessPartialArray(array, array.Length / 2, array.Length)
            );
        }

        public void ProcessPartialArray(double[] array, int begin, int end)
        {
            // CPU-intensive processing...
            Console.WriteLine($"Processing from {begin} to {end}");
        }
    }

    public class Ch01_09
    {
        public void Test()
        {
            try
            {
                Parallel.Invoke(() => { throw new Exception(); },
                    () => { throw new Exception(); });
            }
            catch (AggregateException ex)
            {
                ex.Handle(exception =>
                {
                    Trace.WriteLine(exception);
                    return true; // "handled"
                });
            }
        }
    }

    public class Ch01_10
    {
        public void Test()
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Timestamp()
                .Where(x => x.Value % 2 == 0)
                .Select(x => x.Timestamp)
                .Subscribe(x => Trace.WriteLine(x));
        }

        public void Test2()
        {
            IObservable<DateTimeOffset> timestamps =
                Observable.Interval(TimeSpan.FromSeconds(1))
                    .Timestamp()
                    .Where(x => x.Value % 2 == 0)
                    .Select(x => x.Timestamp);
            timestamps.Subscribe(x => Trace.WriteLine(x));
        }

        public void Test3()
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Timestamp()
                .Where(x => x.Value % 2 == 0)
                .Select(x => x.Timestamp)
                .Subscribe(x => Trace.WriteLine(x),
                    ex => Trace.WriteLine(ex));
        }
    }

    public class Ch01_11
    {
        public void Test()
        {
            try
            {
                var multiplyBlock = new TransformBlock<int, int>(item =>
                {
                    if (item == 1)
                        throw new InvalidOperationException("Blech.");
                    return item * 2;
                });
                var subtractBlock = new TransformBlock<int, int>(item => item - 2);
                multiplyBlock.LinkTo(subtractBlock,
                    new DataflowLinkOptions { PropagateCompletion = true });

                multiplyBlock.Post(1);
                subtractBlock.Completion.Wait();
            }
            catch (AggregateException exception)
            {
                AggregateException ex = exception.Flatten();
                Trace.WriteLine(ex.InnerException);
            }
        }
    }

    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("챕터1 학습");

            // 챕터 1 - 1
            Console.WriteLine("챕터01-01 시작");
            var ch01_01 = new Ch01_01();
            await ch01_01.DoSomethingAsync();

            // 챕터 1 - 2
            Console.WriteLine("챕터01-02 시작");
            var ch01_02 = new Ch01_02_1();
            await ch01_02.DoSomethingAsync();

            // 챕터 1 - 3
            Console.WriteLine("챕터01-03 시작");
            var ch01_03 = new Ch01_03_1();
            await ch01_03.TrySomethingAsync();

            // 챕터 1 - 10
            Console.WriteLine("챕터01-10 시작");
            var ch01_10 = new Ch01_10();
            ch01_10.Test();
        }
    }
}
