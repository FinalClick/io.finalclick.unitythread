using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace FinalClick.UnityThread
{
    public static class UnityMainThread
    {
        public static SynchronizationContext Context { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            Context = SynchronizationContext.Current;
        }

        public static Task<T> Run<T>(Func<T> func)
        {
            var tcs = new TaskCompletionSource<T>();
            Context.Post(_ =>
            {
                try
                {
                    var result = func();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }, null);
            return tcs.Task;
        }
        
        public static Task Run(Func<Task> func)
        {
            var tcs = new TaskCompletionSource<bool>();
            Context.Post(async _ =>
            {
                try
                {
                    await func();
                    tcs.SetResult(true);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }, null);
            return tcs.Task;
        }

        public static Task<T> Run<T>(Func<Task<T>> func)
        {
            var tcs = new TaskCompletionSource<T>();
            Context.Post(async _ =>
            {
                try
                {
                    var result = await func();
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }, null);
            return tcs.Task;
        }
    }
}