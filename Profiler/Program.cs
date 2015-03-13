using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Profiler {

    class Program {

        private const int listSize = 10000;

        static void Main(string[] args) {

            string data = Guid.NewGuid().ToString();

            Thread.Sleep(1000);

            string dateTime = DateTime.Now.ToString();

            List<string> listArg = new List<string>();
            
            listArg.Add("Banana");

            listArg.Add("Macaco");

            TestarInstanciaList(listArg);

            TestarInstanciaIList(listArg);

            TestarInstanciaIEnumerable(listArg);

            TestarInstanciaVar(listArg);

            TestarInstanciaDynamic(listArg);

            TestarInstanciaObject(listArg);

        }

        private static object TestarInstanciaObject(List<string> listArg) {
            object list = listArg;
            return list;
        }

        private static object TestarInstanciaDynamic(List<string> listArg) {
            dynamic list = listArg;
            return list;
        }

        private static object TestarInstanciaVar(List<string> listArg) {
            var list = listArg;
            return list;
        }

        private static object TestarInstanciaIEnumerable(List<string> listArg) {
            IEnumerable<string> list = listArg;
            return list;
        }

        private static object TestarInstanciaIList(List<string> listArg) {
            IList<string> list = listArg;
            return list;
        }

        private static object TestarInstanciaList(List<string> listArg) {
            List<string> list = listArg;
            return list;
        }
        
    }
}
