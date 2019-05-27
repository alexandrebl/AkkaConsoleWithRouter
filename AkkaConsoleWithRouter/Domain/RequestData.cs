using AkkaConsole.ValueObj;

namespace AkkaConsole.Domain {
    public sealed class RequestData : Data {

        public ActionType ActionType { get; }

        public RequestData(ActionType actionType, int valueA, int valueB) : base(valueA, valueB)
        {
            ActionType = actionType;
        }
    }
}
