#if TOOLS

using Godot;
using JetBrains.Annotations;

namespace Exilland.GodotCon.CardEffects.addons.CardResources
{
    [Tool]
    [UsedImplicitly]
    public class CustomResources : EditorPlugin
    {
        public override void _EnterTree()
        {
            AddCustomType(nameof(Card.Cards.CardInfo), nameof(Resource), GD.Load<Script>("res://Card/Cards/CardInfo.cs"), null);
            AddAllTypesFrom("res://Card/Effects/", "0.Effect/");
        }

        public override void _ExitTree()
        {
            RemoveCustomType(nameof(Card.Cards.CardInfo));
            RemoveAllTypesFrom("res://Card/Effects/", "0.Effect/");
        }

        private void AddAllTypesFrom(string path, string prefix)
        {
            using var dir = new Directory();
            if (dir.Open(path) != Error.Ok)
                return;

            dir.ListDirBegin(skipHidden: true, skipNavigational: true);
            string fileName;
            while (!string.IsNullOrEmpty(fileName = dir.GetNext()))
            {
                GD.Print($"Trying to add: {fileName}");
                if (dir.CurrentIsDir())
                    continue;

                var fullPath = System.IO.Path.Combine(path, fileName);
                if (System.IO.Path.GetExtension(fullPath) != ".cs")
                    continue;

                var script = GD.Load<CSharpScript>(fullPath);
                if (script == null)
                    continue;

                var typeName = System.IO.Path.GetFileNameWithoutExtension(fullPath);
                AddCustomType(prefix + typeName, nameof(Resource), script, null);
            }
            dir.ListDirEnd();
        }

        private void RemoveAllTypesFrom(string path, string prefix)
        {
            using var dir = new Directory();
            if (dir.Open(path) != Error.Ok)
                return;

            dir.ListDirBegin(skipHidden: true, skipNavigational: true);
            string fileName;
            while (!string.IsNullOrEmpty(fileName = dir.GetNext()))
            {
                if (dir.CurrentIsDir())
                    continue;

                var fullPath = System.IO.Path.Combine(path, fileName);
                if (System.IO.Path.GetExtension(fullPath) != ".cs")
                    continue;

                var typeName = System.IO.Path.GetFileNameWithoutExtension(fullPath);
                RemoveCustomType(prefix + typeName);
            }
            dir.ListDirEnd();
        }
    }
}

#endif