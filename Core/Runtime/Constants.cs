namespace ScriptableObjectArchitecture
{
    public static class CreateAssetMenuConstants
    {
        public const string BasePath = "SO Arch/";
        public const string ConstantsPath = BasePath + "Constants/";
        public const string VariablesPath = BasePath + "Variables/";
        public const string GameEventsPath = BasePath + "Game Events/";

        public const string RuntimeSetsFolder = "Runtime Sets/";
        public const string ValueRuntimeSetsPath = BasePath + RuntimeSetsFolder + "Values Runtime Sets/";
        public const string VariableRuntimeSetsPath = BasePath + RuntimeSetsFolder + "Variable Runtime Sets/";
    }

    public static class AddComponentMenuConstants
    {
        public const string BasePath = "SO Arch/";
        public const string ListenersFolder = "Listeners/";
        public const string GameEventListenersPath = BasePath + ListenersFolder + "Game Events/";
        public const string ReferenceListenersPath = BasePath + ListenersFolder + "References/";

        public const string InstancersFolder = "Instancers/";
        public const string VariableInstancersPath = BasePath + InstancersFolder + "Variables/";
    }
}