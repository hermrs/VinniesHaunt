using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineManager : MonoBehaviour
{
    public static LandmineManager Instance { get; private set; }

    public GameObject landminePrefab;
    private int totalLandmines = 3; // Toplam mayýn sayýsý
    private float interactionCooldown = 2f; // Etkileþim bekleme süresi

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateLandmineUI();
    }

    public void CreateLandmine(Vector3 position)
    {
        if (totalLandmines > 0)
        {
            Instantiate(landminePrefab, position, Quaternion.identity);
            totalLandmines--;
            UpdateLandmineUI();
        }
    }

    public void IncreaseLandmineCount()
    {
        totalLandmines++;
        UpdateLandmineUI();
    }

    public void UpdateLandmineUI()
    {
        GameManager.Instance.UpdateLandmineCount(totalLandmines);
    }

    public IEnumerator CooldownInteraction(Collider collider)
    {
        if (collider == null) yield break;

        collider.enabled = false;
        yield return new WaitForSeconds(interactionCooldown);

        if (collider != null)
        {
            collider.enabled = true;
        }
    }
}
