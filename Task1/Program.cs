namespace Task1
{
	internal class Program
	{
		static void Main(string[] args)
		{		
			string value = Console.ReadLine();
			//var di = new DirectoryInfo(@"C:\Users\Варнавский\Desktop\SkillFactory");
			var di = new DirectoryInfo(value);
			TimeSpan.FromMinutes(30);
			
			/*foreach (FileInfo file in di.GetFiles())
			{
				
				file.Delete();
			}
			foreach (DirectoryInfo dir in di.GetDirectories())
			{
				dir.Delete(true);
			}*/


			/*try
			{
				DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\Варнавский\Desktop\SkillFactory");
				var dt = dirInfo.LastWriteTime;
				Console.WriteLine(dt);
				//dirInfo.Delete(true); 
				//Console.WriteLine("Каталог удален");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}*/
		}
	}
}