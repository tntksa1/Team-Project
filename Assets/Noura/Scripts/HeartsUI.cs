using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeartsUI : MonoBehaviour
{
    [SerializeField] HealthSystem target;
    [SerializeField] HeartIcon heartPrefab;      // Prefab فيه Image + HeartIcon
    [SerializeField] RectTransform container;    // HUD Health 

    readonly List<HeartIcon> hearts = new();

    void Awake()
    {
        if (!container) container = (RectTransform)transform;
        if (!target) target = FindFirstObjectByType<HealthSystem>(); 
    }

    void OnEnable() { if (target) target.onHealthChanged += Refresh; }
    void OnDisable() { if (target) target.onHealthChanged -= Refresh; }

    void Start()
    {
        Build();
        if (target) Refresh(target.CurrentHealth, target.MaxHealth);
    }

    public void Build()
    {
        if (!heartPrefab || !container) return;

        // تنظيف
        for (int i = container.childCount - 1; i >= 0; i--)
            Destroy(container.GetChild(i).gameObject);
        hearts.Clear();

        int count = target ? target.maxHearts : 5;

        for (int i = 0; i < count; i++)
        {
            var go = Instantiate(heartPrefab.gameObject, container);
            var hi = go.GetComponent<HeartIcon>();
            if (!hi) hi = go.AddComponent<HeartIcon>();

            var img = go.GetComponent<Image>();
            if (img) img.preserveAspect = true;

            hearts.Add(hi);
        }

        
        var grid = container.GetComponent<GridLayoutGroup>();
        if (grid != null)
        {
            int cols = hearts.Count; // صف واحد أفقي
            float width = cols * grid.cellSize.x
                         + Mathf.Max(0, cols - 1) * grid.spacing.x
                         + grid.padding.left + grid.padding.right;

            float height = grid.cellSize.y
                         + grid.padding.top + grid.padding.bottom;

            container.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            container.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(container);
    }

    void Refresh(int current, int max)
    {
        if (!target || hearts.Count == 0 || max == 0) return;

        int perHeart = target.healthPerHeart;
        for (int i = 0; i < hearts.Count; i++)
        {
            int min = i * perHeart;
            int amount = Mathf.Clamp(current - min, 0, perHeart);
            float fraction = (float)amount / perHeart; // 1, 0.5, 0
            hearts[i].SetState(fraction);
        }
    }
}
