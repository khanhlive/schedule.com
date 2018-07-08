using PagedList.Mvc;
using schedule.data.enums;
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
            LinkToPreviousPageFormat= "‹",
            LinkToFirstPageFormat= "«",
            LinkToNextPageFormat= "›",
            LinkToLastPageFormat= "»"
        };
    }
    

    public class MessageObject
    {
        public MessageObjectType type { get; set; }
        public string title { get; set; }
        public string message { get; set; }
    }
}
