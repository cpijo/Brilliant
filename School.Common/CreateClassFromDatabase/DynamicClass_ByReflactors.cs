using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.CreateClassFromDatabase
{
    class DynamicClass_ByReflactors
    {
    }
    public class Field
    {
        public string FieldName;
        public string FieldType;

        public Field(string v, string t) { }
    }

    //https://stackoverflow.com/questions/3862226/how-to-dynamically-create-a-class
    //    public class FieldList_uuuuu
    //    {
    //        void Test_Main0(string[] args)
    //    {
    //        var fields = new List<Field>()
    //            {
    //                new Field("EmployeeID","int"),
    //                new Field("EmployeeName","String"),
    //                new Field("Designation","String")
    //            };

    //        var employeeClass = CreateClass(fields, "Employee");

    //        dynamic employee1 = Activator.CreateInstance(employeeClass);
    //        employee1.EmployeeID = 4213;
    //        employee1.EmployeeName = "Wendy Tailor";
    //        employee1.Designation = "Engineering Manager";

    //        dynamic employee2 = Activator.CreateInstance(employeeClass);
    //        employee2.EmployeeID = 3510;
    //        employee2.EmployeeName = "John Gibson";
    //        employee2.Designation = "Software Engineer";

    //        Console.WriteLine($"{employee1.EmployeeName}");
    //        Console.WriteLine($"{employee2.EmployeeName}");

    //        Console.WriteLine("Press any key to continue...");
    //        Console.ReadKey();
    //    }
    //}

    public class FieldList
    {
        public string FieldName;//age,name
        public Type FieldType;//int,string

        public FieldList(string v, Type t) { }
    }


    public static class MyTypeBuilder
    {
        public static void CreateNewObject()
        {
            var myType = CompileResultType();
            var myObject = Activator.CreateInstance(myType);



        }
        public static Type CompileResultType()
        {
            TypeBuilder tb = GetTypeBuilder();
            ConstructorBuilder constructor = tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);

            //https://stackoverflow.com/questions/3862226/how-to-dynamically-create-a-class
            List<FieldList> FieldLists = new List<FieldList>();

            var fields = new List<FieldList>() {
    new FieldList("EmployeeID", typeof(int)),
    new FieldList("EmployeeName", typeof(string)),
    new FieldList("Designation", typeof(string))
};


            //IEnumerable<FieldList> props = fields.Select(property => new FieldList(property.FieldName, Type.GetType(property.FieldName))).ToList();

            //Type t = DynamicExpression.CreateClass(props);
            //object obj = Activator.CreateInstance(t);
            //t.GetProperty("EmployeeID").SetValue(obj, 34, null);
            //t.GetProperty("EmployeeName").SetValue(obj, "Albert", null);
            //t.GetProperty("Birthday").SetValue(obj, new DateTime(1976, 3, 14), null);


            //dynamic obj = new DynamicClass(fields);

            ////set
            //obj.EmployeeID = 123456;
            //obj.EmployeeName = "John";
            //obj.Designation = "Tech Lead";



            // NOTE: assuming your list contains Field objects with fields FieldName(string) and FieldType(Type)
            foreach (FieldList field in FieldLists)
                CreateProperty(tb, field.FieldName, field.FieldType);

            Type objectType = tb.CreateType();
            return objectType;
        }

        private static TypeBuilder GetTypeBuilder()
        {
            var typeSignature = "MyDynamicType";
            var an = new AssemblyName(typeSignature);
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            TypeBuilder tb = moduleBuilder.DefineType(typeSignature,
                    TypeAttributes.Public |
                    TypeAttributes.Class |
                    TypeAttributes.AutoClass |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.BeforeFieldInit |
                    TypeAttributes.AutoLayout,
                    null);
            return tb;
        }

        private static void CreateProperty(TypeBuilder tb, string propertyName, Type propertyType)
        {
            FieldBuilder fieldBuilder = tb.DefineField("_" + propertyName, propertyType, FieldAttributes.Private);

            PropertyBuilder propertyBuilder = tb.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);
            MethodBuilder getPropMthdBldr = tb.DefineMethod("get_" + propertyName, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            ILGenerator getIl = getPropMthdBldr.GetILGenerator();

            getIl.Emit(OpCodes.Ldarg_0);
            getIl.Emit(OpCodes.Ldfld, fieldBuilder);
            getIl.Emit(OpCodes.Ret);

            MethodBuilder setPropMthdBldr =
                tb.DefineMethod("set_" + propertyName,
                  MethodAttributes.Public |
                  MethodAttributes.SpecialName |
                  MethodAttributes.HideBySig,
                  null, new[] { propertyType });

            ILGenerator setIl = setPropMthdBldr.GetILGenerator();
            Label modifyProperty = setIl.DefineLabel();
            Label exitSet = setIl.DefineLabel();

            setIl.MarkLabel(modifyProperty);
            setIl.Emit(OpCodes.Ldarg_0);
            setIl.Emit(OpCodes.Ldarg_1);
            setIl.Emit(OpCodes.Stfld, fieldBuilder);

            setIl.Emit(OpCodes.Nop);
            setIl.MarkLabel(exitSet);
            setIl.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getPropMthdBldr);
            propertyBuilder.SetSetMethod(setPropMthdBldr);
        }
    }


    /*
    And an object List<Field> with values:

{"EmployeeID","int"},
{"EmployeeName","String"},
{"Designation","String"}
I want to create a class that looks like this:

Class DynamicClass
{
    int EmployeeID,
    String EmployeeName,
    String Designation
}
    */
}
