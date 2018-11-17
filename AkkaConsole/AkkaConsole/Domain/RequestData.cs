using AkkaConsole.ValueObj;

namespace AkkaConsole.Domain {
    public sealed class RequestData : Data {

        public ActionType ActionType { get; set; }
    }
}
