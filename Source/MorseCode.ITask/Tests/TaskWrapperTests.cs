#region License

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskWrapperTests.cs" company="MorseCode Software">
// Copyright (c) 2015 MorseCode Software
// </copyright>
// <summary>
// The MIT License (MIT)
// 
// Copyright (c) 2015 MorseCode Software
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

namespace MorseCode.ITask.Tests
{
    using System.Threading;
    using System.Threading.Tasks;

    using NUnit.Framework;

    [TestFixture]
    public class TaskWrapperTests
    {
        #region Public Methods and Operators

        [Test]
        public async Task AsITaskExtensionMethod()
        {
            await Task.Run(() => Thread.Sleep(50)).AsITask().ConfigureAwait(false);
        }

        [Test]
        public async Task AsITaskWithResultExtensionMethod()
        {
            const int Value = 5;
            int result = await Task.Run(() =>
                {
                    Thread.Sleep(50);
                    return Value;
                }).AsITask().ConfigureAwait(false);

            Assert.AreEqual(Value, result);
        }

        [Test]
        public async Task AsTaskExtensionMethod()
        {
            await TaskInterfaceFactory.CreateTask(async () => await Task.Delay(50).ConfigureAwait(false)).AsTask().ConfigureAwait(false);
        }

        [Test]
        public async Task AsTaskWithResultExtensionMethod()
        {
            const int Value = 5;
            int result = await TaskInterfaceFactory.CreateTask(async () =>
                {
                    await Task.Delay(50).ConfigureAwait(false);
                    return Value;
                }).AsTask().ConfigureAwait(false);

            Assert.AreEqual(Value, result);
        }

        [Test]
        public async Task TaskInterfaceFactoryCreateMethod()
        {
            await TaskInterfaceFactory.CreateTask(async () => await Task.Delay(50).ConfigureAwait(false)).ConfigureAwait(false);
        }

        [Test]
        public async Task TaskInterfaceFactoryCreateWithResultMethod()
        {
            const int Value = 5;
            int result = await TaskInterfaceFactory.CreateTask(async () =>
            {
                await Task.Delay(50).ConfigureAwait(false);
                return Value;
            }).ConfigureAwait(false);

            Assert.AreEqual(Value, result);
        }

        [Test]
        public void ConfiguredTaskWrapperCreateAwaiter()
        {
            IAwaiter awaiter = Task.Run(() => Thread.Sleep(50)).AsITask().ConfigureAwait(false).CreateAwaiter();

            Assert.IsNotNull(awaiter);
        }

        [Test]
        public void ConfiguredTaskWrapperWithResultCreateAwaiter()
        {
            const int Value = 5;
            IAwaiter<int> awaiter = Task.Run(() =>
                {
                    Thread.Sleep(50);
                    return Value;
                }).AsITask().ConfigureAwait(false).CreateAwaiter();

            Assert.IsNotNull(awaiter);
        }

        [Test]
        public async Task TaskWrapper()
        {
            await Task.Run(() => Thread.Sleep(50)).AsITask();
        }

        [Test]
        public async Task TaskWrapperConfigureAwaitFalse()
        {
            await Task.Run(() => Thread.Sleep(50)).AsITask().ConfigureAwait(false);
        }

        [Test]
        public async Task TaskWrapperConfigureAwaitTrue()
        {
            await Task.Run(() => Thread.Sleep(50)).AsITask().ConfigureAwait(true);
        }

        [Test]
        public void TaskWrapperCreateAwaiter()
        {
            IAwaiter awaiter = Task.Run(() => Thread.Sleep(50)).AsITask().CreateAwaiter();

            Assert.IsNotNull(awaiter);
        }

        [Test]
        public void TaskWrapperResult()
        {
            const int Value = 5;
            int result = Task.Run(() =>
                {
                    Thread.Sleep(50);
                    return Value;
                }).AsITask().Result;

            Assert.AreEqual(Value, result);
        }

        [Test]
        public async Task TaskWrapperWithResult()
        {
            const int Value = 5;
            int result = await Task.Run(() =>
                {
                    Thread.Sleep(50);
                    return Value;
                }).AsITask();

            Assert.AreEqual(Value, result);
        }

        [Test]
        public async Task TaskWrapperWithResultConfigureAwaitFalse()
        {
            const int Value = 5;
            int result = await Task.Run(() =>
                {
                    Thread.Sleep(50);
                    return Value;
                }).AsITask().ConfigureAwait(false);

            Assert.AreEqual(Value, result);
        }

        [Test]
        public async Task TaskWrapperWithResultConfigureAwaitTrue()
        {
            const int Value = 5;
            int result = await Task.Run(() =>
                {
                    Thread.Sleep(50);
                    return Value;
                }).AsITask().ConfigureAwait(true);

            Assert.AreEqual(Value, result);
        }

        [Test]
        public void TaskWrapperWithResultCreateAwaiter()
        {
            const int Value = 5;
            IAwaiter<int> awaiter = Task.Run(() =>
                {
                    Thread.Sleep(50);
                    return Value;
                }).AsITask().CreateAwaiter();

            Assert.IsNotNull(awaiter);
        }

        #endregion
    }
}