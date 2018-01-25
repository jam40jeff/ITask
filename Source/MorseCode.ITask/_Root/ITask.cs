#region License

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITask.cs" company="MorseCode Software">
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
    using MorseCode.ITask.CompilerServices;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// An interface representing a Task which does not return a value.
    /// </summary>
    [AsyncMethodBuilder(typeof(TaskInterfaceAsyncMethodBuilder))]
    public interface ITask
    {
        /// <summary>Creates an awaiter used to await this <see cref="ITask"/>.</summary>
        /// <returns>An awaiter instance.</returns>
        /// <remarks>This method is intended for compiler user rather than use directly in code.</remarks>
        IAwaiter CreateAwaiter();

        /// <summary>Configures an awaiter used to await this <see cref="ITask"/>.</summary>
        /// <param name="continueOnCapturedContext">
        /// true to attempt to marshal the continuation back to the original context captured; otherwise, false.
        /// </param>
        /// <returns>An object used to await this task.</returns>
        IConfiguredTask ConfigureAwait(bool continueOnCapturedContext);
    }
}