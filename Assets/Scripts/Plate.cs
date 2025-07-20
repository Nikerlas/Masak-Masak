using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public List<Transform> slots;
    public List<string> currentIngredients = new List<string>();

    public void AddIngredient(GameObject ingredientPrefab, string name)
    {
        if (currentIngredients.Contains(name)) return;

        currentIngredients.Add(name);
        int index = currentIngredients.Count - 1;

        GameObject obj = Instantiate(ingredientPrefab, slots[index].position, Quaternion.identity);
        obj.transform.SetParent(slots[index], false);
    }

    public bool isOrderCorrect(List<string> request)
    {
        return currentIngredients.OrderBy(x => x).SequenceEqual(request.OrderBy(x => x));
    }
}
