using System.Collections.Generic;

namespace FightersCon
{
    public interface IObjectProducer 
    {
        IEnumerable<WorldObject> ProduceObjects();
    }   
}
