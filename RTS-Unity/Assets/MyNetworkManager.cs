using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Inherits from NetworkManager
/// </summary>
public class MyNetworkManager : NetworkManager {

    /// <summary>
    /// Starts client host.
    /// </summary>
    public void MyStartHost()
    {
        try
        {
            Debug.Log("Starting Host: " + Time.timeSinceLevelLoad);
            this.StartHost();
        }
        catch (Exception e)
        {
            //Intercepts error
            Debug.Log("Client could not be started.");
        }
    }

    /// <summary>
    /// Called after host is started successfully
    /// </summary>
    public override void OnStartHost()
    {
        Debug.Log("Host Started: " + Time.timeSinceLevelLoad);
    }

    /// <summary>
    /// Executed when client start is requested
    /// </summary>
    /// <param name="myClient"></param>
    public override void OnStartClient(NetworkClient myClient)
    {
        Debug.Log("Client start requested: " + Time.timeSinceLevelLoad);
        //Start method to show attempting to connect to client
        InvokeRepeating("PrintDots", 0f, 1f);
    }

    /// <summary>
    /// Executed when client connects to host
    /// </summary>
    /// <param name="conn"></param>
    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Client is IsClientConnected to IP: " + conn.address);
        Debug.Log("Connection ID: " + conn.connectionId);
        //Cancel progress after client is connected to host
        CancelInvoke();
    }

    /// <summary>
    /// Progress report for connecting to client
    /// </summary>
    private void PrintDots()
    {
        Debug.Log(".");
    }
}
