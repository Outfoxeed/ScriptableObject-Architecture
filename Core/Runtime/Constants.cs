namespace ScriptableObjectArchitecture
{
    public static partial class CreateAssetMenuConstants
    {
        public const string BasePath = "SO Arch/";
        public const string ConstantsPath = BasePath + "Constants/";
        public const string VariablesPath = BasePath + "Variables/";
        public const string GameEventsPath = BasePath + "Game Events/";
        public const string RuntimeSetsPath = BasePath + "Runtime Sets/";
    }

    public static class AddComponentMenuConstants
    {
        public const string BasePath = "SO Arch/";
        public const string ListenersFolder = "Listeners/";
        public const string GameEventListenersPath = BasePath + ListenersFolder + "Game Events/";
        public const string ReferenceListenersPath = BasePath + ListenersFolder + "References/";

        public const string SettersFolder = "Setters/";
        public const string ReferenceSettersPath = BasePath + SettersFolder + "References/";
        public const string RuntimeSetInjectorsPath = BasePath + SettersFolder + "Runtime Sets Injectors/";

        public const string InstancersFolder = "Instancers/";
        public const string VariableInstancersPath = BasePath + InstancersFolder + "Variables/";
    }

    public static class MenuItemConstants
    {
        public const string MenuItemFolder = "SO Arch/";
        public const string CodeGeneratorWindow = MenuItemFolder + "Code Generator";
    }
}