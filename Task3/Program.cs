namespace Task3
{
	internal class Program
	{
		public static long DirSize(DirectoryInfo di)
		{
			long size = 0;

			size += FileSize(di);

			try
			{
				foreach (DirectoryInfo dir in di.GetDirectories())
					size += DirSize(dir);
			}
			catch (UnauthorizedAccessException ex)
			{
				Console.WriteLine(ex.Message);
			}
			return size;
		}
		public static long FileSize(DirectoryInfo di)
		{
			long size = 0;

			try
			{
				foreach (FileInfo fi in di.GetFiles())
				{
					try
					{
						size += fi.Length;
					}
					catch (UnauthorizedAccessException ex)
					{
						Console.WriteLine($"Нет прав доступа к файлу {fi}. " + ex.Message);
					}
				}
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine($"Нет прав доступа к директории {di}.");
			}
			return size;
		}
		static void Main(string[] args)
		{
			string path = Console.ReadLine();
			
			try
			{
				var di = new DirectoryInfo(path);

				if (!di.Exists)
					throw new DirectoryNotFoundException("Данный каталог не найден!");

				long freeSize = 0;

				long startSize = DirSize(di);
				Console.WriteLine($"Исходный размер папки: {startSize} байт");
			
				foreach (FileInfo file in di.GetFiles())
				{
					var timeSpan = DateTime.Now - file.LastAccessTime;

					if (timeSpan > TimeSpan.FromMinutes(30))
					{
						freeSize += file.Length;
						file.Delete();
					}					
				}
				foreach (DirectoryInfo dir in di.GetDirectories())
				{
					var timeSpan = DateTime.Now - dir.LastAccessTime;

					if (timeSpan > TimeSpan.FromMinutes(30))
					{
						freeSize += DirSize(dir);
						dir.Delete(true);
					}											
				}
	
				Console.WriteLine($"Освобождено: {freeSize} байт");
				Console.WriteLine($"Текущий размер папки: {startSize - freeSize} байт");
			}
			catch (ArgumentNullException ex)
			{
				Console.WriteLine("Аргумент, передаваемый в метод — null. " + ex.Message);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine("Аргумент, передаваемый в метод, является недопустимым. " + ex.Message);
			}
			catch (DirectoryNotFoundException ex)
			{
				Console.WriteLine("Недопустимая часть пути к каталогу. " + ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}