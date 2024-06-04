using InventoryTest.InventoryObjects;

namespace InventoryTest.ContainerSystem;

public static class ContainerOperations
{
    public static void Move<T>(ref BaseContainer from, ref BaseContainer to, int count) where T : BaseInventoryObject, new()
    {
        T element = from.Get<T>();
        to.Add<T>(element.Count, out var returnCount);
        from.Remove<T>(element.Count - returnCount);
    }
}