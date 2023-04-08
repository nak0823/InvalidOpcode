using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;

namespace OpcodeRemover.Helper
{
    internal class Context
    {
        public AssemblyDef assemblyDef;
        public ModuleDef moduleDef;
        public ModuleDefMD moduleDefMD;
        public TypeDef typeDef;
        public Importer importer;
        public MethodDef cctor;

        public Context(AssemblyDef asm)
        {
            assemblyDef = asm;
            moduleDef = asm.ManifestModule;
            typeDef = moduleDef.GlobalType;
            importer = new Importer(moduleDef);
            cctor = typeDef.FindOrCreateStaticConstructor();
        }
    }
}
