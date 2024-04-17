using TrelloDBLayer;

namespace TrelloApp.ViewModels.Base
{
    public static class CurrentData
    {
        public static User CurrentUser { get; set; }
        public static Board CurrentBoard { get; set; }
        public static Task CurrentTask { get; set; }
    }
}
