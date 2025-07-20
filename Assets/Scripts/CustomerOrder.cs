using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public List<string> requiredIngredients = new List<string>();

    void Start()
    {
        requiredIngredients.Add("Rice");
        requiredIngredients.Add("Tofu");
        requiredIngredients.Add("Tempeh");
    }
}
