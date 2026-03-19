public enum BattleMove
{
    Missile,
    Defend,
    Lazer,
    Avoid,
}

public static class BattleMoveExtensions
{
    public static string ToStringFr(this BattleMove move)
    {
        return move switch
        {
            BattleMove.Lazer => "Laser",
            BattleMove.Missile => "Missile",
            BattleMove.Defend => "Bouclier",
            BattleMove.Avoid => "Manoeuvre",
            _ => "???",
        };
    }

    public static string DescriptionFr(this BattleMove move)
    {
        return move switch
        {
            BattleMove.Lazer => "L'ennemi prépare un rayon laser.",
            BattleMove.Missile => "L'ennemi arme ses canons pour tirer des missiles.",
            BattleMove.Defend => "L'ennemi lève son bouclier.",
            BattleMove.Avoid => "L'ennemi s'apprête à manoeuvrer.",
            _ => "L'ennemi fait un truc inattendu o_O",
        };
    }
}