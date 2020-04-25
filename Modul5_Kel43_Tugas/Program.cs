using System;

namespace Modul5_Kel43_Tugas
{
    class Program
    {
        static void Main(string[] args)
        {
                string email, password;
                Console.Write("Email : ");
                email = Console.ReadLine();
                Console.Write("Password : ");
                password = Console.ReadLine();
                userService data = new userService(email, password);
                data.login();
                Console.ReadKey();
            }
        }
    }
class userService
{
    private string[,] data;
    private string[,] histories;
    private string email, password, roles = "";
    int book;

    public userService(string emails, string passwords)
    {
        email = emails;
        password = passwords;
        data = new string[2, 3] {
            {"farraskelompok43@gmail.com", "12345", "superadmin" },
            {"makykelompok43@gmail.com", "12345", "user"  }
            };
        histories = new string[2, 4] {
            {"farraskelompok43@gmail.com", "Fisika Dasar", "Dasar Komputer dan Pemrograman", "25-April-2020" },
            {"makykelompok43@gmail.com", "Dasar Komputer dan Pemrograman", "Konsep Jaringan Komputer", "25-April-2020" }
            };
    }

    public void login()
    {
        var (status, role) = checkCredentials();
        if (status == true)
        {
            Console.WriteLine("\nWelcome " + roles);
            Console.WriteLine("Logged it as user email : " + email);
            Console.WriteLine("");
            Console.WriteLine(email + " Meminjam buku : ");
            for (int i = 1; i < 3; i++)
            {
                Console.WriteLine(histories[book, i]);
            }
            Console.WriteLine("Tanggal Peminjaman : " + histories[book, 3]);
        }
        else
        {
            Console.WriteLine("\nInvalid Login");
        }
    }
    private (bool, string) checkCredentials()
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            if (data[i, 0] == email && data[i, 1] == password)
            {
                if (data[i, 0] == histories[i, 0])
                    book = i;
                roles = data[i, 2];
                return (true, roles);
            }
        }
        return (false, roles);
    }
}
