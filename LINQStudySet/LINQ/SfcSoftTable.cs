namespace Test.LINQ
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    class SfcSoftTable
    {
        public static void Main(string[] args)
        {
            var softDatas = new List<SfcSoftData>();
            using (var reader = new StreamReader(@"c:\test\NSFData.csv"))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split("\t");
                    softDatas.Add(new SfcSoftData
                    {
                        Id = int.Parse(data[0]),
                        ReleaseDate = DateTime.Parse(data[1]),
                        Title = data[2],
                        Maker = data[3],
                        Price = int.Parse(data[4]),
                    });
                }
            }

        }
    }
}
