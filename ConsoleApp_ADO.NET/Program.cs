


using ADO.NET_Business.Helpers;
using ADO.NET_Business.Services;
using ADO.NET_Core.Entities;

PostServices postServices = new PostServices();
bool temp = true;
while (temp)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("1) Add an object to database\n" +
                    "2) Get missing posts from database\n" +
                    "3) Show posts' count in database\n" +
                    "4) Close App\n" +
                    " ");
    Console.ResetColor();
    string? option = Console.ReadLine();
    int IntOption;
    bool IsInt = int.TryParse(option, out IntOption);
    if (IsInt)
    {
        if (IntOption >= 0 && IntOption <= 3)
        {
            switch (IntOption)
            {
                case (int)Menu.Add:
                    try
                    {
                        Console.Write("Enter post's ID: ");
                        int postId = Convert.ToInt32(Console.ReadLine());
                        Post post = await postServices.GetByIdAsync(postId);
                        if (post is not null)
                        {
                            await postServices.AddPostToDbAsync(post);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Post with this {postId} is not found");
                            Console.ResetColor();
                            goto case (int)Menu.Add;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        goto case (int)Menu.Add;
                    }
                    break;
                case (int)Menu.Show:
                    try
                    {
                        await postServices.NotExistPostsDbAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        goto case (int)Menu.Show;
                    }
                    break;
                case (int)Menu.Get:
                    try
                    {
                        Console.Write("Enter user id: ");
                        int userId = Convert.ToInt32(Console.ReadLine());
                        if (!int.TryParse(Console.ReadLine(), out userId) || (userId < 0))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nWrong format id! Please try again...\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            int result = await postServices.GetUserPostCountsAsync(userId);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"User ID : {userId}\n" +
                                              $"User's post count : {result}\n" +
                                              " ");
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        goto case (int)Menu.Get;
                    }
                    break;
                case 0:
                    temp = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Application closed!\n" +
                                      $"Press any key to close window...");
                    Console.ResetColor();
                    break;

            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPlease enter correct number!\n");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nPlease enter correct format!\n");
        Console.ResetColor();
    }
}