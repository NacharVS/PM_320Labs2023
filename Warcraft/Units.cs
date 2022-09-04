static class Units
{
    static public List<Unit> units = new List<Unit>();

    static public List<Unit> GetArchers()
    {
        List<Unit> archers = new List<Unit>();

        foreach(var unit in units)
        {
            if(unit is Archer)
            {
                archers.Add(unit);
            }
        }

        return archers;
    }

    static public List<Unit> GetMilitary()
    {
        List<Unit> military = new List<Unit>();

        foreach(var unit in units)
        {
            if(unit is Military)
            {
                military.Add(unit);
            }
        }

        return military;
    }
}