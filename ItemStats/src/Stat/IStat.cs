namespace ItemStats.Stat
{
    public interface IStat
    {
        float? GetInitialStat(float count, StatContext context);

        string Format(float statValue);
    }
}