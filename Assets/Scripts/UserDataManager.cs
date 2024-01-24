using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using System.IO;

public class UserDataManager : MonoBehaviour
{
    private static UserDataManager instance;

    [Header("Reference to AuthController")]
    [SerializeField] private AuthController authController;

    // Current user information
    private UserInformation currentUserInfo;

    // Singleton pattern to ensure there's only one instance
    public static UserDataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UserDataManager>();

                if (instance == null)
                {
                    GameObject container = new GameObject("UserDataManager");
                    instance = container.AddComponent<UserDataManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //public void LoadCurrentUserData(string username)
    //{
    //    currentUserInfo = authController.GetUserInfo(username);
    //    Vector3 playerPosition = new Vector3(currentUserInfo.posX, currentUserInfo.posY, 0);
    //    GameObject.FindGameObjectWithTag("Player").transform.position = playerPosition;
    //}
}