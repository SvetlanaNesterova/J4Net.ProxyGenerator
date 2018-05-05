using System;
using System.Collections.Generic;
using DSL;

namespace J4Net.Proxy.Parser
{
    public static class JavaLangDescription
    {
        static private LibraryDescription lib;
        static private string libName = "java.lang";

        static JavaLangDescription()
        {
            var classes = new List<ClassDescription>();
            classes.Add(GenerateDescriptionForClassLoader());
            classes.Add(GenerateDescriptionForClass());

            var lib = new LibraryDescription(libName, classes);
            JavaLangDescription.lib = lib;
        }

        public static LibraryDescription GetDescription() => lib;

        private static ClassDescription GenerateDescriptionForClassLoader()
        {
            var methods = new List<MethodDescription>() {
                    new MethodDescription(
                        "getSystemClassLoader",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.STATIC },
                        new List<ParameterDescription>(),
                        "java.lang.ClassLoader"),
                    new MethodDescription(
                        "loadClass",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>() { new ParameterDescription("name", "java.lang.String") },
                        "java.lang.Class")};
            var description = new ClassDescription(
                "ClassLoader",
                libName,
                new List<ModifierDescription>() { ModifierDescription.PUBLIC, ModifierDescription.ABSTRACT },
                new List<FieldDescription>(),
                methods,
                new List<ClassDescription>(),
                new List<ClassDescription>(),
                false);
            return description;
        }

        private static ClassDescription GenerateDescriptionForClass()
        {
            var methods = new List<MethodDescription>() {
                    new MethodDescription(
                        "getName",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.String"),
                    new MethodDescription(
                        "getSimpleName",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.String"),
                    new MethodDescription(
                        "getPackageName",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.String"),
                    new MethodDescription(
                        "getModifiers",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "int"),
                    new MethodDescription(
                        "getClasses",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.Class[]"),
                    new MethodDescription(
                        "getFields",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.reflect.Field[]"),
                    new MethodDescription(
                        "getMethods",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.reflect.Method[]"),
                    new MethodDescription(
                        "getConstructors",
                        new List<ModifierDescription>() { ModifierDescription.PUBLIC },
                        new List<ParameterDescription>(),
                        "java.lang.reflect.Constructor[]")};
            var description = new ClassDescription(
                "Class",
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