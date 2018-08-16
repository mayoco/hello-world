using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class NetworkManagerCustom : NetworkManager
{
    void Start()//两秒后自动运行，开始连接网络
    {
        Invoke("LanGame", 2);
    }

    public void LanGame()
    {
        singleton.StartCoroutine((singleton as NetworkManagerCustom).DiscoverNetwork());

    }
    
    public IEnumerator DiscoverNetwork()
    {
        NetworkTransport.Init();
        //监听其它的服务器
        NetworkDiscoveryCustom discovery = GetComponent<NetworkDiscoveryCustom>();
        discovery.Initialize();
        discovery.StartAsClient();


        //等待2秒，等监听结果

        yield return new WaitForSeconds(2);

        //没有找到局域网服务器就建立服务器

        if (discovery.running)

        {
            discovery.StopBroadcast();
            yield return new WaitForSeconds(0.5f);
            discovery.StartAsServer();
            StartHost();
        }

        
    }
}
