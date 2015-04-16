namespace CalendarUGCCWebService.Models.Pray
{
    public class PrayItem
    {    
        public enum Actors
        {
            Prist,
            People
        };

        public string Actor { get; set; } 
    
        public string AheadText { get; set; }
        public string Text { get; set; }
        public string AfterText { get; set; }

        public PrayItem()
        {

        }
        public PrayItem(string afterText, string aheadText)
        {
            AfterText = afterText;
            AheadText = aheadText;
        }
        public PrayItem(Actors actor, string text)
        {
            Text = text;
            Actor = actor.ToString();
        }

        public PrayItem(string afterText, string actor, string text)
        {
            AfterText = afterText;
            Text = text;
            Actor = actor;
        }


    }
}