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
        public readonly List<ClassDescription> NestedClassesDescriptions;
        public readonly List<string> Dependencies;
        public readonly bool IsNested;

        public ClassDescription(
            string shortName,
            string packageName,
            List<ModifierDescription> modifiersDescriptions,
            List<FieldDescription> fieldsDescriptions,
            List<MethodDescription> methodsDescriptions,
            List<ClassDescription> nestedClassesDescriptions,
            bool isNested)
                : base(packageName + "." + shortName, modifiersDescriptions)
        {
            PackageName = packageName;
            ShortName = shortName;
            FullName = packageName + "." + shortName;
            FieldsDescriptions = fieldsDescriptions;
            MethodsDescriptions = methodsDescriptions;
            IsNested = isNested;
            NestedClassesDescriptions = nestedClassesDescriptions;

            Dependencies = CollectAllUsedTypesNames();
        }

        private List<string> CollectAllUsedTypesNames()
        {
            return new List<string>(new HashSet<string>(
                FieldsDescriptions.Select(field => field.Type)
                .Concat(MethodsDescriptions
                    .Select(method => method.ReturnType))
                .Concat(MethodsDescriptions
                    .SelectMany(method => method.ParametersDescriptions.Select(parameter => parameter.Type)))
                .Concat(NestedClassesDescriptions.SelectMany(nestedCls => nestedCls.Dependencies))));
        }
    }
}