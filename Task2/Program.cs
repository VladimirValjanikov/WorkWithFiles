namespace Task2
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
				Console.WriteLine($"Размер директории {DirSize(di)} байт");			
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