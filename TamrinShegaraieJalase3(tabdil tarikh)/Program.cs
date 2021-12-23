using System;
using System.Globalization;

namespace TamrinShegaraieJalase3_tabdil_tarikh_
{
    class Program
    {
        /// <summary>
        /// باسلام
        /// تبدیل تاریخ شمسی به میلادی و بلعکس
        /// نرم افزر از 4 بخش تکیل شده 
        /// 1 - ورودی
        /// 2 - (تایید اطلاعات (به صورت مختصر
        /// 3 - منتطق و اجرای اطلاعات
        /// 4 - نمایش اررور
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool lExecution = true;
            string cWarningMessage = string.Empty;
            string cType = string.Empty,
                cYear = string.Empty,
                cMonth = string.Empty,
                cDay = string.Empty;

            int nType = 0,
                nYear = 0,
                nMonth = 0,
                nDay = 0;

            #region Input
            Console.WriteLine("Please press key 1 or 2");
            Console.WriteLine("1. Convert Shamsi to Miladi");
            Console.WriteLine("2. Convert Miladi to Shamsi");
            cType = Console.ReadLine();
            Console.WriteLine("Please enter Year: ");
            cYear = Console.ReadLine();
            Console.WriteLine("Please enter Month: ");
            cMonth = Console.ReadLine();
            Console.WriteLine("Please enter Day: ");
            cDay = Console.ReadLine();
            #endregion
            #region Validation
            if (lExecution && !int.TryParse(cType, out nType))
            {
                lExecution = false;
                cWarningMessage = "Type error! please open agein and press 1 or 2 key for valid type";
            }
            if (lExecution && nType != 1 && nType != 2)
            {
                lExecution = false;
                cWarningMessage = "Type error! please open agein and press 1 or 2 key for valid type";
            }

            if (lExecution && !int.TryParse(cYear, out nYear))
            {
                lExecution = false;
                cWarningMessage = "Year error! please open agein and enter valid year";
            }
            if (lExecution && nType == 1 && (nYear < 1200 || nYear > 1500))
            {
                lExecution = false;
                cWarningMessage = "Year error!please open agein and enter valid year";
            }
            if (lExecution && nType == 2 && (nYear < 1800 || nYear > 2200))
            {
                lExecution = false;
                cWarningMessage = "Year error!please open agein and enter valid year";
            }

            if (lExecution && !int.TryParse(cMonth, out nMonth))
            {
                lExecution = false;
                cWarningMessage = "Month error! please open agein and enter valid Month";
            }
            if (lExecution && (nMonth > 12 || nMonth < 1))
            {
                lExecution = false;
                cWarningMessage = "Month error! please open agein and enter valid Month";
            }

            if (lExecution && !int.TryParse(cDay, out nDay))
            {
                lExecution = false;
                cWarningMessage = "Day error! please open agein and enter valid Day";
            }
            if (lExecution && (nDay > 30 || nDay < 1))
            {
                lExecution = false;
                cWarningMessage = "Day error! please open agein and enter valid Day";
            }


            #endregion
            #region Logic
            if (lExecution && nType == 1)
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = new DateTime(nYear, nMonth, nDay, pc);
                Console.WriteLine("Your Miladi date: ");
                Console.WriteLine(dt);
            }

            if (lExecution && nType == 2)
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = DateTime.Parse(cYear + "-" + cMonth + "-" + cDay);
                Console.WriteLine("Your Shamsi date:");
                Console.WriteLine($"{pc.GetYear(dt)}/{pc.GetMonth(dt)}/{pc.GetDayOfMonth(dt)}");
            }
            #endregion
            #region Error
            if (!lExecution)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(cWarningMessage);
                Console.ForegroundColor = ConsoleColor.White;
            }
            #endregion

            Console.ReadKey();
        }
    }
}
