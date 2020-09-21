using com.Neogoma.HoboDream;
using UnityEngine;
using UnityEngine.UI;

namespace Neogoma.Hobodream.Examples.BasicInteractive
{

    public class SuccessListener : MonoBehaviour, IInteractiveElementListener
    {
        public Text successListenerText;


        private InteractiveEventAction[] actions = new InteractiveEventAction[] { InteractiveEventAction.SUCCESS };

        public InteractiveEventAction[] GetSupportedEvents()
        {
            return actions;
        }

        public void HandleEvent(IInteractionEvent e)
        {

            successListenerText.text = "Success happened";
        }
    }
}
