using ExtentionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionExample2
{
    internal static class MissingData
    {
        public static string Mailestone3(this Operations opr)
        {
            return "Milestone3 is on react";
        }
        public static string Mailestone4(this Operations opr) {
            return "Milestone4 is on React and .NET";
        }
        public static string CapstoneProject(this Operations opr)
        {
            return "must compleate CapstoneProject";
        }
        }
    }
