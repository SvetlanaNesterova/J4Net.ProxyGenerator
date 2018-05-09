using System.Collections.Generic;
using System.Linq;

namespace DSL
{
    public class LibraryDescription : Description
    {
        public readonly List<ClassDescription> Classes;
        public readonly List<string> ExternalDependenciesTypes;

        public LibraryDescription(string name, List<ClassDescription> classes)
            : base(name, null)
        {
            Classes = classes;
            var internalClassesNames = new HashSet<string>(Classes.Select(cls => cls.FullName));
            ExternalDependenciesTypes = classes
                .SelectMany(cls => cls.Dependencies)
                .Where(cls => !internalClassesNames.Contains(cls))
                .ToList();
        }
    }
}
