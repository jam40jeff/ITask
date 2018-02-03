// Avoid any “using MorseCode.ITask” to verify that we can await ITask without
// needing to have the extension methods visible. This improves consumability of
// ITask in other projects.
// See https://github.com/jam40jeff/ITask/issues/4

namespace MorseCodeDifferentNamespace.ITask.Tests
{
    using NUnit.Framework;
    using System.Threading.Tasks;

    [TestFixture]
    public class AwaitTaskInterfaceDifferentNamespaceTests
    {
        // Full type name here to avoid “using MorseCode.ITask”.
        async MorseCode.ITask.ITask DoSomethingAsync()
        {
            await Task.Yield();
        }

        [Test]
        public async Task CanAwaitITaskWithoutUsingNamespace()
        {
            await DoSomethingAsync();
        }

        // Full type name here to avoid “using MorseCode.ITask”
        async MorseCode.ITask.ITask<int> CalculateSomethingAsync()
        {
            await Task.Yield();
            return 42;
        }

        [Test]
        public async Task CanAwaitITaskResultWithoutUsingNamespace()
        {
            Assert.AreEqual(42, await CalculateSomethingAsync());
        }
    }
}
