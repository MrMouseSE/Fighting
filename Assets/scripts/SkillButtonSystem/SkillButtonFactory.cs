using UnityEngine;
using UnityEngine.UI;

namespace SkillButtonSystem
{
    public class SkillButtonFactory : IFactory
    {
        public GameObject Create(SkillButtonContainer container)
        {
            var go = new GameObject();
            go.name = "Button_" + container.Name;
            go.AddComponent<CanvasRenderer>();
            go.AddComponent<Button>();
            var image = go.AddComponent<Image>();
            image.sprite = container.Icon;
            var goText = new GameObject();
            goText.transform.SetParent(go.transform);
            goText.AddComponent<CanvasRenderer>();
            goText.AddComponent<Text>();
            
            return go;
        }
    }
}
