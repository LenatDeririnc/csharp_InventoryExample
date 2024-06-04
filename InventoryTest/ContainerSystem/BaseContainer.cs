using System.Text;
using InventoryTest.InventoryObjects;

namespace InventoryTest.ContainerSystem;

public class BaseContainer
{
    private readonly Dictionary<Type, BaseInventoryObject> _inventoryObjects = new Dictionary<Type, BaseInventoryObject>();

    public void Add<T>(int count, out int returnCount) where T : BaseInventoryObject, new()
    {
        Type type = typeof(T);
        returnCount = 0;
        
        if (_inventoryObjects.TryGetValue(type, out BaseInventoryObject? element)) {
            var prevCount = element.Count;
            element.Count += count;
            returnCount = element.Count - count;
        }
        else {
            _inventoryObjects[type] = new T();
            _inventoryObjects[type].Count = count;
            returnCount = _inventoryObjects[type].Count - count;
        }
    }

    public void Remove<T>(int count) where T : BaseInventoryObject
    {
        Type type = typeof(T);

        if (_inventoryObjects.TryGetValue(type, out BaseInventoryObject? element)) {
            element.Count -= count;
            if (element.Count <= 0) {
                _inventoryObjects.Remove(type);
            }
            
            return;
        }

        Console.WriteLine($"[WARNING] Can't remove object with type \"{type}\". This object type doesn't exist on this container.");
        return;

    }

    public T Get<T>() where T : BaseInventoryObject
    {
        Type type = typeof(T);
        T retVal = _inventoryObjects[type] as T ?? throw new InvalidOperationException();
        return retVal;
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