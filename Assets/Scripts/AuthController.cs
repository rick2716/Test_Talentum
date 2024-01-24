using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UserInformation
{
    [Header("User")]
    public string user;
    public string password;

    [Header("Position")]
    public float posX;
    public float posY;

    [Header("Inventory")]
    public InventorySlot[] inventorySlots;
    public InventoryPlayerSlot playerSlot;

    public static UserInformation GetUserInfo(List<UserInformation> userInfoList, string userName)
    {
        return userInfoList.Find(user => user.user == userName);
    }
}

// wrapper class para que jsonutility pueda serializar
[System.Serializable]
public class UserInformationList
{
    public List<UserInformation> userInfoList = new List<UserInformation>();

    public void SaveUserInfo(string filepath)
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(filepath, json);
    }
}

public class AuthController : MonoBehaviour
{

    //[SerializeField] private UserInformation userInfo;
    [Header("Sections")]
    [SerializeField] private GameObject panelLogIn;
    [SerializeField] private GameObject panelRegister;

    [Header("Inputs Log In")]
    [SerializeField] private TMP_InputField inputUserLG;
    [SerializeField] private TMP_InputField inputPassLG;

    [Header("Inputs Register")]
    [SerializeField] private TMP_InputField inputUserR;
    [SerializeField] private TMP_InputField inputPassR;
    [SerializeField] private TMP_InputField inputPassConfirmedR;

    private UserInformationList userInfoListWrapper = new UserInformationList();
    private string filePath;
    private bool isAuthenticated;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/userInfo.json";
        Debug.Log("json file: " +  filePath);
        LoadJsonFile();
    }

    void LoadJsonFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            userInfoListWrapper = JsonUtility.FromJson<UserInformationList>(json);
            
            if (userInfoListWrapper == null)
            {
                userInfoListWrapper = new UserInformationList();
            }
            Debug.Log("Si hay archivo");
        }
        else
        {
            userInfoListWrapper = new UserInformationList();
            Debug.Log("no hay pero lo creo");
        }
    }

    public void SaveRegisterInfo()
    {
        if (inputPassR.text == inputPassConfirmedR.text)
        {
            UserInformation newUser = new UserInformation
            {
                user = inputUserR.text,
                password = inputPassR.text,
                posX = -6.0f,
                posY = -2.0f
            };

            userInfoListWrapper.userInfoList.Add(newUser);

            string json = JsonUtility.ToJson(userInfoListWrapper);
            File.WriteAllText(filePath, json);

            Debug.Log("Registrado " + inputUserR.text + " " + inputPassR.text);
        }
        else
        {
            Debug.Log("No coinciden");
        }
        
    }

    //public UserInformation GetUserInfo(string username)
    //{
    //    return UserInformation.GetUserInfo(userInfoListWrapper.userInfoList, username);
    //}

    //public void SaveUserData(UserInformation currentUserInfo)
    //{
    //    int index = userInfoListWrapper.userInfoList.FindIndex(user => user.user == currentUserInfo.user);

    //    if (index != -1)
    //    {
    //        userInfoListWrapper.userInfoList[index] = currentUserInfo;
    //        userInfoListWrapper.SaveUserInfo(filePath);
    //        Debug.Log("Se guardo " + currentUserInfo.user);
    //    }
    //}

        public void AuthLogIn()
    {
        string user = inputUserLG.text;
        string password = inputPassLG.text;

        foreach (var info in userInfoListWrapper.userInfoList)
        {
            if (info.user == user && info.password == password)
            {
                isAuthenticated = true;
                break;
            }
        }

        if (isAuthenticated)
        {
            Debug.Log("Pasa a jugar");
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("No pasa");
        }
    }

    public void EnterRegister()
    {
        panelLogIn.SetActive(false);
        panelRegister.SetActive(true);
    }

    public void EnterLogIn()
    {
        LoadJsonFile();
        panelLogIn.SetActive(true);
        panelRegister.SetActive(false);
    }
}
