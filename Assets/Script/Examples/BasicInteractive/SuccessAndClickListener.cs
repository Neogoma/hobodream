using com.Neogoma.HoboDream;
using UnityEngine;
using UnityEngine.UI;

namespace Neogoma.Hobodream.Examples.BasicInteractive
{
    public class SuccessAndClickListener : MonoBehaviour, IInteractiveElementListener
    {
        public Text successAndClickListenerText;

        private InteractiveEventAction[] actions = new InteractiveEventAction[] { InteractiveEventAction.SUCCESS, InteractiveEventAction.CLICK };

        public InteractiveEventAction[] GetSupportedEvents()
        {
            return actions;
        }

        public void HandleEvent(IInteractionEvent e)
        {
            if (e.GetEventType() == InteractiveEventAction.CLICK)
            {
                successAndClickListenerText.text = "Click happened";
            }else if (e.GetEventType() == InteractiveEventAction.SUCCESS)
            {
                successAndClickListenerText.text = "Success happened";
            }
        }
    }
}
