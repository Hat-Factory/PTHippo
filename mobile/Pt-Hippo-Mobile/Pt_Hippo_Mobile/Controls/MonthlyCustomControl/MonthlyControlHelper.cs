using Pt_Hippo_Mobile.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pt_Hippo_Mobile.Controls.MonthlyCustomControl
{
    public static class MonthlyControlHelper
    {
        private static string noData = "No Data";
        public static string CurrentYear = noData;
        public static string CurrentMonth = noData;
        public static Dictionary<int, List<string>> MonthlyData;
        public static MonthNode head;
        private static MonthNode tail;
        public static MonthNode current;
        public static bool forceReload = false;

        public static int GetCurrentMonthNumber()
        {
            int i = DateTime.ParseExact(CurrentMonth, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;
            return i;
        }
        public static async Task ReloadAPIData()
        {
            try
            {
                current = null;
                tail = null;
                head = null;
                MonthlyData = null;
                if (forceReload == false)
                {
                    return;
                }

                if (MonthlyData == null)
                {
                    MonthlyData = new Dictionary<int, List<string>>();
                }

                MonthlyAPIService monthlyService = new MonthlyAPIService();
                MonthlyData = await monthlyService.GetMonthlyCalenderAPI(URLConfig.MonthlyCalenderAPI);
                var selectedNode = new MonthNode();
                foreach (int year in MonthlyData.Keys)
                {
                    foreach (string month in MonthlyData[year])
                    {
                        if (head == null)
                        {
                            head = new MonthNode
                            {
                                Month = month,
                                Year = year.ToString(),
                                Next = null,
                                Previous = null
                            };

                            selectedNode = head;
                            current = head;
                        }
                        else
                        {
                            var newNode = new MonthNode
                            {
                                Month = month,
                                Year = year.ToString(),
                            };
                            newNode.Next = null;
                            newNode.Previous = selectedNode;
                            selectedNode.Next = newNode;
                            tail = newNode;
                            selectedNode = tail;

                        }

                        CurrentMonth = selectedNode.Month;
                        CurrentYear = selectedNode.Year;

                    }
                }

                current = head;

            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("Error in while trying to load monthly calender API data", ex);
                await logged.LoggAPI();
            }

        }

        private static void Start()
        {
            if (head != null)
            {
                CurrentMonth = head.Month;
                CurrentYear = head.Year;
            }
            else
            {
                CurrentMonth = noData;
                CurrentYear = noData;
            }
        }
         
        public static bool SlideRight()
        {
            try
            {

                if (current != null)
                {
                    current = current.Previous; 
                } 
                if (current == null)
                {
                    current = tail;
                    if (tail == null)
                    {
                        CurrentMonth = noData;
                        CurrentYear = noData;
                        return false;
                    }
                     
                } 
                CurrentMonth = current.Month;
                CurrentYear = current.Year;
                return MonthlyData.Count() >= 1 ? true : false;

                 
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("error in MonthlyControlHelper.cs", ex);
                logged.LoggAPI();
            }
            return false;
        }

        

        public static bool SlideLeft()
        {
            try
            {
                if (current != null)
                {
                    current = current.Next; 
                }
                if (current == null)
                { 
                    current = head;
                    if (head == null)
                    {
                        CurrentMonth = noData;
                        CurrentYear = noData;
                        return false;
                    }
                  
                } 
                CurrentMonth = current.Month;
                CurrentYear = current.Year;
                return MonthlyData.Count() >= 1 ? true : false;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException.LoggedException("error in MonthlyControlHelper.cs", ex);
                logged.LoggAPI();
            }
            return false;
        }
    }
}

 