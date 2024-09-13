using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class controller : MonoBehaviour
{
    public Texture2D imgskill1, imgskill2, imgskill3, imgnone;
    public RawImage rawslot1, rawslot2, rawslot3;
    private List<int> listIdSkill;
    public bool isupdateusedskill;
    public int idskillupdate;
    // Start is called before the first frame update
    void Start()
    {
        listIdSkill = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if(listIdSkill.Count > 0)
        {
            for (int i = 0; i < listIdSkill.Count; i++)
            {
                if (i == 0 && listIdSkill[i] == 1)
                {
                    rawslot1.texture = imgskill1;
                } else if (i == 0 && listIdSkill[i] == 2)
                {
                    rawslot1.texture = imgskill2;
                } else if (i == 0 && listIdSkill[i] == 3)
                {
                    rawslot1.texture = imgskill3;
                }
                if(i == 1 && listIdSkill[i] == 1)
                {
                    rawslot2.texture = imgskill1;
                }
                else if (i == 1 && listIdSkill[i] == 2)
                {
                    rawslot2.texture = imgskill2;
                }
                else if (i == 1 && listIdSkill[i] == 3)
                {
                    rawslot2.texture = imgskill3;
                }
                if (i == 2 && listIdSkill[i] == 1)
                {
                    rawslot3.texture = imgskill1;
                }
                else if (i == 2 && listIdSkill[i] == 2)
                {
                    rawslot3.texture = imgskill2;
                }
                else if (i == 2 && listIdSkill[i] == 3)
                {
                    rawslot3.texture = imgskill3;
                }
            }
            if(listIdSkill.Count == 1)
            {
                rawslot2.texture = imgnone;
                rawslot3.texture = imgnone;
            } else if (listIdSkill.Count == 2)
            {
                rawslot3.texture = imgnone;
            }
        }
        else
        {
            rawslot1.texture = imgnone;
            rawslot2.texture = imgnone;
            rawslot3.texture = imgnone;
        }
        if (isupdateusedskill)
        {
            bool isused = false;
            int indexremove = 0;
            for (int i = 0; i < listIdSkill.Count; i++)
            {
                if (listIdSkill[i] == idskillupdate)
                {
                    isused = true;
                    indexremove = i;
                }
            }
            if (isused)
            {
                Debug.Log(indexremove + "indexremove");
                listIdSkill.RemoveAt(indexremove);
            }
            else
            {
                listIdSkill.Add(idskillupdate);
            }
            idskillupdate = 0;
            isupdateusedskill = false;
        }
    }
}
