using com.Neogoma.HoboDream.Network;
using com.Neogoma.HoboDream.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Neogoma.Hobodream.Examples.BasicInteractive
{
    public class ImageRequestExample : MonoBehaviour,ITextureDownloadListener
    {
        public Image img;


        private IHTTPConnector<string, ITextureDownloadListener> textureDownloader;
        public static string textureListenerKey = "textureTest";


        // Start is called before the first frame update
        public void Start()
        {
            textureDownloader = NetworkProvider.Instance.GetDefaultHTTPNotifier<ITextureDownloadListener>();
            textureDownloader.AddRequestListener(textureListenerKey, this);
            
        }

        public void RunRequest()
        {

            textureDownloader.RequestURL("https://www.coolhobo.com/images/photo/k0Ps4kdvJ8yU3muwQrR6ZO3m4OUPrvuxO7CGaqZL.jpeg", textureListenerKey);

        }

        public void RequestFailed(string jsonResult, string key)
        {
            
        }

        public void TextureLoaded(string listenerKey, Texture2D texture)
        {
            var sprite = ImageHelper.CreateSpriteFromTexture(texture);
            img.overrideSprite = sprite;
        }

    }
}