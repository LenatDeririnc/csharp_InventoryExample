namespace InventoryTest.InventoryObjects;

public abstract class BaseInventoryObject
{
    public abstract string Name { get; }
    public abstract int MaxContainerCount { get; }

    private int m_count = 0;
    
    public int Count
    {
        get => m_count;
        set
        {
            if (value > MaxContainerCount) {
                Console.WriteLine($"[WARNING] inventory object \"{Name}\" can't contain more than {MaxContainerCount} elements on a row");
            }

            if (value < 0) {
                Console.WriteLine($"[WARNING] inventory object \"{Name}\" can't be less than 0 elements");
            }
            
            m_count = Math.Clamp(value, 0, MaxContainerCount);
        }
    }

    // ... other properties
}