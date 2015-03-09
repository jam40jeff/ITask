#region License

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskExtensionMethods.cs" company="MorseCode Software">
// Copyright (c) 2014 MorseCode Software
// </copyright>
// <summary>
// The MIT License (MIT)
// 
// Copyright (c) 2014 MorseCode Software
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace MorseCode.ITask
{
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;

    /// <summary>
    /// Class providing task extension methods.
    /// </summary>
    public static class TaskExtensionMethods
    {
        /// <summary>
        /// Converts the <see cref="Task"/> instance into an <see cref="ITask"/>.
        /// </summary>
        /// <param name="task">
        /// The task to convert.
        /// </param>
        /// <returns>
        /// The <see cref="ITask"/>.
        /// </returns>
        public static ITask AsITask(this Task task)
        {
            return new TaskWrapper(task);
        }

        /// <summary>
        /// Converts the <see cref="Task{TResult}"/> instance into an <see cref="ITask{TResult}"/>.
        /// </summary>
        /// <param name="task">
        /// The task to convert.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the result of the task.
        /// </typeparam>
        /// <returns>
        /// The <see cref="ITask{TResult}"/>.
        /// </returns>
        public static ITask<TResult> AsITask<TResult>(this Task<TResult> task)
        {
            return new TaskWrapper<TResult>(task);
        }

        /// <summary>
        /// Converts the <see cref="ITask"/> instance into a <see cref="Task"/>.
        /// </summary>
        /// <param name="task">
        /// The task to convert.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task AsTask(this ITask task)
        {
            await task.ConfigureAwait(false);
        }

        /// <summary>
        /// Converts the <see cref="ITask{TResult}"/> instance into a <see cref="Task{TResult}"/>.
        /// </summary>
        /// <param name="task">
        /// The task to convert.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the result of the task.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task{TResult}"/>.
        /// </returns>
        public static async Task<TResult> AsTask<TResult>(this ITask<TResult> task)
        {
            return await task;
        }

        /// <summary>
        /// Gets a concrete awaiter.
        /// </summary>
        /// <param name="awaitable">
        /// The awaitable.
        /// </param>
        /// <returns>
        /// The <see cref="AwaiterInterfaceWrapper"/>.
        /// </returns>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        public static AwaiterInterfaceWrapper GetAwaiter(this ITask awaitable)
        {
            Contract.Requires(awaitable != null);

            return new AwaiterInterfaceWrapper(awaitable.CreateAwaiter());
        }

        /// <summary>
        /// Gets a concrete awaiter.
        /// </summary>
        /// <param name="awaitable">
        /// The awaitable.
        /// </param>
        /// <returns>
        /// The <see cref="AwaiterInterfaceWrapper"/>.
        /// </returns>
        public static AwaiterInterfaceWrapper GetAwaiter(this IConfiguredTask awaitable)
        {
            Contract.Requires(awaitable != null);

            return new AwaiterInterfaceWrapper(awaitable.CreateAwaiter());
        }

        /// <summary>
        /// Gets a concrete awaiter.
        /// </summary>
        /// <param name="awaitable">
        /// The awaitable.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the result of the task.
        /// </typeparam>
        /// <returns>
        /// The <see cref="AwaiterInterfaceWrapper{TResult}"/>.
        /// </returns>
        public static AwaiterInterfaceWrapper<TResult> GetAwaiter<TResult>(this ITask<TResult> awaitable)
        {
            Contract.Requires(awaitable != null);

            return new AwaiterInterfaceWrapper<TResult>(awaitable.CreateAwaiter());
        }

        /// <summary>
        /// Gets a concrete awaiter.
        /// </summary>
        /// <param name="awaitable">
        /// The awaitable.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the result of the task.
        /// </typeparam>
        /// <returns>
        /// The <see cref="AwaiterInterfaceWrapper{TResult}"/>.
        /// </returns>
        public static AwaiterInterfaceWrapper<TResult> GetAwaiter<TResult>(this IConfiguredTask<TResult> awaitable)
        {
            Contract.Requires(awaitable != null);

            return new AwaiterInterfaceWrapper<TResult>(awaitable.CreateAwaiter());
        }
    }
}