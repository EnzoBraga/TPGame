using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject panel;
    private int level;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    public void UpdateExperienceSlider(int current, int target){
        slider.maxValue = target;
        slider.value = current;
    }

    public void SetLevelText(int level, List<UpgradesData> upgradesData){
        levelText.text = "Level: " + level.ToString();
        if(this.level < level){
            panel.SetActive(true);
            for (int i = 0; i < upgradesData.Count; i++)
            {
                upgradeButtons[i].Set(upgradesData[i]);
            }
        }
    }
}
