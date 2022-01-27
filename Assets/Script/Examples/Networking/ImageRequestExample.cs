using com.Neogoma.HoboDream.Network;
using com.Neogoma.HoboDream.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Neogoma.Hobodream.Examples.Networking
{
    public class ImageRequestExample : MonoBehaviour,ITextureDownloadListener
    {
        public Image img;
        public string url= "https://neogoma.com/images/logoneogoma.png";

        private IHTTPConnector<ITextureDownloadListener> textureDownloader;
        public static string textureListenerKey = "textureTest";


        // Start is called before the first frame update
        public void Start()
        {
            textureDownloader = NetworkProvider.Instance.GetDefaultHTTPNotifier<ITextureDownloadListener>();
            textureDownloader.AddRequestListener(textureListenerKey, this);
            
        }

        public void RunRequest()
        {

            textureDownloader.RequestURL(url,true, textureListenerKey);

        }

        public void RequestFailed(long code,string data,string jsonResult, string key)
        {
            
        }

        public void TextureLoaded(string listenerKey, Texture2D texture)
        {
            var sprite = ImageHelper.CreateSpriteFromTexture(texture);
            img.overrideSprite = sprite;
        }

    }
}