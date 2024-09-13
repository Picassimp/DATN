using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class playscript : MonoBehaviour

{
    public Text textUsed1, textUsed2, textUsed3, textUsed4;
    public int lvskill1 = 0, lvskill2 = 0, lvskill3 = 0, lvskill4 = 0;
    public GameObject gbSkill1, gbSkill2, gbSkill3, gbSkill4, gbbuy1, gbbuy2, gbbuy3, gbbuy4;
    public List<Image> listGameObjectLVSkill1, listGameObjectLVSkill2, listGameObjectLVSkill3, listGameObjectLVSkill4;
    public Text textCoinInSkill;
    public GameObject panelLV,panelInformation, panelSkill;
    private string map;
    private string currentSceneName;
    private string mapInt;
    public GameObject panelshop, panelmenu, panelsetting;
    public GameObject player;
    private bool nishavecharacter1, nishavecharacter2, nishavecharacter3, isUsedCharacter1, isUsedCharacter2, isUsedCharacter3;
    public Text textbtnmua1, textbtnmua2, textbtnmua3, textsumcoint;
    private int coint;
    public Slider amthanhslider;
    public GameObject MainCamera;
    private int countskill = 0;
    //if true thi hien thi trong game
    private bool isusedSkill1 = false, isusedSkill2 = false, isusedSkill3 = false, isusedSkill4 = false;


    //shop skill
    public GameObject shopSkillPanel;
    // Start is called before the first frame update
    void Start()
    {
        // lưu game theo tên
       map = "Map test"; // lấy từ api xuống  
       currentSceneName = SceneManager.GetActiveScene().name;// lưu lên api
       amthanhslider.onValueChanged.AddListener(OnSliderValueChanged);
        
    }

    // Update is called once per frame
    void Update()
    {
        /*updateBtnUsed();
        onUpdateSkillLv();
        if (lvskill1 == 0)
        {
            gbbuy1.SetActive(true);
            gbSkill1.SetActive(false);
        } else
        {
            gbbuy1.SetActive(false);
            gbSkill1.SetActive(true);
        }
        if (lvskill2 == 0)
        {
            gbbuy2.SetActive(true);
            gbSkill2.SetActive(false);
        }
        else
        {
            gbbuy2.SetActive(false);
            gbSkill2.SetActive(true);
        }
        if (lvskill3 == 0)
        {
            gbbuy3.SetActive(true);
            gbSkill3.SetActive(false);
        }
        else
        {
            gbbuy3.SetActive(false);
            gbSkill3.SetActive(true);
        }
        if (lvskill4 == 0)
        {
            gbbuy4.SetActive(true);
            gbSkill4.SetActive(false);
        }
        else
        {
            gbbuy4.SetActive(false);
            gbSkill4.SetActive(true);
        }
        
        //khi bam m thi mo menu
        if (Input.GetKeyDown(KeyCode.M))
        { 
            onOpenMenu();
        }
        nishavecharacter1 = player.GetComponent<Mainplayer1>().ishavacharacter1;
        nishavecharacter2 = player.GetComponent<Mainplayer1>().ishavacharacter2;
        nishavecharacter3 = player.GetComponent<Mainplayer1>().ishavacharacter3;
        isUsedCharacter1 = player.GetComponent<Mainplayer1>().isUsedCharacter1;
        isUsedCharacter2 = player.GetComponent<Mainplayer1>().isUsedCharacter2;
        isUsedCharacter3 = player.GetComponent<Mainplayer1>().isUsedCharacter3;
        coint = player.GetComponent<Mainplayer1>().coint;
        if (nishavecharacter1)
        {
            if(isUsedCharacter1)
            {
                textbtnmua1.text = "Đang Dùng";
            } else
            {
                textbtnmua1.text = "Dùng";
            }
            
        }
        else
        {
            textbtnmua1.text = "Mua";
        }
        if (nishavecharacter2)
        {
            if (isUsedCharacter2)
            {
                textbtnmua2.text = "Đang Dùng";
            }
            else
            {
                textbtnmua2.text = "Dùng";
            }
        }
        else
        {
            textbtnmua2.text = "Mua";
        }
        if (nishavecharacter3)
        {
            if (isUsedCharacter3)
            {
                textbtnmua3.text = "Đang Dùng";
            }
            else
            {
                textbtnmua3.text = "Dùng";
            }
        }
        else
        {
            textbtnmua3.text = "Mua";
        }*/
        

    }
    private void onUpdateSkillLv()
    {
        for (int i = 0; i <lvskill1; i++)
        {
            listGameObjectLVSkill1[i].gameObject.SetActive(true);
        }
        for (int i = 0; i <lvskill2; i++)
        {
            listGameObjectLVSkill2[i].gameObject.SetActive(true);
        }
        for (int i = 0; i <lvskill3; i++)
        {
            listGameObjectLVSkill3[i].gameObject.SetActive(true);
        }
        for (int i = 0; i <lvskill4; i++)
        {
            listGameObjectLVSkill4[i].gameObject.SetActive(true);
        }
    }
    public void onOpenInformation()
    {
        panelInformation.SetActive(true);
    }
    public void onQuitInformation()
    {
        panelInformation.SetActive(false);
    }
    public void btnstart()
    {
        panelLV.SetActive(true);
        // SceneManager.LoadScene(map);
    }
    public void onClouseChondokho()
    {
        panelLV.SetActive(false);
    }
    public void onOpenSkill()
    {
        textCoinInSkill.text = coint + "";
        panelSkill.SetActive(true);
    }
    public void onQuitSkill()
    {
        panelSkill.SetActive(false);
    }
    public void onKho()
    {
        GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().difficulty = 2;        
        GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().status = 0;       
        GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().stage = 1;       
       
        GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().startTimer();
        SceneManager.LoadScene(map);
        //che do kho
    }
    public void onDe()
    {
        GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().difficulty = 1;
        GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().status = 0;
        GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().stage = 1;
        GameObject.FindGameObjectWithTag("Data").GetComponent<dataHolder>().startTimer();
        SceneManager.LoadScene(map);
        //che do don gian
    }
    public void btnsave() {
        currentSceneName = SceneManager.GetActiveScene().name;
    }
    public void btnshopgame()
    {
        panelshop.SetActive(true);
        textsumcoint.text = coint + "";

    }
    void OnSliderValueChanged(float value)
    {
        MainCamera.GetComponent<AudioSource>().volume = value;
    }
    public void onclickbtn1()
    {
        if(!nishavecharacter1)
        {
            coint = coint - 1000;
            player.GetComponent<Mainplayer1>().coint  = coint;
            textsumcoint.text = coint + "";
            player.GetComponent<Mainplayer1>().ishavacharacter1 = true;

        } else
        {
            if (isUsedCharacter1)
            {
                
            }
            else
            {
                player.GetComponent<Mainplayer1>().isUsedCharacter2 = false;
                player.GetComponent<Mainplayer1>().isUsedCharacter3 = false;
                player.GetComponent<Mainplayer1>().isUsedCharacter1 = true;
            }
        }
    }
    public void onclickbtn2()
    {
        if (!nishavecharacter2)
        {
            coint = coint - 1000;
            player.GetComponent<Mainplayer1>().coint = coint;
            player.GetComponent<Mainplayer1>().ishavacharacter2 = true;
            textsumcoint.text = coint + "";

        }
        else
        {
            if (isUsedCharacter2)
            {

            }
            else
            {
                player.GetComponent<Mainplayer1>().isUsedCharacter2 = true;
                player.GetComponent<Mainplayer1>().isUsedCharacter3 = false;
                player.GetComponent<Mainplayer1>().isUsedCharacter1 = false;
            }
        }
    }
    public void onclickbtn3()
    {
        if (!nishavecharacter3)
        {
            coint = coint - 1000;
            player.GetComponent<Mainplayer1>().coint = coint;
            player.GetComponent<Mainplayer1>().ishavacharacter3 = true;
            textsumcoint.text = coint + "";

        }
        else
        {
            if (isUsedCharacter3)
            {

            }
            else
            {
                player.GetComponent<Mainplayer1>().isUsedCharacter2 = false;
                player.GetComponent<Mainplayer1>().isUsedCharacter3 = true;
                player.GetComponent<Mainplayer1>().isUsedCharacter1 = false;
            }
        }
    }
    public void onquitshop()
    {
        panelshop.SetActive(false);
    }
    public void onOpenMenu()
    {
        //tam dung game
        Time.timeScale = 0;
        panelmenu.SetActive(true);
    }
    public void onCloseMenu() {
        //tiep tuc game
        Time.timeScale = 1;
        panelmenu.SetActive(false);
    }
    public void onQuitGame()
    {
        Application.Quit();
    }
    public void onOpenpanelSetting()
    {
        panelsetting.SetActive(true);

    }
    public void onClosepanelSetting()
    {
        panelsetting.SetActive(false);
    }
    public void onMuaSkill1()
    {
        if(coint>100)
        {
            coint -=100;
            lvskill1 += 1;
        }
    }
    public void onMuaSkill2()
    {
        if (coint > 100)
        {
            coint -= 100;
            lvskill2 += 1;
        }
    }
    public void onMuaSkill3()
    {
        if (coint > 100)
        {
            coint -= 100;
            lvskill3 += 1;
        }
    }
    public void onMuaSkill4()
    {
        if (coint > 100)
        {
            coint -= 100;
            lvskill4 += 1;
        }
    }
    public void onNangSkill1()
    {
        if(lvskill1 != 10)
        {
            lvskill1 += 1;
            coint -= 100;
        }
    }
    public void onNangSkill2()
    {
        if (lvskill2 != 10)
        {
            lvskill2 += 1;
            coint -= 100;
        }
    }
    public void onNangSkill3()
    {
        if (lvskill3 != 10)
        {
            lvskill3 += 1;
            coint -= 100;
        }
    }
    public void onNangSkill4()
    {
        if (lvskill4 != 10)
        {
            lvskill4 += 1;
            coint -= 100;
        }
    }
    public void changeSkill1()
    {
        if(isusedSkill1)
        {
            isusedSkill1 = false;
        } else
        {
            isusedSkill1 = true;
            onChangeSkill(1);
        }
    }
    public void changeSkill2()
    {
        if (isusedSkill2)
        {
            isusedSkill2 = false;
        }
        else
        {
            isusedSkill2 = true;
            onChangeSkill(2);
        }
    }
    public void changeSkill3()
    {
        if (isusedSkill3)
        {
            isusedSkill3 = false;
        }
        else
        {
            isusedSkill3 = true;
            onChangeSkill(3);
        }
    }
    public void changeSkill4()
    {
        if (isusedSkill4)
        {
            isusedSkill4 = false;
        }
        else
        {
            isusedSkill4 = true;
            onChangeSkill(4);
        }
    }
    private void onChangeSkill(int index)
    {
        if (countskill == 3)
        {
            if(isusedSkill1)
            {
                isusedSkill1 = false;
            } else
            {
                isusedSkill1 = true;
                if (isusedSkill2)
                {
                    isusedSkill2 = false;
                }
                else
                {
                    isusedSkill2 = true;
                    if (isusedSkill3)
                    {
                        isusedSkill3 = false;
                    }
                    else
                    {
                        isusedSkill3 = true;
                        if (isusedSkill4)
                        {
                            isusedSkill4 = false;
                        }
                        else
                        {
                            isusedSkill4 = true;
                        }
                    }
                }
            }
        } else
        {
            countskill += 1;
        }
    }
    private void updateBtnUsed()
    {
        /*if (isusedSkill1)
        {
            textUsed1.text = "Nghỉ";
        }
        else
        {
            textUsed1.text = "Dùng";
        }
        if (isusedSkill2)
        {
            textUsed2.text = "Nghỉ";
        }
        else
        {
            textUsed2.text = "Dùng";
        }
        if (isusedSkill3)
        {
            textUsed3.text = "Nghỉ";
        }
        else
        {
            textUsed3.text = "Dùng";
        }
        if (isusedSkill4)
        {
            textUsed4.text = "Nghỉ";
        }
        else
        {
            textUsed4.text = "Dùng";
        }*/

    }

    public void openShopSkill(){
        shopSkillPanel.SetActive(true);
    }

    public void closeShopSkill(){
        shopSkillPanel.SetActive(false);
    }
}
