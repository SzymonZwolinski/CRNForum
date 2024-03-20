using Microsoft.AspNetCore.Components;

namespace Platender.Front.Event
{
    public class PasteMultimediaEventArgs : EventArgs
    {
        public bool IsMultimedia { get; set; }
        public string Data { get; set; }
    }

    [EventHandler("onpastemultimedia", typeof(PasteMultimediaEventArgs),
    enableStopPropagation: true, enablePreventDefault: true)]
    public static class EventHandlers
    {

    }
}
