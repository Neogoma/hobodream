using com.Neogoma.HoboDream;
using com.Neogoma.HoboDream.Impl;
using UnityEngine;

namespace Neogoma.Hobodream.Examples.BasicInteractive
{
    public class BasicInteractive : AbstractInteractive
    {
        private IInteractionEvent sucessEvent;
        private IInteractionEvent clickEvent;

        public SuccessAndClickListener successAndClickListener;

        public SuccessListener sucessListener;

        protected override void DoOnAwake()
        {
            sucessEvent = new BaseInteractionEvent(this, InteractiveEventAction.SUCCESS);
            clickEvent = new BaseInteractionEvent(this, InteractiveEventAction.CLICK);

            AddInteractiveListener(sucessListener);
            AddInteractiveListener(successAndClickListener);
        }


        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                NotifyListeners(sucessEvent);
            }

            if (Input.GetKeyUp(KeyCode.C))
            {
                NotifyListeners(clickEvent);
            }
        }

        protected override void DoOnDestroy()
        {
            //
        }
    }
}
