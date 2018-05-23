using System.Collections.Generic;
using System.Linq;

namespace DSL
{
    public class ClassDescription : Description
    {
        public readonly string PackageName;
        public readonly string FullName;
        public readonly string ShortName;
        public readonly List<FieldDescription> FieldsDescriptions;
        public readonly List<MethodDescription> MethodsDescriptions;
        public readonly List<string> DependenciesNames;
        public readonly List<ClassDescription> NestedClassesDescriptions;
        public readonly bool IsNested;

        public ClassDescription(
            string shortName,
            string packageName,
            List<ModifierDescription> modifiersDescriptions,
            List<FieldDescription> fieldsDescriptions,
            List<MethodDescription> methodsDescriptions,
            List<string> dependenciesNames,
            List<ClassDescription> nestedClassesDescriptions,
            bool isNested)
                : base(packageName + "." + shortName, modifiersDescriptions)
        {
            PackageName = packageName;
            ShortName = shortName;
            FullName = packageName + "." + shortName;
            FieldsDescriptions = fieldsDescriptions;
            MethodsDescriptions = methodsDescriptions;
            DependenciesNames = dependenciesNames;
            IsNested = isNested;
            NestedClassesDescriptions = nestedClassesDescriptions;
        }
    }
}