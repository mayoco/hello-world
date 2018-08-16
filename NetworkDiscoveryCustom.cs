using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkDiscoveryCustom : NetworkDiscovery
{
    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        StopBroadcast();
        NetworkManagerCustom.singleton.networkAddress = fromAddress;
        NetworkManagerCustom.singleton.StartClient();
    }
}
