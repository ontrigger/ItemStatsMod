namespace ItemStats.Stat
{
    public interface IStat
    {
        float? GetInitialStat(float count);

        string Format(float statValue);
    }
}