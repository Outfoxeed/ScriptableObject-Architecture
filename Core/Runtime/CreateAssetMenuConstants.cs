namespace ScriptableObjectArchitecture
{
    public static class CreateAssetMenuConstants
    {
        public const string BasePath = "SO Arch/";
        public const string ConstantsPath = BasePath + "Constants/";
        public const string VariablesPath = BasePath + "Variables/";
        public const string GameEventsPath = BasePath + "Game Events/";
    }

    public static class AddComponentMenuConstants
    {
        public const string BasePath = "SO Arch/";
        public const string ListenersFolder = "Listeners/";
        public const string GameEventListenersPath = BasePath + ListenersFolder + "Game Events/";
        public const string ReferenceListenersPath = BasePath + ListenersFolder + "References/";
    }
}