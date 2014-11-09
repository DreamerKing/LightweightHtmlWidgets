using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.IO;

// This class has been taken from 'http://stackoverflow.com/questions/14139766/run-a-particular-python-function-in-c-sharp-with-ironpython' and was written by 'NewProger' and modified by 'GameplayJDK'

namespace LightweightHtmlWidgets
{
    class PythonInstance
    {
        private ScriptEngine engine;
        private ScriptScope scope;
        private ScriptSource source;
        private CompiledCode compiled;
        private object pythonClass;

        public PythonInstance(String code, String className, String libaryPath)
        {
            //creating engine and stuff
            engine = Python.CreateEngine();

            ICollection<String> path = engine.GetSearchPaths();
            path.Add(Path.GetFullPath(libaryPath));
            engine.SetSearchPaths(path);

            scope = engine.CreateScope();

            //loading and compiling code
            source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
            compiled = source.Compile();

            //now executing this code (the code should contain a class)
            compiled.Execute(scope);

            //now creating an object that could be used to access the stuff inside a python script
            pythonClass = engine.Operations.Invoke(scope.GetVariable(className));
        }

        public void SetVariable(string variable, dynamic value)
        {
            scope.SetVariable(variable, value);
        }

        public dynamic GetVariable(string variable)
        {
            return scope.GetVariable(variable);
        }

        public void CallMethod(string method, params dynamic[] arguments)
        {
            engine.Operations.InvokeMember(pythonClass, method, arguments);
        }

        public dynamic CallFunction(string method, params dynamic[] arguments)
        {
            return engine.Operations.InvokeMember(pythonClass, method, arguments);
        }
    }
}
