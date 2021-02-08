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

        static void cisnij(IWebDriver driver, IWebDriver driver2)
        {
            String getDataInLocalVar = "";
            String getDataInLocalVar2 = "";
            String slowo1 = "";
            String slowo2 = "";
            String slowo3 = "";
            //okno 1
            try
            {

                driver.Navigate().GoToUrl("https://skribbl.io/");
                Thread.Sleep(1000);
                IWebElement ele1 = driver.FindElement(By.Id("cmpbntyestxt"));
                ele1.Click();
                Thread.Sleep(1000);
                IWebElement ele11 = driver.FindElement(By.Id("loginLanguage"));
                var selectElement = new SelectElement(ele11);
                selectElement.SelectByText("Polish");
                Thread.Sleep(300);
                IWebElement ele2 = driver.FindElement(By.Id("buttonLoginCreatePrivate"));
                ele2.Click();
                Thread.Sleep(1000);
                IWebElement ele18 = driver.FindElement(By.Id("lobbySetRounds"));
                var selectElement3 = new SelectElement(ele18);
                selectElement3.SelectByText("10");
                Thread.Sleep(300);
                IWebElement ele3 = driver.FindElement(By.Id("inviteCopyButton"));
                ele3.Click();
                Actions a = new Actions(driver);
                driver.FindElement(By.Id("lobbySetCustomWords")).SendKeys(Keys.Control + "v");
                getDataInLocalVar = driver.FindElement(By.Id("lobbySetCustomWords")).GetAttribute("value");
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                try
                {
                    driver.Quit();
                    driver2.Quit();
                }
                catch
                {

                }
                Environment.Exit(1);
            }

            //okno 2
            try
            {
                driver2.Navigate().GoToUrl(getDataInLocalVar);
                Thread.Sleep(1000);
                IWebElement ele4 = driver2.FindElement(By.Id("cmpbntyestxt"));
                ele4.Click();
                Thread.Sleep(1000);
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

            //okno 1
            try
            {
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

            //okno2
            try
            {
                slowo1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
                slowo2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
                slowo3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }

            string filename = RandomString(30);


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            //////////////////////////////////////////////////////////////////////////////////////////////////////

            //okno2
            try
            {
                IWebElement ele25 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }

            
            //okno 1
            try
            {
                IWebElement ele12 = driver.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(6000);
                slowo1 = driver.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
                slowo2 = driver.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
                slowo3 = driver.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            //okno1
            try
            {
                IWebElement ele25 = driver.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 2
            try
            {
                IWebElement ele12 = driver2.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver2);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(12000);
            slowo1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno2
            try
            {
                IWebElement ele25 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 1
            try
            {
                IWebElement ele12 = driver.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(6000);
            slowo1 = driver.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno1
            try
            {
                IWebElement ele25 = driver.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 2
            try
            {
                IWebElement ele12 = driver2.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver2);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(12000);
            slowo1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno2
            try
            {
                IWebElement ele25 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 1
            try
            {
                IWebElement ele12 = driver.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(6000);
            slowo1 = driver.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);


            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno1
            try
            {
                IWebElement ele25 = driver.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 2
            try
            {
                IWebElement ele12 = driver2.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver2);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(12000);
            slowo1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno2
            try
            {
                IWebElement ele25 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 1
            try
            {
                IWebElement ele12 = driver.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(6000);
            slowo1 = driver.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);


            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno1
            try
            {
                IWebElement ele25 = driver.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 2
            try
            {
                IWebElement ele12 = driver2.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver2);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(12000);
            slowo1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno2
            try
            {
                IWebElement ele25 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 1
            try
            {
                IWebElement ele12 = driver.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(6000);
            slowo1 = driver.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno1
            try
            {
                IWebElement ele25 = driver.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 2
            try
            {
                IWebElement ele12 = driver2.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver2);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(12000);
            slowo1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno2
            try
            {
                IWebElement ele25 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 1
            try
            {
                IWebElement ele12 = driver.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(6000);
            slowo1 = driver.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno1
            try
            {
                IWebElement ele25 = driver.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 2
            try
            {
                IWebElement ele12 = driver2.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver2);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(12000);
            slowo1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno2
            try
            {
                IWebElement ele25 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 1
            try
            {
                IWebElement ele12 = driver.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(6000);
            slowo1 = driver.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno1
            try
            {
                IWebElement ele25 = driver.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 2
            try
            {
                IWebElement ele12 = driver2.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver2);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(12000);
            slowo1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno2
            try
            {
                IWebElement ele25 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 1
            try
            {
                IWebElement ele12 = driver.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(6000);
            slowo1 = driver.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno1
            try
            {
                IWebElement ele25 = driver.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 2
            try
            {
                IWebElement ele12 = driver2.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver2);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(12000);
            slowo1 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver2.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver2.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //okno2
            try
            {
                IWebElement ele25 = driver2.FindElement(By.CssSelector("div.word:nth-child(1)"));
                ele25.Click();
                Thread.Sleep(3000);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            //okno 1
            try
            {
                IWebElement ele12 = driver.FindElement(By.Id("inputChat"));
                Actions b = new Actions(driver);
                ele12.Clear();
                ele12.SendKeys(slowo1);
                Thread.Sleep(50);
                ele12.SendKeys(Keys.Enter);
            }
            catch (Exception x)
            {
                Console.WriteLine("Exception: " + x.ToString());
                driver.Quit();
                driver2.Quit();
                Environment.Exit(1);
            }


            Thread.Sleep(6000);
            slowo1 = driver.FindElement(By.CssSelector("div.word:nth-child(1)")).Text;
            slowo2 = driver.FindElement(By.CssSelector("div.word:nth-child(2)")).Text;
            slowo3 = driver.FindElement(By.CssSelector("div.word:nth-child(3)")).Text;


            File.AppendAllText("slowa/" + filename + ".txt", slowo1 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo2 + Environment.NewLine);
            File.AppendAllText("slowa/" + filename + ".txt", slowo3 + Environment.NewLine);





            driver.Quit();
            driver2.Quit();
            Console.WriteLine("filename:");
            Console.WriteLine(filename);
        }
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            IWebDriver driver2 = new FirefoxDriver();

            var task = Task.Run(() => cisnij(driver, driver2));
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