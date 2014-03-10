namespace FightersCon
{
    using System.Collections.Generic;

    public interface IUserInterface
    {
        void ProcessInput(WorldObject hero, List<WorldObject> otherObjects);
    }
}
