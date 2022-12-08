namespace Task1
{
	internal class Program
	{	
		static void Main(string[] args)
		{			
			string path = Console.ReadLine();
									
			try
			{
				var di = new DirectoryInfo(path);

				if (!di.Exists)
					throw new DirectoryNotFoundException("Данный каталог не найден!");

				foreach (FileInfo file in di.GetFiles())
				{
					var timeSpan = DateTime.Now - file.LastAccessTime;

					if (timeSpan > TimeSpan.FromMinutes(30))						
						file.Delete();
				}
				foreach (DirectoryInfo dir in di.GetDirectories())
				{
					var timeSpan = DateTime.Now - dir.LastAccessTime;

					if (timeSpan > TimeSpan.FromMinutes(30))						
						dir.Delete(true);
				}

				Console.WriteLine("Очистка завершена.");
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