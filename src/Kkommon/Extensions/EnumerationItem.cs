namespace Kkommon.Extensions
{
    public readonly struct EnumerationItem<T>
    {
        public readonly int Index;
        public readonly T Item;

        public EnumerationItem(int index, T item)
        {
            Index = index;
            Item = item;
        }

        public void Deconstruct(out int index, out T item)
        {
            index = Index;
            item = Item;
        }
    }
}