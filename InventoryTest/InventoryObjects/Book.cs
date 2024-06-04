namespace InventoryTest.InventoryObjects;

public class Book : BaseInventoryObject
{
    public override string Name => "Ordinary Book";
    public override int MaxContainerCount => 10;
}