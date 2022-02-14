using System;

namespace SOLID
{
	// DIP

	/*
	 * Simple models
	 */
	public class UserModel
	{
	}

	public class PostModel
	{
	}

	/*
	  * Storage abstraction
	 */
	public interface IStorage
	{
		public void Open(string s);
		public void Close();
	}

	public class MockStorage : IStorage
	{
		public void Open(string s)
		{
			Console.WriteLine($"Connected to Mock {s}");
		}

		public void Close()
		{
			Console.WriteLine("Disconnected from Mock");
		}
	}

	public class MongoStorage : IStorage
	{
		public void Open(string s)
		{
			Console.WriteLine($"Connected to MongoDB with string {s}");
		}

		public void Close()
		{
			Console.WriteLine("Disconnected from MongoDB");
		}
	}

	/*
	  * Repository abstraction
	 */
	public interface IRepository<T>
	{
		public void Create(T item);
		public void Delete(int id);
		public T Update(int id, T item);
		public T Find(int id);
	}

	public class UserRepository<T> : IRepository<T>
	{
		private readonly IStorage _storage;

		public UserRepository(IStorage storage)
		{
			_storage = storage ?? throw new Exception("Storage can't be null");
		}

		public void Create(T user)
		{
			Console.WriteLine("Create new record in User repository");
		}

		public void Delete(int id)
		{
			// ! Stupid C# :)
			// Console.WriteLine("Delete record from User repository");
			Console.WriteLine("Delete record in User repository");
		}

		public T Update(int id, T user)
		{
			Console.WriteLine("Update record from User repository");
			return default;
		}

		public T Find(int id)
		{
			Console.WriteLine("Find record in User repository");
			return default;
		}
	}

	public class PostRepository<T> : IRepository<T>
	{
		private readonly IStorage _storage;

		public PostRepository(IStorage storage)
		{
			_storage = storage ?? throw new Exception("Storage can't be null");
		}

		public void Create(T post)
		{
			Console.WriteLine("Create record in Post repository");
		}

		public void Delete(int id)
		{
			Console.WriteLine("Delete record at Post repository");
		}

		public T Update(int id, T post)
		{
			Console.WriteLine("Update record from Post repository");
			return default;
		}

		public T Find(int id)
		{
			Console.WriteLine("Find record in Post repository");
			return default;
		}
	}

	/*
	  * Service abstraction
	 */
	public interface IService<T>
	{
		public void Add(T item);
		public T Get(int id);
		public void Remove(int id);
		public void Update(int id, T item);
	}

	public class UserService : IService<UserModel>
	{
		private IRepository<UserModel> _userRepository;

		public UserService(IRepository<UserModel> userRepo)
		{
			_userRepository = userRepo;
		}

		public void Add(UserModel item)
		{
			Console.WriteLine("Add new user");
		}

		public UserModel Get(int id)
		{
			Console.WriteLine($"Get user with id {id}");
			return default;
		}

		public void Remove(int id)
		{
			Console.WriteLine("Delete user");
		}

		public void Update(int id, UserModel item)
		{
			Console.WriteLine("Update user");
		}
	}

	public class PostService : IService<PostModel>
	{
		private IRepository<PostModel> _postRepository;

		public PostService(IRepository<PostModel> userRepo)
		{
			_postRepository = userRepo;
		}

		public void Add(PostModel item)
		{
			Console.WriteLine("Add new post");
		}

		public PostModel Get(int id)
		{
			Console.WriteLine($"Get post with id {id}");
			return default;
		}

		public void Remove(int id)
		{
			Console.WriteLine("Update post");
		}

		public void Update(int id, PostModel item)
		{
			Console.WriteLine("Update post");
		}
	}

	/*
	 * Whole App which depends only on switchable abstractions
	 */
	public class App
	{
		private readonly IService<UserModel> _userService;
		private readonly IService<PostModel> _postService;

		public App(IService<UserModel> userService, IService<PostModel> postService)
		{
			_userService = userService ?? throw new Exception("Service can't be null");
			_postService = postService ?? throw new Exception("Service can't be null");
		}

		public void HandleCreateUser()
		{
			_userService.Add(null);
		}

		public void HandleGetPost()
		{
			_postService.Get(0);
		}

		// * Any other methods
	}
}