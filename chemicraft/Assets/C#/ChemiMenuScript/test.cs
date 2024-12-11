using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class MixingSytem : MonoBehaviour
{
    public ItemData itemtype;

    [SerializeField] private SpriteRenderer bottlesprite;
    [SerializeField] private Inventory Inventory;

    // alle objecter starter med color hvid. 
    private Color currentColor = Color.white;

    public void MixItems()
    {
        if (Inventory == null || Inventory.items.Count == 0)
        {
            Debug.Log("inventroy er tomt eller ikke tilsluttet");
            return;
        }
        //reset color
        currentColor = Color.white;
        foreach (var item in Inventory.items)
        {
            if (item.name != null && item.items.Count > 0)
            {
                foreach (var item2 in item.items)
                {
                    //currentColor = Color.Lerp(currentColor, GetItemColor(subItem), 0.5f);
                }
            }
            else
            {
               //currentColor = Color.Lerp(currentColor, GetItemColor(SubItem), 0.5f);
            }
        }

       

    }
    public void GetItemColor(ItemData item)
    {

    }

}
