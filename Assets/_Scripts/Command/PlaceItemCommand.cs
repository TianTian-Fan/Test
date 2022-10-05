using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItemCommand : ICommand
{
    Vector3 position;
    Transform item;

    public PlaceItemCommand(Vector3 position, Transform item)
    {
        this.position = position;
        this.item = item;
    }
    // Start is called before the first frame update
    public void Execute()
    {
        ItemPlacer.PlaceItem(item);
    }

    // Update is called once per frame
    public void Undo()
    {
        ItemPlacer.RemoveItem(item.position);
    }
}
