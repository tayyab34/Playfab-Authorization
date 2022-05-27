using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayfabManager : MonoBehaviour
{
    public TextMeshProUGUI message;
    public TMP_InputField email;
    public TMP_InputField password;

    public void Register()
    {
        if (password.text.Length < 6)
        {
            message.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest{
            Email = email.text,
            Password = password.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        message.text = "Registration Successful!";
    }
    void OnError(PlayFabError error)
    {
        message.text = error.ErrorMessage;
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email.text,
            Password = password.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {
        message.text = "Login Successful!";
    }

    public void ResetPass()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = email.text,
            TitleId= "23735"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    private void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        message.text = "Password reset mail sent";
    }
}
