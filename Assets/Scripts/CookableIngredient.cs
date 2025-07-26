using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CookableIngredient", menuName = "Cooking/CookableIngredient")]
public class CookableIngredient : ScriptableObject
{
    public string ingredientName;
    public float cookingTime = 3f; 
    public float graceTime = 2f; 
    public GameObject cookedPrefab; 
    public GameObject burntPrefab; 
}