using System;

// SOLID 
// 1. SRP
// 2. OCP
// 3. LSP
// 4. ISP
// 5. DIP

namespace SOLID
{
	class Program
	{
		static void Main()
		{
			// SRP
			Book book = new Book(
				"Dune",
				"F.Herbert",
				"Real or not book text",
				"Epic science fiction novel"
			);
			Console.WriteLine(book.IsContainsWord("text"));

			BookPrinter bk = new BookPrinter();
			bk.ToConsole(book);
			Console.WriteLine("---");

			// OCP
			Keyboard kb = new Keyboard(68, SwitchType.Mechanical);
			RGBKeyboard rgbKb = new RGBKeyboard(104, SwitchType.Membrane, 2);
			KeyboardWithTouchPanel touchKb = new KeyboardWithTouchPanel(105, SwitchType.Scissor, 6, false);
			Console.WriteLine("---");

			// LSP
			Unit unit = new Unit(25);
			Knight knight = new(100);
			Wizard wizard = new(80);
			Game.Run(unit, knight, wizard);

			Console.WriteLine("---");

			// 4. ISP
			Console.WriteLine("---");

			// 5. DIP
			IStorage mockStorage = new MockStorage();
			IStorage mongoStorage = new MongoStorage();

			mockStorage.Open("Empty");
			mongoStorage.Open("mongodb://connection_string");

			IRepository<UserModel> userRepo = new UserRepository<UserModel>(mockStorage);
			IRepository<PostModel> postRepo = new PostRepository<PostModel>(mockStorage);
			// IRepository<PostModel> postRepo = new PostRepository<PostModel>(mongoStorage);

			IService<UserModel> userService = new UserService(userRepo);
			IService<PostModel> postService = new PostService(postRepo);

			App app = new App(userService, postService);
			app.HandleCreateUser();
			app.HandleGetPost();

			Console.WriteLine("---");

			TFunc(userService);
			TFunc(postService);
		}

		static void TFunc<T>(IService<T> service)
		{
			service.Get(1);
		}
	}
}