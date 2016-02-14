using System;
using System.Threading;
using OpenQA.Selenium;

namespace AcceptanceTests.Extensions
{
    public static class ClickExtensitons
    {
        public static void ClickAndWait(this IWebElement element, double timeoutInSeconds)
        {
            if (!(timeoutInSeconds > 0)) return;
            var timeout = timeoutInSeconds * 1000;
            element.Click();
            Thread.Sleep(Convert.ToInt32(timeout));
        }
    }
}