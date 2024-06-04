using InventoryTest.InventoryObjects;

namespace InventoryTest.ContainerSystem;

public static class ContainerOperations
{
    public static void Move<T>(BaseContainer from, BaseContainer to, int count) where T : BaseInventoryObject, new()
    {
        T? element = from.Get<T>();
        
        if (element == null)
            return;
        
        T? movedElem = to.Add<T>(Math.Min(count, element.Count));
        
        if (movedElem != null) {
            from.Remove<T>(movedElem.Count);
        }
    }
}