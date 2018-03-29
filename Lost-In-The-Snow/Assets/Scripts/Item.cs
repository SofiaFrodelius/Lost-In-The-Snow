using UnityEngine;

public class Item : MonoBehaviour
{
    private int id;
    private string name;
    private int itemAmmount;

    public Item(int tID, string tName)
    {
        id = tID;
        name = tName;
    }
}
