using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.CreateClassFromDatabase
{
    class class_Creator
    {


        static void Main(string[] args)
        {
            string className = "BlogPost";

            var props = new Dictionary<string, Type>() {
                { "Title", typeof(string) },
                { "Text", typeof(string) },
                { "Tags", typeof(string[]) }
            };

            createType(className, props);
        }

        static void createType(string name, IDictionary<string, Type> props)
        {
            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "Test.Dynamic.dll", false);
            parameters.GenerateExecutable = false;

            var compileUnit = new CodeCompileUnit();
            var ns = new CodeNamespace("Test.Dynamic");
            compileUnit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));

            var classType = new CodeTypeDeclaration(name);
            classType.Attributes = MemberAttributes.Public;
            ns.Types.Add(classType);

            foreach (var prop in props)
            {
                var fieldName = "_" + prop.Key;
                var field = new CodeMemberField(prop.Value, fieldName);
                classType.Members.Add(field);

                var property = new CodeMemberProperty();
                property.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                property.Type = new CodeTypeReference(prop.Value);
                property.Name = prop.Key;
                property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName)));
                property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName), new CodePropertySetValueReferenceExpression()));
                classType.Members.Add(property);
            }

            var results = csc.CompileAssemblyFromDom(parameters, compileUnit);
            results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
        }


    }
    //@@@@@@@@@  OUtPUT
    //http://dontcodetired.com/blog/post/Creating-Your-Own-Custom-Dynamic-C-Classes
    //https://softwareengineering.stackexchange.com/questions/93322/generating-a-class-dynamically-from-types-that-are-fetched-at-runtime
    namespace Test.Dynamic
    {
        public class BlogPost
        {
            private string _Title;
            private string _Text;
            private string[] _Tags;

            public string Title
            {
                get
                {
                    return this._Title;
                }
                set
                {
                    this._Title = value;
                }
            }
            public string Text
            {
                get
                {
                    return this._Text;
                }
                set
                {
                    this._Text = value;
                }
            }
            public string[] Tags
            {
                get
                {
                    return this._Tags;
                }
                set
                {
                    this._Tags = value;
                }
            }
        }
        public class DynamicEntity : DynamicObject
        {
            private IDictionary<string, object> _values;

            public DynamicEntity(IDictionary<string, object> values)
            {
                _values = values;
            }
            public override IEnumerable<string> GetDynamicMemberNames()
            {
                return _values.Keys;
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (_values.ContainsKey(binder.Name))
                {
                    result = _values[binder.Name];
                    return true;
                }
                result = null;
                return false;
            }
        }

        class myUsage {
            void usage_1()
            {
                var values = new Dictionary<string, object>();
                values.Add("Title", "Hello World!");
                values.Add("Text", "My first post");
                values.Add("Tags", new[] { "hello", "world" });

                var post = new DynamicEntity(values);

                dynamic dynPost = post;
                var text = dynPost.Text;
            }
        }

    }
}

