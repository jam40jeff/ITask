namespace System.Runtime.CompilerServices
{
    sealed class AsyncMethodBuilderAttribute : Attribute
    {
        public Type BuilderType { get; }

        public AsyncMethodBuilderAttribute(
            Type builderType)
        {
            BuilderType = builderType;
        }
    }
}
