using System.Globalization;
using System.IO;

using CsvHelper;

namespace WizTreeTools
{
	public class Program
	{
#warning Doesn't support to calculate folder list size now.
		static void Main(string[] args)
		{
			string wizTreeCsvPath;
			int clusterSizeBytes;

			Console.WriteLine("help: CalUsedFileSize <path to WirTree CSV data file> <cluster size>");

			Console.Write("WizTree CSV file path = ");
			if (args.Length > 0)
			{
				wizTreeCsvPath = args[0];
				Console.WriteLine($"\"{wizTreeCsvPath}\"");
			}
			else
			{
				wizTreeCsvPath = Console.ReadLine();
			}

			Console.Write("Cluster size of storage = ");
			if (args.Length > 1)
			{
				clusterSizeBytes = Convert.ToInt32(args[1]);
				Console.WriteLine(clusterSizeBytes);
			}
			else
			{
				clusterSizeBytes = (int)(FileSize.Parse(Console.ReadLine()).Bytes);
			}

			WizTreeCsvItem[] wizTreeCsvItems = null;
			using (var reader = new StreamReader(wizTreeCsvPath))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				wizTreeCsvItems = csv.GetRecords<WizTreeCsvItem>().ToArray();
			}

			long usedSize = 0;
			long totalAllocationSize = 0;
			long actualUsedSize = 0;

			foreach(var wizTreeCsvItem in wizTreeCsvItems)
			{
				if(!(wizTreeCsvItem.Path.EndsWith('/')|| wizTreeCsvItem.Path.EndsWith('\\')))
				{
					usedSize += wizTreeCsvItem.Size;
					actualUsedSize += CalActualUsedIsze(wizTreeCsvItem.Size, clusterSizeBytes);
					totalAllocationSize += wizTreeCsvItem.AllocationSize;
				}
			}

			Console.WriteLine($"Used size = {new FileSize(usedSize)}");
			Console.WriteLine($"Total allocation size = {new FileSize(totalAllocationSize)} [+{new FileSize(totalAllocationSize - usedSize)}]");
			Console.WriteLine($"Actual Used size = {new FileSize(actualUsedSize)} [+{new FileSize(actualUsedSize - usedSize)}]");
		}

		public static long CalActualUsedIsze(long usedSize, int clusterSize)
		{
			Math.DivRem(usedSize, clusterSize, out long remainder);
			if(remainder > 0)
			{
				return usedSize - remainder + clusterSize;
			}
			return usedSize;
		}
	}
}