# ClientTimeSynchronizationScheme
The scheme of client getting time from server and keeping synchronization
``` c#
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StopWatchTest
{
    public sealed class TimeWatch
    {
        private static TimeWatch TW;
        private static readonly object _lock = new object();
        private static Stopwatch stopwatch = Stopwatch.StartNew();
        private static DateTime initDateTime = DateTime.Now;
        private static Func<DateTime> CorrectingTimeStrategy;
        private static TimeSpan CorrectingSpan;
        public static DateTime DateTimeNow { get => initDateTime + stopwatch.Elapsed; }
        public static TimeWatch GetInstance(Func<DateTime> synchronizeStragy, TimeSpan synchronizeSpan)
        {
           if(TW==null)
            {
                lock (_lock)
                {
                    if (TW == null)
                        TW = new TimeWatch(synchronizeStragy, synchronizeSpan);
                }
            }
            return TW;
        }
        /// <summary>
        /// 启动一个计时器，计时器会自动从指定的获取时间的委托(synchronizeStragy)获取时间并开始计时。计时器还可以按指定的时间间隔(synchronizeSpan)循环执行委托进行校时。
        /// </summary>
        /// <param name="correctingTimeStrategy">获取时间的委托</param>
        /// <param name="correctingSpan">想要执行校时的时间间隔</param>
        private TimeWatch(Func<DateTime> correctingTimeStrategy, TimeSpan correctingSpan)
        {
            if (correctingSpan.TotalSeconds < 1)
                throw new ArgumentException("执行同步的间隔不能小于1秒", nameof(correctingSpan));
            CorrectingTimeStrategy = correctingTimeStrategy ?? throw new ArgumentNullException(nameof(correctingTimeStrategy));
            CorrectingSpan = correctingSpan;
            stopwatch.Start();
            StartAsync().ConfigureAwait(false);
        }
        public static async Task StartAsync()
        {
            try
            {
                TimeSpan timeSpanElapsedBoforeRequst;
                do
                {
                    //(stopwatch.Elapsed-timeSpanElapsedBoforeRequst).TotalMilliseconds /2) 取请求往返耗时的一半，即执行该获取时间的工作所造成的延时。把这个延时要加进计时器里
                    timeSpanElapsedBoforeRequst = stopwatch.Elapsed;
                    initDateTime = (await Task.Run(() => CorrectingTimeStrategy.Invoke())).AddMilliseconds((stopwatch.Elapsed-timeSpanElapsedBoforeRequst).TotalMilliseconds /2) - stopwatch.Elapsed;
                    var i = stopwatch.Elapsed;
                    await Task.Delay(CorrectingSpan);
                } while (true);
            }
            catch { throw; }
        }
    }
}
``` 

The following is an example of calling it in a WinForm application
``` C#
            DateTime dateTime = DateTime.Parse(textBox1.Text.Trim());
            Func<DateTime> func = () =>
            {
                System.Threading.Thread.Sleep(1500);//模拟网络耗时
                    return dateTime;
            };
            TimeWatch.GetInstance(func, TimeSpan.FromSeconds(3));

            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 100;
            timer.Start();
            timer.Tick += (s, ee) =>
            {
                this.labelNowTime.Text = TimeWatch.DateTimeNow.ToString("yyyy-MM-dd HH:mm:ss fff");
            };
```
There is The complete source code in release part.You can download it there.

If it has a little reference value for you, I hope you can help me light up a star,I have never had it. 
