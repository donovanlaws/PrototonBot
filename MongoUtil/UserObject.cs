namespace PrototonBot.MongoUtil
{
  public class UserObject
  {
    /// <summary>
    /// Discord ID of the User.
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// Discord Username of the User.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Money the User has.
    /// </summary>
    public long Money { get; set; }
    /// <summary>
    /// TimeStamp of the last time a Daily was claimed.
    /// </summary>
    public long LastDaily { get; set; }
    /// <summary>
    /// Tracks the days the user has been claiming their daily daily.
    /// </summary>
    public long DailyStreak { get; set; }
    /// <summary>
    /// Level of the User.
    /// </summary>
    public int Level { get; set; }
    /// <summary>
    /// Experience the User has.
    /// </summary>
    public long EXP { get; set; }
    /// <summary>
    /// TimeStamp of the last message that counted towards minuteMoney + XP
    /// </summary>
    public long LastMessage { get; set; }
    /// <summary>
    /// Number of Pats the User has received.
    /// </summary>
    public int PatsReceived { get; set; }
    /// <summary>
    /// TimeStamp of the last pat the User claimed.
    /// </summary>
    public int LastPat { get; set; }
    /// <summary>
    /// Number of Purchases the User has made.
    /// </summary>
    public int Purchases { get; set; }
    /// <summary>
    /// Description the user set to their profile.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// ID of the User's current Partner as a string.
    /// </summary>
    public string Partner { get; set; }
    /// <summary>
    /// Whether or not the user is mutual partners with another user.
    /// </summary>
    public bool Mutuals { get; set; }
    /// <summary>
    /// Whether or not the user has purchased the Boosted Effect.
    /// </summary>
    public bool Boosted { get; set; }
    /// <summary>
    /// TimeStamp of the last time the user Gambled.
    /// </summary>
    public long LastGamble { get; set; }
    /// <summary>
    /// Number of Gambles the User has done.
    /// </summary>
    public int Gambles { get; set; }
    /// <summary>
    /// Number of Gambles the User has won.
    /// </summary>
    public int GamblesWon { get; set; }
    /// <summary>
    /// Number of Gambles the User has lost.
    /// </summary>
    public int GamblesLost { get; set; }
    /// <summary>
    /// Amount of money the user has won from gambling.
    /// </summary>
    public int GamblesNetGain { get; set; }
    /// <summary>
    /// Amount of money the user has lost from gambling.
    /// </summary>
    public int GamblesNetLoss { get; set; }
    /// <summary>
    /// The User's Luck stat.
    /// </summary>
    public int Luck { get; set; }
    /// <summary>
    /// The User's DailyBonus stat.
    /// </summary>
    public int DailyBonus { get; set; }
    /// <summary>
    /// The Amount the user has Donated.
    /// </summary>
    public int Donations { get; set; }
    /// <summary>
    /// The amount of money the user received via transfers.
    /// </summary>
    public long TransferIn { get; set; }
    /// <summary>
    /// The amount of money the user sent via transfers.
    /// </summary>
    public long TransferOut { get; set; }
  }
}
