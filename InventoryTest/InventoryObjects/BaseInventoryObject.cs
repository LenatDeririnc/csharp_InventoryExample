namespace InventoryTest.InventoryObjects;

public abstract class BaseInventoryObject
{
    public abstract string Name { get; }
    public abstract int MaxContainerCount { get; }
    
    public Action<int> OnCountChange { get; set; }

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
            
            int prevValue = m_count;
            
            m_count = Math.Clamp(value, 0, MaxContainerCount);

            if (prevValue != m_count) {
                OnCountChange?.Invoke(m_count);
            }
        }
    }

    // ... other properties
}