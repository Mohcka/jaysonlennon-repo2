using System;

namespace AptMgmtPortal.Entity
{
    public class Period
    {
        DateTimeOffset Start { set; get; }
        DateTimeOffset End { set; get; }

        public Period(DateTimeOffset start, DateTimeOffset end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}