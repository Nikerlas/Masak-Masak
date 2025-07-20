using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeButton : MonoBehaviour
{
    public Plate plate;
    public CustomerOrder order;

    public void OnClickServe()
    {
        if (plate.isOrderCorrect(order.requiredIngredients))
        {
            Debug.Log("Order served correctly!");
            // Additional logic for serving the order can be added here
        }
        else
        {
            Debug.Log("Order is incorrect. Please check the ingredients.");
        }
    }
}
