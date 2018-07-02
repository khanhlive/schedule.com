using PagedList.Mvc;
using System.Collections.Generic;

namespace schedule.data.helpers
{
    public class HtmlHelper
    {
        public static PagedListRenderOptions GetPagedListRenderOptions = new PagedListRenderOptions
        {
            Display = PagedListDisplayMode.Always,
            DisplayLinkToFirstPage = PagedListDisplayMode.Always,
            DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
            DisplayLinkToNextPage = PagedListDisplayMode.Always,
            DisplayLinkToLastPage = PagedListDisplayMode.Always, LiElementClasses=new List<string> { "footable-page" },
        };
    }
}
