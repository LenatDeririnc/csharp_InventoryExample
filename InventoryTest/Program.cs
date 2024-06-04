using InventoryTest.ContainerSystem;
using InventoryTest.InventoryObjects;

namespace InventoryTest;

public class Program
{
    public static void Main(string[] args)
    {
        BaseContainer Table = new BaseContainer();
        BaseContainer Inventory = new BaseContainer();
        
        Table.Add<Amulet>(1);
        Table.Add<Money>(33);
        Table.Add<Book>(1);
        
        Console.WriteLine(Table.PrintInfo());
        Console.WriteLine("---------");
        Console.WriteLine();
        
        ContainerOperations.Move<Money>(Table, Inventory, 33);
        
        Console.WriteLine(Table.PrintInfo());
        Console.WriteLine(Inventory.PrintInfo());
        
        
    }
}