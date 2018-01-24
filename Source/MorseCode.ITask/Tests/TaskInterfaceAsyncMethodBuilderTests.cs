using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace MorseCode.ITask.Tests
{
    [TestFixture]
    public class TaskInterfaceAsyncMethodBuilderTests
    {
        [Test]
        public async Task TaskInterfaceAsyncMethodBuilderTask()
        {
            await TaskInterfaceAsyncMethodBuilderTaskMethodAsync().ConfigureAwait(false);
        }

        async ITask TaskInterfaceAsyncMethodBuilderTaskMethodAsync()
        {
            await Task.Delay(50).ConfigureAwait(false);
        }

        [Test]
        public async Task TaskInterfaceAsyncMethodBuilderResultTask()
        {
            var value = await TaskInterfaceAsyncMethodBuilderResultTaskMethodAsync().ConfigureAwait(false);
            Assert.AreEqual(3, value);
        }

        async ITask<int> TaskInterfaceAsyncMethodBuilderResultTaskMethodAsync()
        {
            var results = await Task.WhenAll(
                Enumerable.Range(0, 3).Select(async i =>
                {
                    await Task.Delay(i);
                    return i;
                }));
            return results.Length;
        }
    }
}
