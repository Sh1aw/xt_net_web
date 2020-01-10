using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    class MyFile
    {
        public string Name { get; private set; }
        public DateTime TimeOfCreation { get; set; }
        public string Value { get; private set; }
        public string Reason { get; private set; }
        public string FullPath { get; private set; }
        public string OldPath { get; private set; }
        public string OldName { get; private set; }

        public MyFile(string name, string value, DateTime time, string reason, string fullPath, string oldName, string oldPath)
        {
            Name = name;
            Value = value;
            TimeOfCreation = time;
            Reason = reason;
            FullPath = fullPath;
            OldPath = oldPath;
            OldName = oldName;
        }
        public override string ToString()
        {
            return String.Format("Name: {0}; Date: {1}; Value {2}; Reason: {3}; FullPath: {4}; OldName: {5}", Name, TimeOfCreation, Value, Reason, FullPath, OldName);
        }
    }
}
