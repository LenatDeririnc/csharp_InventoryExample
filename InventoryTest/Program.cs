using InventoryTest.ContainerSystem;
using InventoryTest.InventoryObjects;

namespace InventoryTest;

public class Program
{
    public static void Main(string[] args)
    {
        BaseContainer Table = new BaseContainer();
        BaseContainer Inventory = new BaseContainer();
        
        Table.Add<Amulet>(1, out _);
        Table.Add<Money>(33, out _);
        Table.Add<Book>(1, out _);
        
        Console.WriteLine(Table.PrintInfo());
        Console.WriteLine("---------");
        Console.WriteLine();
        
        ContainerOperations.Move<Money>(ref Table, ref Inventory, 33);
        
        Console.WriteLine(Table.PrintInfo());
        Console.WriteLine(Inventory.PrintInfo());
        
        
    }
}