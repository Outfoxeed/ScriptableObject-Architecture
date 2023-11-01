using ScriptableObjectArchitecture.References;
using UnityEditor;

namespace ScriptableObjectArchitecture.Editor.References
{
    /// <summary>
    /// A custom property drawer for References. Makes it possible to choose between a Value, Variable, Constant or a Variable Instancer.
    /// Credits: https://github.com/unity-atoms/unity-atoms
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnlyReference<>), true)]
    public class ReadOnlyReferenceDrawer : BaseReferenceDrawer
    {
        protected class UsageValue : UsageData
        {
            public override int Value { get => (int)ReferenceUsage.Value; }
            public override string PropertyName { get => "_value"; }
            public override string DisplayName { get => "Use Value"; }
        }

        protected class UsageConstant : UsageData
        {
            public override int Value { get => (int)ReferenceUsage.Constant; }
            public override string PropertyName { get => "_constant"; }
            public override string DisplayName { get => "Use Constant"; }
        }

        protected class UsageVariable : UsageData
        {
            public override int Value { get => (int)ReferenceUsage.Variable; }
            public override string PropertyName { get => "_variable"; }
            public override string DisplayName { get => "Use Variable"; }
        }

        protected class UsageVariableInstancer : UsageData
        {
            public override int Value { get => (int)ReferenceUsage.Instancer; }
            public override string PropertyName { get => "_variableInstancer"; }
            public override string DisplayName { get => "Use Variable Instancer"; }
        }

        private readonly UsageData[] _usages = new UsageData[4] { new UsageValue(), new UsageVariable(), new UsageVariableInstancer(), new UsageConstant() };

        protected override UsageData[] GetUsages(SerializedProperty prop = null) => _usages;
    }
}
