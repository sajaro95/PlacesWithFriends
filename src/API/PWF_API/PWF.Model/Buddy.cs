using System.ComponentModel.DataAnnotations.Schema;

namespace PWF.Model
{
    public class Buddy
    {
        public int BuddyUserId { get; set; }
        public int MainUserId { get; set; }

        public virtual User BuddyUser { get; set; }
        public virtual User MainUser { get; set; }
    }
}
