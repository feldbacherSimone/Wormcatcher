using UnityEngine;
using Yarn.Compiler;

namespace _Wormcatcher.Scripts.Interaction
{
    public class ClothesSwitcher : ModelSwitcher
    {
        [SerializeField] private HangClothes hangClothes;
        [SerializeField] private Clothing clothingItem;

        protected override void Awake()
        {
            foreach (GameObject obj in OnObjects)
            {
                obj.SetActive(false);
            }
        }
        protected override void SwitchObjects(bool switchOn)
        {
            switchOn = true;
            foreach (GameObject obj in OnObjects)
            {
                obj.SetActive(switchOn);
            }
            DebugPrint("Objects toggled to " + isOn);
            hangClothes.HangItem(clothingItem);
            Active = false;
        }
    }
}