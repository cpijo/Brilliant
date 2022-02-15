using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.CreateClassFromDatabase
{
    class CSharpProvider_Class_AsString
    {
        void testos()
        {
            var code = @"
                    public class Abc {
                       public string Get() { return ""abc""; }
                    }
                ";

            var options = new CompilerParameters();
            options.GenerateExecutable = false;
            options.GenerateInMemory = false;

            var provider = new CSharpCodeProvider();
            var compile = provider.CompileAssemblyFromSource(options, code);

            var type = compile.CompiledAssembly.GetType("Abc");
            var abc = Activator.CreateInstance(type);

            var method = type.GetMethod("Get");
            var result = method.Invoke(abc, null);

            Console.WriteLine(result); //output: abc
        }


        /*
        https://www.dotnetcurry.com/csharp/dynamic-class-creation-roslyn
        public static T BuildDynamicClass<T>(string className, IEnumerable<DynamicProperty> fields, IEnumerable<DynamicMethod> methods = null)
        {
            var dt = new DynamicType { Name = className, Implements = typeof(T) };

            foreach (var field in fields) dt.Fields.Add(field);

            foreach (var method in methods) dt.Methods.Add(method);

            // This demo only supports non-parameter constructors
            var globals = new Globals { };

            //If this functionality is extended, extra references / imports could be provided
            //as parameters. This demo just uses a default configuration of both
            dynamic ret2 = Exec(dt.ToString() + ";\n CreatedObj = new " + dt.Name + "();",
                globals: globals,
                references: new string[] { "System", typeof(T).Assembly.ToString() },
                imports: typeof(T).Namespace).Result;
            if (ret2 != null) throw new Exception("Compilation error: \n" + ret2);

            return (T)globals.CreatedObj;
        }
        
         
         //Dynamic properties to match the demo interface
var p1 = new DynamicProperty { Name = "BirthYear", FType = typeof(int) };
var p2 = new DynamicProperty { Name = "BirthMonth", FType = typeof(int) };
var p3 = new DynamicProperty { Name = "BirthDay", FType = typeof(int) };
 
//Other properties
var p4 = new DynamicProperty { Name = "Pet", FType = typeof(string) };
var p5 = new DynamicProperty { Name = "Name", FType = typeof(string) };
         
         */
    }
}



