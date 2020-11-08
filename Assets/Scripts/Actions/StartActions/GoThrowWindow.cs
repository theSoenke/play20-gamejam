public class GoThrowWindow : ActionDescription
{
    public float SusValue = 10f;

    public override string Description(GameState state)
    {
        string[] responses = { "I need to get in there, oh look a window..", "This party rocks 🤘 Maybe I should try to find a window" };
        return RandomString.Select(responses);
    }

    public override int EvaluateProbability(GameState state)
    {
        return state.IsInside ? 0 : 1;
    }

    public override void Execute(GameState state)
    {
        state.SusAdd(SusValue);
        state.GoInside();
    }
}
