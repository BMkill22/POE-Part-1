using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace POE_Part_1
{
    public class basic
    {
        public basic()
        {

            //This is to Display the chatbot UI with colors and ASCII logo
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*==========================================================*");
            Console.WriteLine("          $ The Cybersecurity Awareness Chatbot $  ");
            Console.WriteLine("*=========================================================*");
            Console.ResetColor();

            //To show the ascii logo
            //that gets called for the class below
            DisplayCyberSecurityLogo();

            //Asking the user to enter their name
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n Please enter your name: ");
            Console.ResetColor();

            //This is to make sure that the user will enter the correct name
            string userName;
            while (true)
            {
                userName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userName) && userName.All(char.IsLetter))
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Wrong input! , Can you please enter a valid name (letters only) ");
                Console.ResetColor();
            }//End of while

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n Hello, {userName}! Ask me any question about staying safe online.");
                Console.ResetColor();
            

            //The questions that the user will ask
            //The Dictionary of things related to cybersecurity awareness responses
            Dictionary<string, string> responses = new Dictionary<string, string>()
          {
            { "protect personal information", "Limit the information you share online and adjust your privacy settings on social media." },
            { "hacked", "Change your passwords immediately, enable 2FA, and check for suspicious activity on your accounts." },
            { "cybersecurity threats", "Phishing, malware, ransomware, and identity theft are common threats. Stay informed and cautious!" },
            { "strong password", "Use at least 12 characters, mix uppercase, lowercase, numbers, and symbols." },
            { "phishing", "Phishing is a cyber attack where attackers trick you into revealing personal info via fake emails or websites." },
            { "browse safely", "Use HTTPS websites, avoid public Wi-Fi for sensitive transactions, and enable two-factor authentication." },
            { "two-factor authentication", "2FA adds an extra layer of security by requiring a second form of verification." },
            { "avoid malware", "Don't download files from untrusted sources, keep your software updated, and use antivirus protection." },
            {"VPN","A VPN (Virtual Private Network) encrypts your internet connection, improving privacy and security, especially on public Wi-Fi." },
            
            };

            // ArrayList to store possible cybersecurity-related questions
            ArrayList questionList = new ArrayList()
        {
            "How do I protect my personal information?",
            "What should I do if I get hacked?",
            "What are some common cybersecurity threats?",
            "How to create a strong password?",
            "What is phishing?",
            "How to browse safely?",
            "What is two-factor authentication?",
            "How to avoid malware?",
            "What is a VPN?"
        
            };//End of arrayList

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nAsk the cybersecurity question or type 'exit' to quit: ");
                Console.ResetColor();
                string question = Console.ReadLine().ToLower();

                if (question == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\n Please Stay safe online! Goodbye!");
                    Console.ResetColor();
                    break;
                }

                //This searches the response using the keyword that was matched
                string answer = responses.FirstOrDefault(kvp => question.Contains(kvp.Key)).Value;

                if (answer != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(answer);
                    Console.ResetColor();
                }
                else
                {
                    //If they dont enter the corrct question this message will pop up
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, I can only answer questions related to online safety.");
                    Console.WriteLine("Here are some questions you can ask:");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    foreach (string q in questionList)
                    {
                        Console.WriteLine($"- {q}");
                    }

                    Console.ResetColor();
                }//End of else

            }//End of while

        }//End of basic

        //This is the logo class that gets called in the main class
        static void DisplayCyberSecurityLogo()
        {
          
            //getting the full path
            string path_project = AppDomain.CurrentDomain.BaseDirectory;

            //then replacing the bin\\Debug\\
            string new_path_project = path_project.Replace("bin\\Debug\\", "");

            //then combining the project full path and the image with the format
            string full_path = Path.Combine(new_path_project, "Lgog.png");

            //working on the logo with ASCII
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(100, 50));



            //this is the for loop
          for (int height = 0; height < image.Height; height++)
            {
                //this is to work on the on the width and the hight of the image
                for (int width = 0; width < image.Width; width++)
                {

                    //working on the ascii design
                    Color pixecolor = image.GetPixel(width, height);
                    int color = (pixecolor.R + pixecolor.G + pixecolor.B) / 3;

                    //making use of char
                    char ascii_design = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? '0' : color > 50 ? '#' : '@';
                    Console.Write(ascii_design);//output the design

                }//end of the loop for inner
                Console.WriteLine();//to skip the line
            }//end of the loop for outer 


        }//End of static 

    }//End of class
}//End of namespace