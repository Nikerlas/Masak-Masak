using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingStation : MonoBehaviour
{
    public CookableIngredient ingredientData;
    public GameObject spawnedIngredient;
    public Slider progressBar;
    public Image panImage;
    public Plate plate;

    private float timer = 0f;
    private bool isCooking = false;
    private bool isCooked = false;
    private bool isBurnt = false;

    void Update()
    {
        if (!isCooking) return;
        timer += Time.deltaTime;
        float totalBurnTime = ingredientData.cookingTime + ingredientData.graceTime;

        progressBar.value = Mathf.Min(timer / totalBurnTime, 1f);

        if (!isCooked && timer >= ingredientData.cookingTime)
        {
            isCooked = true;
            Debug.Log($"{ingredientData.ingredientName} is cooked!");
        }

        if (!isBurnt && timer >= totalBurnTime)
        {
            isBurnt = true;
            isCooking = false;
            Debug.Log($"{ingredientData.ingredientName} is burnt!");
        }
    }

    public void StartCooking()
    {
        if (isCooking) return;

        if(spawnedIngredient != null) Destroy(spawnedIngredient);

        spawnedIngredient = Instantiate(ingredientData.cookedPrefab, panImage.transform);
spawnedIngredient.transform.localPosition = Vector3.zero;
spawnedIngredient.transform.localScale = Vector3.one;

if (spawnedIngredient != null)
    Debug.Log($"Spawned {spawnedIngredient.name} at {spawnedIngredient.transform.position}");
else
    Debug.LogWarning("Tempeh prefab failed to instantiate!");

        timer = 0f;
        isCooking = true;
        isCooked = false;
        isBurnt = false;
        progressBar.value = 0f;

        Debug.Log($"Started cooking {ingredientData.ingredientName}.");
    }

    public void TakeIngredient()
    {
        if (!isCooking) return;

        isCooking = false;

        GameObject prefabToAdd;
        string nameToAdd;

        if (isBurnt)
        {
            prefabToAdd = ingredientData.burntPrefab;
            nameToAdd = "Burnt" + ingredientData.ingredientName;
            Debug.Log($"{ingredientData.ingredientName} is burnt and cannot be served.");
        }
        else if (isCooked)
        {
            prefabToAdd = ingredientData.cookedPrefab;
            nameToAdd = ingredientData.ingredientName;
            Debug.Log($"{ingredientData.ingredientName} is cooked and ready to serve.");
        }
        else
        {
            prefabToAdd = ingredientData.cookedPrefab;
            nameToAdd = ingredientData.ingredientName;
            Debug.Log($"{ingredientData.ingredientName} is still raw.");
        }



        plate.AddIngredient(prefabToAdd, nameToAdd);
        timer = 0f;
        isCooked = false;
        isBurnt = false;

        progressBar.value = 0f;
    }
}
