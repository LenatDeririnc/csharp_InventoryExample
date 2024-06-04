namespace InventoryTest.InventoryObjects;

public class Money : BaseInventoryObject
{
    public override string Name => "Money";
    public override int MaxContainerCount => int.MaxValue; //why not lmao
}