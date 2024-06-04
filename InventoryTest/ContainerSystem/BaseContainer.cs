using System.Text;
using InventoryTest.InventoryObjects;

namespace InventoryTest.ContainerSystem;

public class BaseContainer
{
    private readonly Dictionary<Type, BaseInventoryObject> _inventoryObjects = new Dictionary<Type, BaseInventoryObject>();

    public T? Add<T>(int count) where T : BaseInventoryObject, new()
    {
        if (count <= 0)
            return null;
        
        Type type = typeof(T);
        
        if (_inventoryObjects.TryGetValue(type, out BaseInventoryObject? element)) {
            element.Count += count;
        }
        else {
            _inventoryObjects[type] = new T();
            _inventoryObjects[type].Count = count;
        }

        return (T) _inventoryObjects[type];
    }

    public T? Remove<T>(int count) where T : BaseInventoryObject
    {
        Type type = typeof(T);
        
        if (count <= 0)
            return (T) _inventoryObjects[type];

        if (_inventoryObjects.TryGetValue(type, out BaseInventoryObject? element)) {
            element.Count -= count;

            if (element.Count > 0)
                return (T)_inventoryObjects[type];

            _inventoryObjects.Remove(type);
            return null;

        }

        Console.WriteLine($"[WARNING] Can't remove object with type \"{type}\". This object type doesn't exist on this container.");
        return (T) _inventoryObjects[type];
    }

    public T? Get<T>() where T : BaseInventoryObject
    {
        Type type = typeof(T);

        if (!_inventoryObjects.TryGetValue(type, out BaseInventoryObject? value))
            return null;
        
        return (T) value;
    }

    public string PrintInfo()
    {
        StringBuilder stringBuilder = new StringBuilder();
        
        foreach (KeyValuePair<Type, BaseInventoryObject> objPair in _inventoryObjects) {
            stringBuilder.AppendLine($"{objPair.Value.Name} : {objPair.Value.Count}");
        }

        return stringBuilder.ToString();
    }
}