using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Repair_Btn : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public int btn_id;
    public bool btn_active;

    public void onClick()
    {
        btn_active = btn_active ? false : true;

        Repair repair = RepairSystem.repairs[btn_id];
        RepairSystem.UI_Repairs[repair] = btn_active;
        SoundSystem.instance.PlaySoundEffect(0);
    }

    private void Update()
    {
        if (btn_active)
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.gray;
        }
    }
}
