#region License

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskInterfaceFactory.cs" company="MorseCode Software">
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
    using System;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;

    /// <summary>
    /// Factory for creating <see cref="ITask"/> instances.
    /// </summary>
    public static class TaskInterfaceFactory
    {
        /// <summary>
        /// Creates an <see cref="ITask"/> from a method returning a <see cref="Task"/>.
        /// </summary>
        /// <param name="func">
        /// The method which returns a <see cref="Task"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ITask"/>.
        /// </returns>
        /// <remarks>
        /// This method allows for creating an <see cref="ITask"/> from an async method (which must return either <see cref="Task"/> or <see cref="Task{TResult}"/>).
        /// </remarks>
        public static ITask CreateTask(Func<Task> func)
        {
            Contract.Requires(func != null);

            return func().AsITask();
        }

        /// <summary>
        /// Creates an <see cref="ITask{TResult}"/> from a method returning a <see cref="Task{TResult}"/>.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the result of the task.
        /// </typeparam>
        /// <param name="func">
        /// The method which returns a <see cref="Task{TResult}"/>.
        /// </param>
        /// <returns>
        /// The <see cref="ITask{TResult}"/>.
        /// </returns>
        /// <remarks>
        /// This method allows for creating an <see cref="ITask{TResult}"/> from an async method (which must return either <see cref="Task"/> or <see cref="Task{TResult}"/>).
        /// </remarks>
        public static ITask<TResult> CreateTask<TResult>(Func<Task<TResult>> func)
        {
            Contract.Requires(func != null);

            return func().AsITask();
        }
    }
}