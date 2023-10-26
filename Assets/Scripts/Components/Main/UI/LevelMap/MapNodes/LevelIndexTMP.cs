using Extensions.Unity.MonoHelper;

namespace Components.Main.UI.LevelMap.MapNodes
{
    public class LevelIndexTMP : UITMP
    {
        public void Construct(int levelIndex)
        {
            _myTMP.text = levelIndex.ToString();
        }
    }
}