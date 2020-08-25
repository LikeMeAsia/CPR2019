using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace com.dgn.XR.Extensions
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class HideHandAfterGrabbed : MonoBehaviour
    {
        private XRGrabInteractable grabInteractable;

        private HandPresence handPresence;
        private bool recordShowController;
        private bool recordShowHand;

        // Start is called before the first frame update
        void Start()
        {
            grabInteractable = this.GetComponent<XRGrabInteractable>();
            grabInteractable.onSelectEnter.AddListener(OnGrabbed);
            grabInteractable.onSelectExit.AddListener(OnReleased);
        }

        void OnGrabbed(XRBaseInteractor rBaseInteractor)
        {
            HandPresence rHandPresence = rBaseInteractor.GetComponentInChildren<HandPresence>();
            if (!rHandPresence) {
                rHandPresence = rBaseInteractor.attachTransform.GetComponentInChildren<HandPresence>();
            }
            if (rHandPresence)
            {
                if (handPresence && handPresence != rHandPresence)
                {
                    handPresence.showController = recordShowController;
                    handPresence.showHand = recordShowHand;
                }
                handPresence = rHandPresence;
                recordShowController = handPresence.showController;
                recordShowHand = handPresence.showHand;
                handPresence.showController = false;
                handPresence.showHand = false;
            }
        }

        void OnReleased(XRBaseInteractor rBaseInteractor)
        {
            if (handPresence)
            {
                handPresence.showController = recordShowController;
                handPresence.showHand = recordShowHand;
            }
            handPresence = null;
        }

        private void OnDestroy()
        {
            if (grabInteractable)
            {
                grabInteractable.onSelectEnter.RemoveListener(OnGrabbed);
                grabInteractable.onSelectExit.RemoveListener(OnReleased);
            }
        }

    }
}