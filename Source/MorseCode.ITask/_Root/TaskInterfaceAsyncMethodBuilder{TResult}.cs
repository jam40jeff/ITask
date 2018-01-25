using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MorseCode.ITask.CompilerServices
{
    /// <summary>
    ///   Runtime helper for async methods returning <see cref="ITask"/>.
    /// </summary>
    [StructLayout(LayoutKind.Auto)]
    public struct TaskInterfaceAsyncMethodBuilder<TResult>
    {
        /// <summary>
        ///   Delegate everything to the official <see cref="Task"/> method builder
        ///   since we just use <see cref="TaskExtensionMethods.AsITask(System.Threading.Tasks.Task)"/>
        ///   in the end.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     This must not be marked <c>readonly</c> because it is mutable. If marked
        ///     <c>readonly</c>, first <c>await</c> silently freezes everything.
        ///   </para>
        /// </remarks>
        AsyncTaskMethodBuilder<TResult> builder;

        /// <summary>
        ///   Used by the compiler to generate the return value for the async method.
        /// </summary>
        public ITask<TResult> Task => builder.Task.AsITask();

        TaskInterfaceAsyncMethodBuilder(AsyncTaskMethodBuilder<TResult> builder) : this()
        {
            this.builder = builder;
        }



        /// <summary>
        ///   Part of async method builder contract: create a builder.
        /// </summary>
        public static TaskInterfaceAsyncMethodBuilder<TResult> Create()
            => new TaskInterfaceAsyncMethodBuilder<TResult>(
                AsyncTaskMethodBuilder<TResult>.Create());

        /// <summary>
        ///   Part of async method builder contract: set exception.
        /// </summary>
        public void SetException(Exception ex) => builder.SetException(ex);

        /// <summary>
        ///   Part of async method builder contract: set RanToCompletion.
        /// </summary>
        public void SetResult(TResult result) => builder.SetResult(result);

        /// <summary>
        ///   Part of async method builder contract: set the state machine to use
        ///   if the method ends up running asynchronously.
        /// </summary>
        public void SetStateMachine(IAsyncStateMachine stateMachine) => builder.SetStateMachine(stateMachine);

        /// <summary>
        ///   Part of async method builder contract: initialize and start running
        ///   the state machine.
        /// </summary>
        public void Start<TStateMachine>(ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine
            => builder.Start(ref stateMachine);

        /// <summary>
        ///   Part of async method builder contract: called when an awaited operation
        ///   is pending completion to schedule a continuation.
        /// </summary>
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter,
            ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine
            => builder.AwaitOnCompleted(ref awaiter, ref stateMachine);

        /// <summary>
        ///   Part of async method builder contract: called when an awaited operation
        ///   is pending completion to schedule a continuation.
        /// </summary>
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(
            ref TAwaiter awaiter,
            ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine
            => builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
    }
}
