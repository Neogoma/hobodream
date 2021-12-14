using com.Neogoma.HoboDream.Network;
using UnityEngine;
using UnityEngine.UI;

namespace Neogoma.Hobodream.Examples.Networking
{
    public class TextRequestExample : MonoBehaviour, IJSonRequestListener
    {
        public Text text;


        private IHTTPConnector<IJSonRequestListener> connector;
        private string listenerKey = "key";

        public void Awake()
        {
            connector = NetworkProvider.Instance.GetDefaultHTTPNotifier<IJSonRequestListener>();
            connector.AddRequestListener(listenerKey, this);
            
        }

        public void RunRequest()
        {
            connector.RequestURL("www.perdu.com", listenerKey);
        }

        public void RequestFailed(long code,string jsonResult, string key)
        {
            
        }

        public void RequestSucess(string jsonResult, string key)
        {
            text.text = jsonResult;
        }

    }
}
