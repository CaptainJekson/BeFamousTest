using System;

[Serializable]
public class ChestProtocol
{
    public string chest;
    public ChestItem[] chest_items;
}

[Serializable]
public class ChestItem
{
    public string type;
    public string slottype;
    public string rarity;
    public int level;
    public int level_wmin;
    public string itemkey;
    public int value;
}