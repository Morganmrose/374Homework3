using System;
using System.Collections.Generic;
using System.IO;

namespace Homework3 {
    class NumberReader : IDisposable {
        private readonly TextReader _reader;
        private long[] array;

        public NumberReader(FileInfo file) {
            _reader = new StreamReader(new BufferedStream(new FileStream(
                file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan), 65536));
            array = new long[File.ReadAllLines(file.FullName).Length];

        }

        public long[] ReadIntegers() {
            string x;
            var y = 0;
            while((x = _reader.ReadLine()) != null){
                array[y] = long.Parse(x);
                y++;
            }
            return array;
            }
         
     

        public void Dispose() {
            _reader.Dispose();
        }
    }
}