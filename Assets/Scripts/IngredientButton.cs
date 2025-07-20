using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientButton : MonoBehaviour
{
    public Plate plate;
    public GameObject ingredientPrefab;
    public string ingredientName;

    public void OnClickAddIngredient()
    {
        plate.AddIngredient(ingredientPrefab, ingredientName);
    }
}
