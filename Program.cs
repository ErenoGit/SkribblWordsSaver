using System;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace SkribblWordsSaver
{
    class Program
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void Start(IWebDriver driver, IWebDriver driver2)
        {
            String getDataInLocalVar = "";
            String getDataInLocalVar2 = "";
            String word1 = "";
            String word2 = "";
            String word3 = "";

            //window 1
            try
            {
                //open skribbl.io
                driver.Navigate().GoToUrl("https://skribbl.io/");
                Thread.Sleep(1000);
                //agree cookies
                IWebElement ele1 = driver.FindElement(By.Id("cmpbntyestxt"));
                ele1.Click();
                Thread.Sleep(1000);
                //change language to Polish
                IWebElement ele11 = driver.FindElement(By.Id("loginLanguage"));
                var selectElement = new SelectElement(ele11);
                selectElement.SelectByText("Polish");
                Thread.Sleep(300);
                //create private room
                IWebElement ele2 = driver.FindElement(By.Id("buttonLoginCreatePrivate"));
                ele2.Click();
                Thread.Sleep(1000);
                //set 10 rounds in private room
                IWebElement ele18 = driver.FindElement(By.Id("lobbySetRounds"));
                var selectElement3 = new SelectElement(ele18);
                selectElement3.SelectByText("10");
                Thread.Sleep(300);
                //copy private room address
                IWebElement ele3 = driver.FindElement(By.Id("inviteCopyButton"));
                ele3.Click();
                Actions a = new Actions(driver);
                driver.FindElement(By.Id("lobbySetCustomWords")).SendKeys(Keys.Control + "v");
                getDataInLocalVar = driver.FindElement(By.Id("lobbySetCustomWords")).GetAttribute("value");
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }

            //window 2
            try
            {
                //open skribbl.io private room address
                driver2.Navigate().GoToUrl(getDataInLocalVar);
                Thread.Sleep(1000);
                //agree cookies
                IWebElement ele4 = driver2.FindElement(By.Id("cmpbntyestxt"));
                ele4.Click();
                Thread.Sleep(1000);
                //join room
                IWebElement ele5 = driver2.FindElement(By.CssSelector("button.btn:nth-child(3)"));
                ele5.Click();
                Thread.Sleep(1000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }

            //window 1
            try
            {
                //start game
                IWebElement ele6 = driver.FindElement(By.Id("buttonLobbyPlay"));
                ele6.Click();
                Thread.Sleep(6000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }

            //window 2
            try
            {
                //get 3 propositions for word in this game
                word1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
                word2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
                word3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }

            //generate random 30 chars string for filename, it's not necessary, I did it for no reason
            string filename = RandomString(30);

            //save 3 words in txt file
            File.AppendAllText(filename + ".txt", word1 + Environment.NewLine);
            File.AppendAllText(filename + ".txt", word2 + Environment.NewLine);
            File.AppendAllText(filename + ".txt", word3 + Environment.NewLine);

            //show on console name of txt file
            Console.WriteLine("filename: "+filename);
        }

        static void Main(string[] args)
        {
            //start 2 Firefox windows
            IWebDriver driver = new FirefoxDriver();
            IWebDriver driver2 = new FirefoxDriver();

            //start job, timeout - 5 min
            var task = Task.Run(() => Start(driver, driver2));
            if (task.Wait(TimeSpan.FromSeconds(300)))
                Console.WriteLine("OK");
            else
            {
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }
        }
    }
}