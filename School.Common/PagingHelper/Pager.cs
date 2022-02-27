using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.PagingHelper
{
    public class childPage
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public bool enableFirstDot { get; set; }
        public bool enableLastDot { get; set; }

        public int goBack { get; set; }
        public int goNext { get; set; }
    }

    public class Pager
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; set; }
        public childPage chilPage { get; set; }

        public bool enablePrevious { get; set; }
        public bool enableNext { get; set; }

        public int firstDot { get; set; }
        public int lastDot { get; set; }
        public int goBack { get; set; }
        public int goNext { get; set; }

        public Pager(childPage cp, int totalItems, int? clickedPage, int pageSize = 12, int pageNumber = 5)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = (int)clickedPage;

            if (cp.CurrentPage > 4)
            {
                int remainPages = totalPages - cp.CurrentPage;

                    if (cp.CurrentPage == totalPages)
                    {
                        if (cp.CurrentPage > 5)
                        {
                            enablePrevious = true;
                        }
                        else
                        {
                            enablePrevious = false;
                        }
                    }
                    if (remainPages <= 4)//cp.StartPage = 1;
                    {
                        int newLastPage = totalPages - currentPage; // =3   29  32

                        int goFiveStepBack = totalPages - 5;
                        int newPage = 4 - newLastPage;  // = 2;
                        int newStart = currentPage - newPage;
                        cp.StartPage = newStart;
                    }
              
            }

            if (cp.StartPage == cp.CurrentPage)
            {
                if (cp.StartPage > 1)
                {
                    cp.EndPage = cp.StartPage;
                    currentPage = cp.CurrentPage;
                    cp.StartPage = (cp.EndPage - 4);
                }
            }
            else if (cp.EndPage == cp.CurrentPage)
            {
                cp.StartPage = cp.EndPage;
                currentPage = cp.CurrentPage;
                cp.EndPage = (cp.StartPage + 4);

                if (cp.EndPage < totalPages)
                {
                    enablePrevious = true;
                    firstDot = (cp.EndPage + 5);//Use this one
                    firstDot = totalPages;
                }
                if ((cp.EndPage + 4) < totalPages)
                {
                    enableNext = true;
                    lastDot = totalPages;
                }
            }
            else if (currentPage == cp.EndPage)
            {
            }
            else if (cp.EndPage < totalPages)
            {
            }
            else
            {
                //cp.StartPage = 1;
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = cp.StartPage;
            EndPage = cp.EndPage;
        }
    }
}
