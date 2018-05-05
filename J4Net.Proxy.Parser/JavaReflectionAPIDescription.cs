using DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace J4Net.Proxy.Parser
{
    public static class JavaReflectionAPIDescription
    {
        static private LibraryDescription lib;
        static private string libName = "java.lang.reflect";

        static JavaReflectionAPIDescription()
        {
            var classes = new List<ClassDescription>();
            classes.Add(GenerateDescriptionForModifier());
            classes.Add(GenerateDescriptionForField());
            classes.Add(GenerateDescriptionForParameter());
            classes.Add(GenerateDescriptionForMethod());
            classes.Add(GenerateDescriptionForConstructor());

            var lib = new LibraryDescription(libName, classes);
            JavaReflectionAPIDescription.lib = lib;
        }

        public static LibraryDescription GetDescription() => lib;

        private static ClassDescription GenerateDescriptionForModifier()
        {
            var methods = new List<MethodDescription>() {
                    new MethodDescription(
                        "isAbstaract",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>() { new ParameterDescription("mod", "int") },
                        "boolean"),
                    new MethodDescription(
                        "isFinal",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>() { new ParameterDescription("mod", "int") },
                        "boolean"),
                    new MethodDescription(
                        "isNative",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>() { new ParameterDescription("mod", "int") },
                        "boolean"),
                    new MethodDescription(
                        "isProtected",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>() { new ParameterDescription("mod", "int") },
                        "boolean"),
                    new MethodDescription(
                        "isPublic",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>() { new ParameterDescription("mod", "int") },
                        "boolean"),
                    new MethodDescription(
                        "isStatic",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>() { new ParameterDescription("mod", "int") },
                        "boolean"),
                    new MethodDescription(
                        "isSynchronized",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>() { new ParameterDescription("mod", "int") },
                        "boolean"),
                    new MethodDescription(
                        "isTransient",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>() { new ParameterDescription("mod", "int") },
                        "boolean"),
                    new MethodDescription(
                        "isVolatile",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>() { new ParameterDescription("mod", "int") },
                        "boolean")};

            var description = new ClassDescription(
                "Modifier",
                libName,
                new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                new List<FieldDescription>(),
                methods,
                new List<ClassDescription>(),
                new List<ClassDescription>(),
                false);
            return description;
        }

        private static ClassDescription GenerateDescriptionForField()
        {
            var methods = new List<MethodDescription>() {
                    new MethodDescription(
                        "getName",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.String"),
                    new MethodDescription(
                        "getType",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.Class"),
                    new MethodDescription(
                        "getModifiers",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "int")};
            var description = new ClassDescription(
                "Field",
                libName,
                new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.FINAL },
                new List<FieldDescription>(),
                methods,
                new List<ClassDescription>(),
                new List<ClassDescription>(),
                false);
            return description;
        }

        private static ClassDescription GenerateDescriptionForParameter()
        {
            var methods = new List<MethodDescription>() {
                    new MethodDescription(
                        "getName",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.String"),
                    new MethodDescription(
                        "getType",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.Class")};
            var description = new ClassDescription(
                "Parameter",
                libName,
                new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.FINAL },
                new List<FieldDescription>(),
                methods,
                new List<ClassDescription>(),
                new List<ClassDescription>(),
                false);
            return description;
        }

        private static ClassDescription GenerateDescriptionForConstructor()
        {
            var methods = new List<MethodDescription>() {
                    new MethodDescription(
                        "getName",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.String"),
                    new MethodDescription(
                        "getModifiers",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "int"),
                    new MethodDescription(
                        "getParameters",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.reflect.Parameter[]")};
            var description = new ClassDescription(
                "Constructor",
                libName,
                new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.FINAL },
                new List<FieldDescription>(),
                methods,
                new List<ClassDescription>(),
                new List<ClassDescription>(),
                false);
            return description;
        }

        private static ClassDescription GenerateDescriptionForMethod()
        {
            var methods = new List<MethodDescription>() {
                    new MethodDescription(
                        "getName",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.String"),
                    new MethodDescription(
                        "getReturnType",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.Class"),
                    new MethodDescription(
                        "getModifiers",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "int"),
                    new MethodDescription(
                        "getParameters",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.reflect.Parameter[]")};
            var description = new ClassDescription(
                "Method",
                libName,
                new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.FINAL },
                new List<FieldDescription>(),
                methods,
                new List<ClassDescription>(),
                new List<ClassDescription>(),
                false);
            return description;
        }
    }
}
